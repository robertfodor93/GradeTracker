import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit,Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Subject } from '../services/module.service';
import { ModuleService } from '../services/module.service';

@Component({
  selector: 'app-newgoal',
  templateUrl: './newgoal.component.html',
  styleUrls: ['./newgoal.component.scss']
})



export class NewgoalComponent implements OnInit {

  newGoal : FormGroup

  constructor(
    public dialogRef: MatDialogRef<NewgoalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Subject,
    private http:HttpClient,
    private formBuilder : FormBuilder) {
      this.newGoal = this.formBuilder.group({
        name : [null],
        goal : [null],
      })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

 onSubmit(){
  this.http.post('https://localhost:7290/api/Module/create', this.newGoal.value).subscribe((result)=>{
    console.warn("result", result);
  })
 }

  ngOnInit(): void {
  }

}
