import { EducationTypeService } from './../_services/education-type.service';
import { CompetenceAreaService } from './../_services/competence-area.service';
import { CompetenceArea } from './../_models/competenceArea';
import { EducationType } from '../_models/educationType';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, OnInit,Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Module } from '../_models/module';
import { ModuleService } from '../_services/module.service';

@Component({
  selector: 'app-new-subject-module',
  templateUrl: './new-subject-module.component.html',
  styleUrls: ['./new-subject-module.component.scss']
})
export class NewSubjectModuleComponent implements OnInit {

  createModuleForm : FormGroup
  module : Module
  educationTypes : EducationType[]
  selectedEducationTypeId : number
  competenceAreas : CompetenceArea[]
  private userId = localStorage.getItem('userId');

  constructor(
    public dialogRef: MatDialogRef<NewSubjectModuleComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Module,
    private competenceAreaService : CompetenceAreaService,
    private educationTypeService : EducationTypeService,
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
    this.educationTypeService.getAll().subscribe(response =>{
      this.educationTypes = response
      console.warn(this.educationTypes)
    })
    console.warn(this.userId)
  }

  competenceAreasByEducationType() {
    this.competenceAreaService.getByEducationType(this.selectedEducationTypeId).subscribe(response => {
      this.competenceAreas = response
    })
  }
}
