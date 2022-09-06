import { Component, OnInit,Inject } from '@angular/core';
import { ModuleService, Subject } from '../services/module.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Exam } from '../services/grade.service';


@Component({
  selector: 'app-new-grade',
  templateUrl: './new-grade.component.html',
  styleUrls: ['./new-grade.component.scss']
})
export class NewGradeComponent implements OnInit {

modul:any;
  
  constructor(
    public dialogRef: MatDialogRef<NewGradeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Exam, private Modulservice: ModuleService
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  

  public getModule() {
    let resp = this.Modulservice.getModule();
    resp.subscribe(report => this.modul = report as Subject[]);
    console.log('modul',this.modul);
  }

  ngOnInit(): void {
    this.getModule();
  }

}
