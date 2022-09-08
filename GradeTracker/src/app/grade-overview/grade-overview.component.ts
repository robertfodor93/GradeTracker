import { Component, OnInit, ViewChild } from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NewGradeComponent } from '../new-grade/new-grade.component';
import { ModuleService, Subject } from '../services/module.service';
import { Exam, GradeService } from '../services/grade.service';
import { MatTableDataSource } from '@angular/material/table';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';

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

title: string='Notenübersicht';
  posts: any;

  constructor(private _liveAnnouncer: LiveAnnouncer, private Modulservice: ModuleService,private Gradeservice: GradeService,public dialog: MatDialog,) { }

 //Daten von der Datenbank holen
  displayedColumnsSubject = ['name', 'competenceArea', 'teacher', 'averageDesiredMark', 'marks', 'showOnDashboard','id']
  displayedColumnsExam =['date','weighting','grade','moduleId'];
  expandedElements: Subject | null | undefined;

  ngOnInit() {
    this.getModule();
    this.getGrade();
    console.log(this.title);
    this.Modulservice.getModule()
    .subscribe(response => {
      this.posts = response;
    });
  }

  subject: string | undefined;
  datum: Date | undefined;
  bez:string | undefined;
  gewichtung:number | undefined;
  note:number | undefined;



 
  panelOpenState = false;
  protected SUBJECT_DATA_EFZ: Subject[] = [];
  protected SUBJECT_DATA_BM: Subject[] = [];
  protected EXAM_DATA_EFZ: Exam[] = [];
  protected EXAM_DATA_BM: Exam[] = [];

  dataSourceEFZ = new MatTableDataSource<Subject>(this.SUBJECT_DATA_EFZ);
  dataSourceBM = new MatTableDataSource<Subject>(this.SUBJECT_DATA_BM);
  // datasourceEFZExam = EXAM_DATA_EFZ;
  // datasourceBMExam = EXAM_DATA_BM;
  dataSourceEFZexam = new MatTableDataSource<Exam>(this.EXAM_DATA_EFZ);
  dataSourceBMexam = new MatTableDataSource<Exam>(this.EXAM_DATA_BM);

  onChange($event:any){
    const filterValue = $event.value;
    this.dataSourceBM.filter = filterValue.trim().toLowerCase();
    this.dataSourceEFZ.filter = filterValue.trim().toLowerCase();
  }
  

  public getModule() {
    let resp = this.Modulservice.getModule();
    resp.subscribe(report => this.dataSourceEFZ.data = report as Subject[])
    resp.subscribe(report => this.dataSourceBM.data = report as Subject[])
  }
  
  public getGrade() {
    let resp = this.Gradeservice.getGrade();
    resp.subscribe(report => this.dataSourceEFZexam.data = report as Exam[])
    resp.subscribe(report => this.dataSourceBMexam.data = report as Exam[])
    console.log(this.dataSourceEFZexam)
  }
  
  //Neue Noten erfassen
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


  //sortieren
  @ViewChild(MatSort) sort = new MatSort();

  ngAfterViewInit() {
    this.dataSourceBM.sort = this.sort;
    this.dataSourceEFZ.sort = this.sort;
    this.dataSourceBMexam.sort = this.sort;
    this.dataSourceEFZexam.sort = this.sort;
  }

  announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  applyFilter(event: Event) {
    console.log((event.target as HTMLInputElement).value);
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSourceBM.filter = filterValue.trim().toLowerCase();
    this.dataSourceEFZ.filter = filterValue.trim().toLowerCase();
  }

}


// export interface Exam{
//   subject: string;
//   datum: Date;
//   bez:string;
//   gewichtung:number;
//   note:number;
// }


// const EXAM_DATA_EFZ: Exam[]=[
//   {subject:'INF 226B', bez:'Theorie', gewichtung: 1, note: 5, datum: new Date(2022, 4, 8) },
//   {subject:'M117', bez:'Praktische Arbeit', gewichtung: 1, note: 4, datum: new Date(2022, 6, 18) },
//   {subject:'M200', bez:'Theorie', gewichtung: 1, note: 4.5, datum: new Date(2022, 5, 8) }
// ]
// const EXAM_DATA_BM: Exam[]=[
//   {subject:'Mathematik', bez:'Vektorgeometrie', gewichtung: 1, note: 5.5, datum: new Date(2022, 4, 8) },
//   {subject:'Englisch', bez:'FCE', gewichtung: 1, note: 5, datum: new Date(2022, 4, 28) },
//   {subject:'Deutsch', bez:'Theorie', gewichtung: 1, note: 4.5, datum: new Date(2022, 4, 18) }
// ]

