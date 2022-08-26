import { Component, OnInit } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NewGradeComponent } from '../new-grade/new-grade.component';
import { ModuleService, Subject } from '../services/module.service';
import { MatTableDataSource } from '@angular/material/table';
import { LiveAnnouncer } from '@angular/cdk/a11y';

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

  displayedColumnsSubject = ['subject',  'fachtyp','kompetenzbereich','teacher','durchschnitt','anzahlNoten']
  displayedColumnsExam =['suject','datum','bez','gewichtung','note'];
  expandedElements: Subject | null | undefined;

  constructor(private _liveAnnouncer: LiveAnnouncer, private service: ModuleService,public dialog: MatDialog,) { }

  ngOnInit() {
    this.getModule();
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
  protected SUBJECT_DATA_EFZ: Subject[] = []
  protected SUBJECT_DATA_BM: Subject[] = []

  dataSourceEFZ = new MatTableDataSource<Subject>(this.SUBJECT_DATA_EFZ);
  dataSourceBM = new MatTableDataSource<Subject>(this.SUBJECT_DATA_BM);
  
  dataSourceEFZexam = EXAM_DATA_EFZ;
  dataSourceBMexam = EXAM_DATA_BM;

  public getModule() {
    let resp = this.service.getModule();
    resp.subscribe(report => this.dataSourceEFZ.data = report as Subject[])
    resp.subscribe(report => this.dataSourceBM.data = report as Subject[])
  }
  

  // toggleRow(element:{expanded:boolean;subject:string;}){
  //   SUBJECT_DATA_EFZ.forEach(row=>{
  //     row.expanded= false
  //   })
  //   element.expanded = !element.expanded
  // }
  // manageAllRows(flag: boolean) {
  //   SUBJECT_DATA_EFZ.forEach(row => {
  //     row.expanded = flag;
  //   })
  // }

}

export interface Exam{
  subject: string;
  datum: Date;
  bez:string;
  gewichtung:number;
  note:number;
}


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
