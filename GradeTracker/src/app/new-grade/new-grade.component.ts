import { Component, OnInit,Inject } from '@angular/core';
import { ModuleService, Subject } from '../services/module.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Exam ,GradeService } from '../services/grade.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-new-grade',
  templateUrl: './new-grade.component.html',
  styleUrls: ['./new-grade.component.scss']
})
export class NewGradeComponent implements OnInit {

modul:any;
  
  constructor(
    public dialogRef: MatDialogRef<NewGradeComponent>,
    @Inject(MAT_DIALOG_DATA ) public data: Exam, private Modulservice: ModuleService, private GradeService: GradeService, private http:HttpClient
  ) {}

  onClick() {
    this.postGrade(this.data)
  }

  postGrade(data : Exam){
    const headers = { 'content-type': 'application/json'} 
    const grade = JSON.stringify(data);
    console.log(grade)
    this.http.post('https://localhost:7290/api/Mark/create', grade, {'headers':headers}).subscribe((result)=>{
      console.warn("result", result);
    });
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
