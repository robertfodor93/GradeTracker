import { CompetenceArea } from './../_models/competenceArea';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit,Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Module } from '../_models/module';
import { ModuleService } from '../_services/module.service';
import { CompetenceareaService } from '../_services/competencearea.service';

@Component({
  selector: 'app-new-subject-module',
  templateUrl: './new-subject-module.component.html',
  styleUrls: ['./new-subject-module.component.scss']
})
export class NewSubjectModuleComponent implements OnInit {

  createModuleForm : FormGroup
  competenceAreas : CompetenceArea[] = []

  constructor(
    public dialogRef: MatDialogRef<NewSubjectModuleComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Module,
    private http:HttpClient,
    private competenceAreaService : CompetenceareaService,
    private moduleService : ModuleService,
    private formBuilder : FormBuilder) {
      this.createModuleForm = this.formBuilder.group({
        name : [null],
        competenceAreaId : [null],
        showOnDashboard : [null],
        teacher : formBuilder.group({
          name: [null]
        })
      })
  }

 
  get competenceAreaId() {
    return this.createModuleForm.get('competenceAreaId')
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

 onSubmit(){
  this.moduleService.create(this.createModuleForm.value).subscribe()
 }

  ngOnInit() {
    this.competenceAreaService.getAll().subscribe(response =>{
      this.competenceAreas = response
      console.warn(response)
    })
  }

}
