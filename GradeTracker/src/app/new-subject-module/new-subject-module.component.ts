import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit,Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Module } from '../_models/module';
import { ModuleService } from '../_services/module.service';

@Component({
  selector: 'app-new-subject-module',
  templateUrl: './new-subject-module.component.html',
  styleUrls: ['./new-subject-module.component.scss']
})
export class NewSubjectModuleComponent implements OnInit {

  createModuleForm : FormGroup

  constructor(
    public dialogRef: MatDialogRef<NewSubjectModuleComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Module,
    private http:HttpClient,
    private formBuilder : FormBuilder) {
      this.createModuleForm = this.formBuilder.group({
        name : [null],
        competenceArea : [null],
        showOnDashboard : [null],
        teacher : formBuilder.group({
          name: [null]
        })
      })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

 onSubmit(){
  this.http.post('https://localhost:7290/api/Module/create', this.createModuleForm.value).subscribe((result)=>{
    console.warn("result", result);
  })
 }

  ngOnInit(): void {
  }

}
