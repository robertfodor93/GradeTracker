import { EducationtypeService } from './../_services/educationtype.service';
import { AuthService } from './../_services/auth.service';
import { CompetenceArea } from './../_models/competenceArea';
import { EducationType } from '../_models/educationType';
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
  educationTypes : EducationType[] = []
  competenceAreas : CompetenceArea[] = []
  private userId = localStorage.getItem('userId');

  constructor(
    public dialogRef: MatDialogRef<NewSubjectModuleComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Module,
    private competenceAreaService : CompetenceareaService,
    private educationtypeService : EducationtypeService,
    private moduleService : ModuleService,
    private formBuilder : FormBuilder) {
      this.createModuleForm = this.formBuilder.group({
        name : [null],
        educationTypeId : [null],
        competenceAreaId : [null],
        showOnDashboard : [null],
        userId : [this.userId],
        teacher : formBuilder.group({
          name: [null]
        }),
      })
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

 onSubmit(){
  this.moduleService.create(this.createModuleForm.value).subscribe((result) => {
    console.warn(result)
  })
 }

  ngOnInit() {
    this.educationtypeService.getAll().subscribe(response =>{
      this.educationTypes = response
      console.warn(response)
    })
    this.competenceAreaService.getAll().subscribe(response =>{
      this.competenceAreas = response
    })
  }

  filterCompetenceArea(id : number) {
    return this.competenceAreas.filter(ca => ca.educationTypeId = id)
  }
}
