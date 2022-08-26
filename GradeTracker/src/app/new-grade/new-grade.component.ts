import { Component, OnInit,Inject } from '@angular/core';

import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Exam } from '../grade-overview/grade-overview.component';


@Component({
  selector: 'app-new-grade',
  templateUrl: './new-grade.component.html',
  styleUrls: ['./new-grade.component.scss']
})
export class NewGradeComponent implements OnInit {


  
  constructor(
    public dialogRef: MatDialogRef<NewGradeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Exam,
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  


  ngOnInit(): void {
  }

}
