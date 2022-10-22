import { Module } from './../_models/module';
import { Mark } from './../_models/mark';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
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
  modules: Module[];


  constructor(
    public dialogRef: MatDialogRef<NewgoalComponent>,
    private moduleService: ModuleService,
    private formBuilder : FormBuilder) {
  }

  onSubmit() {
    this.moduleService.update(this.newGoalForm.value).subscribe()
  }


  ngOnInit() {
    this.moduleService.getAll()
      .subscribe(response => {
        this.modules = response;
      });
    console.log(this.modules)

    this.newGoalForm = this.formBuilder.group({
      id : [null],
      averageDesiredMark : [null],
    })
  }


  onNoClick(): void {
    this.dialogRef.close();
  }

}
