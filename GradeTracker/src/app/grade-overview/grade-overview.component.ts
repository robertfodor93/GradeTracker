import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { animate, state, style, transition, trigger } from '@angular/animations';

import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NewGradeComponent } from '../new-grade/new-grade.component';

@Component({
  selector: 'app-grade-overview',
  templateUrl: './grade-overview.component.html',
  styleUrls: ['./grade-overview.component.scss'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})

export class GradeOverviewComponent implements OnInit {

  constructor(public dialog: MatDialog,) { }

  ngOnInit(): void {
  }

  subject: string | undefined;
  datum: Date | undefined;
  bez:string | undefined;
  gewichtung:number | undefined;
  note:number | undefined;

  openDialog(): void {
    const dialogRef = this.dialog.open(NewGradeComponent, {
      width: '40%' ,height:'87%',
      data: {subject: this.subject,datum:this.datum, bez: this.bez, gewictung: this.gewichtung,note:this.note },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.bez = result;
    });
  }

  panelOpenState = false;
 
  dataSourceEFZ = SUBJECT_DATA_EFZ;
  dataSourceBM = SUBJECT_DATA_BM;
  displayedColumnsSubject = ['subject',  'fachtyp','kompetenzbereich','teacher','durchschnitt','anzahlNoten']


  dataSourceEFZexam = EXAM_DATA_EFZ;
  dataSourceBMexam = EXAM_DATA_BM;
  displayedColumnsExam =['suject','datum','bez','gewichtung','note'];
  expandedElements: Subject | null | undefined;

  toggleRow(element:{expanded:boolean;subject:string;}){
    SUBJECT_DATA_EFZ.forEach(row=>{
      row.expanded= false
    })
    element.expanded = !element.expanded
  }
  manageAllRows(flag: boolean) {
    SUBJECT_DATA_EFZ.forEach(row => {
      row.expanded = flag;
    })
  }

}


export interface Subject {
  subject: string;
  fachtyp: string;
  kompetenzbereich: string;
  teacher: string;
  durchschnitt: number;
  anzahlNoten: number;
  favorit: boolean;
  expanded:boolean;
}
export interface Exam{
  subject: string;
  datum: Date;
  bez:string;
  gewichtung:number;
  note:number;
}

const SUBJECT_DATA_EFZ: Subject[] = [
  { subject: 'M117', fachtyp: 'EFZ', kompetenzbereich: 'Informatikkompetenzen', teacher: 'Erik Benz', durchschnitt: 4, anzahlNoten: 3, favorit: false, expanded:false },
  { subject: 'M200', fachtyp: 'EFZ', kompetenzbereich: 'ÜK', teacher: 'Erik Benz', durchschnitt: 3, anzahlNoten: 2, favorit: true, expanded:false },
  { subject: 'M300', fachtyp: 'EFZ', kompetenzbereich: 'Informatikkompetenzen', teacher: 'Erik Benz', durchschnitt: 6, anzahlNoten: 7, favorit: true, expanded:false },
  { subject: 'M400', fachtyp: 'EFZ', kompetenzbereich: 'ÜK', teacher: 'Erik Benz', durchschnitt: 5, anzahlNoten: 1, favorit: false,expanded:false }
];
const EXAM_DATA_EFZ: Exam[]=[
  {subject:'M117', bez:'Theorie', gewichtung: 1, note: 5, datum: new Date(2022, 4, 8) },
  {subject:'M117', bez:'Praktische Arbeit', gewichtung: 1, note: 4, datum: new Date(2022, 6, 18) },
  {subject:'M200', bez:'Theorie', gewichtung: 1, note: 4.5, datum: new Date(2022, 5, 8) }
]
const EXAM_DATA_BM: Exam[]=[
  {subject:'Mathe', bez:'Vektorgeometrie', gewichtung: 1, note: 5.5, datum: new Date(2022, 4, 8) },
  {subject:'Englisch', bez:'FCE', gewichtung: 1, note: 5, datum: new Date(2022, 4, 28) },
  {subject:'Deutsch', bez:'Theorie', gewichtung: 1, note: 4.5, datum: new Date(2022, 4, 18) }
]

const SUBJECT_DATA_BM: Subject[] = [
  { subject: 'Mathe', fachtyp: 'BM', kompetenzbereich: 'Berufsmaturität', teacher: 'Heinz Estermann', durchschnitt: 5, anzahlNoten: 2, favorit: true,expanded:false  },
  { subject: 'Deutsch', fachtyp: 'BM', kompetenzbereich: 'Berufsmaturität', teacher: 'Peter Wicki', durchschnitt: 5, anzahlNoten: 2, favorit: false ,expanded:false},
  { subject: 'Englisch', fachtyp: 'BM', kompetenzbereich: 'Berufsmaturität', teacher: 'Timothy Black', durchschnitt: 4.5, anzahlNoten: 6, favorit: false, expanded:false },
  { subject: 'Wirtschaft', fachtyp: 'BM', kompetenzbereich: 'Berufsmaturität', teacher: 'Patrick Stark', durchschnitt: 5.5, anzahlNoten: 4, favorit: true,expanded:false }
];
