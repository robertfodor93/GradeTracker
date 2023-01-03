import { Component, OnInit, ViewChild, ViewChildren, QueryList, ChangeDetectorRef} from '@angular/core';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { MatDialog} from '@angular/material/dialog';
import { NewGradeComponent } from '../new-grade/new-grade.component';
import { ModuleService } from '../_services/module.service';
import { MatTableDataSource, MatTable } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { Module } from '../_models/module';
import { Mark } from '../_models/mark';

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

  dataSource = new MatTableDataSource<Module>()
  dataArray : Module [] = []
  modulesData : Module[] = []
  columnsToDisplay = ['name', 'competenceArea', 'teacher']
  innerDisplayedColumns = ['description','grade', 'weighting']
  expandedElement: Module | null;

  @ViewChild('outerSort', { static: true }) sort: MatSort;
  @ViewChildren('innerSort') innerSort: QueryList<MatSort>;
  @ViewChildren('innerTables') innerTables: QueryList<MatTable<Mark>>;

  constructor(
    private modulService: ModuleService,
    public matDialog: MatDialog, 
    private changeDetectorRef: ChangeDetectorRef) {
    }

  ngOnInit() {
    this.modulService.getAll().subscribe(response =>{
      this.dataArray = response
      this.dataArray.forEach(module => {
        if(module.marks && Array.isArray(module.marks) && module.marks.length) {
          this.modulesData = [...this.modulesData, {...module, marks: new MatTableDataSource(module.marks)}]
        } else {
          this.modulesData = [...this.modulesData, module];
        }
      });
      this.dataSource = new MatTableDataSource<Module>(this.modulesData);
      this.dataSource.sort = this.sort
      console.warn(this.dataSource.data)
    })
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
  applyFilter(event: Event) {
  
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSourceBM.filter = filterValue.trim().toLowerCase();
    this.dataSourceEFZ.filter = filterValue.trim().toLowerCase();
    console.log(this.dataSourceEFZ.filter = filterValue.trim().toLowerCase());
  }
  // filterExam($event:Event){
  //   const subject = document.getElementById("subject")?.innerHTML;
  //   console.log(subject);
  //   this.dataSourceEFZ.filter = subject.trim().toLowerCase();
  // }

    filterExam(){
   const filter = 2;
   this.dataSourceEFZexam.filter = filter.toString();
    console.log(this.dataSourceEFZexam.filter = filter.toString().trim());
  //funktioniert noch nicht 
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
    const dialogRef = this.matDialog.open(NewGradeComponent, {
      width: '40%' ,height:'87%', 
      data: {subject: this.subject,datum:this.datum, bez: this.bez, gewictung: this.gewichtung,note:this.note },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.bez = result;
    });
  }


  toggleRow(element: Module) {
    element.marks && (element.marks as MatTableDataSource<Mark>).data?.length?(this.expandedElement = this.expandedElement === element ? null : element) : null;
    this.changeDetectorRef.detectChanges();
    this.innerTables.forEach((table, index) => (table.dataSource as MatTableDataSource<Mark>).sort = this.innerSort.toArray()[index]);
  }
  

}