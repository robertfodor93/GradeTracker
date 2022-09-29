import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Module } from '../_models/module';
import { Goal } from '../_models/goal';
import { ModuleService } from '../_services/module.service';

@Component({
  selector: 'app-newgoal',
  templateUrl: './newgoal.component.html',
  styleUrls: ['./newgoal.component.scss']
})



export class NewgoalComponent implements OnInit {
  goal = new Goal()
  newGoalForm: FormGroup;
  posts: any;


  constructor(
    public dialogRef: MatDialogRef<NewgoalComponent>,
    private http: HttpClient,
    private moduleService: ModuleService,
    private formBuilder : FormBuilder) {
  }

  onSubmit() {
    this.moduleService.setGoal(this.newGoalForm.value).subscribe()
  }


  ngOnInit() {
    this.moduleService.getAll()
      .subscribe(response => {
        this.posts = response;
      });
    console.log(this.posts)

    this.newGoalForm = this.formBuilder.group({
      id : [null],
      averageDesiredMark : [null],
    })
  }


  onNoClick(): void {
    this.dialogRef.close();
  }

}
