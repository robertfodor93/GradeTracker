import { Component, OnInit,Inject } from '@angular/core';
import { ModuleService} from '../_services/module.service';
import { Module } from '../_models/module';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MarkService } from '../_services/mark.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-new-grade',
  templateUrl: './new-grade.component.html',
  styleUrls: ['./new-grade.component.scss']
})
export class NewGradeComponent implements OnInit {

  newMarkForm : FormGroup
  modules : any
  
  constructor(
    public dialogRef: MatDialogRef<NewGradeComponent>,
    private moduleService: ModuleService, private markService: MarkService, private http:HttpClient, private formBuilder : FormBuilder
  ) {
    
  }

  onSubmit() {
    this.markService.createMark(this.newMarkForm.value).subscribe()
  }

  ngOnInit() {
    this.moduleService.getAll()
      .subscribe(response => {
        this.modules = response;
      });
    console.log(this.modules)

    this.newMarkForm = this.formBuilder.group({
      mark: [null],
      description : [null],
      weighting : [null],
      date : [null],
      moduleId : [null]
    })
  }
}
