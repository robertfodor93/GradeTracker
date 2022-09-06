import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit,Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Subject } from '../services/module.service';
import { ModuleService } from '../services/module.service';
import { GoalService } from '../services/goal.service';

@Component({
  selector: 'app-newgoal',
  templateUrl: './newgoal.component.html',
  styleUrls: ['./newgoal.component.scss']
})



export class NewgoalComponent implements OnInit {
  newGoal: FormGroup;
  posts: any;
  

  constructor(
    public dialogRef: MatDialogRef<NewgoalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Subject,
    private http:HttpClient,
    private formBuilder : FormBuilder, private service:ModuleService, private serviceGoal:GoalService) {
        this.newGoal = new FormGroup({
          fach: new FormControl(''),
          goal: new FormControl(''),
        });

  }

  onNoClick(): void {
    this.dialogRef.close();
  }

 onSubmit(){
  console.log(this.newGoal);
  this.serviceGoal.setGoals(this.newGoal.get('name')?.value)
  }
 

 ngOnInit(){
  this.service.getModule()
    .subscribe(response => {
      this.posts = response;
    });
    console.log(this.posts)
  }
}
