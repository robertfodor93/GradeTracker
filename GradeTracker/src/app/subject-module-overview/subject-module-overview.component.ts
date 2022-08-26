import { Component, OnInit, ViewChild, AfterViewInit, ViewChildren } from '@angular/core';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ModuleService, Subject } from '../services/module.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NewSubjectModuleComponent } from '../new-subject-module/new-subject-module.component';
@Component({
  selector: 'app-subject-module-overview',
  templateUrl: './subject-module-overview.component.html',
  styleUrls: ['./subject-module-overview.component.scss']
})




export class SubjectModuleOverviewComponent implements AfterViewInit, OnInit {

  displayedColumns = ['name', 'competenceArea', 'teacher', 'averageDesiredMark', 'marks', 'showOnDashboard'];

  subject: string | undefined;
  datum: Date | undefined;
  bez:string | undefined;
  gewichtung:number | undefined;
  note:number | undefined;

  openDialog(): void {
    const dialogRef = this.dialog.open(NewSubjectModuleComponent, {
      width: '40%' ,height:'70%',
      data: {subject: this.subject,datum:this.datum, bez: this.bez, gewictung: this.gewichtung,note:this.note },
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.bez = result;
    });
  }
  protected SUBJECT_DATA_EFZ: Subject[] = []
  protected SUBJECT_DATA_BM: Subject[] = []

  dataSourceEFZ = new MatTableDataSource<Subject>(this.SUBJECT_DATA_EFZ);
  dataSourceBM = new MatTableDataSource<Subject>(this.SUBJECT_DATA_BM);

  title = "Fach-/Modulübersicht";


  constructor(private _liveAnnouncer: LiveAnnouncer, private service: ModuleService,public dialog: MatDialog,) { }

  ngOnInit() {
    this.getModule();
  }

  public getModule() {
    let resp = this.service.getModule();
    resp.subscribe(report => this.dataSourceEFZ.data = report as Subject[])
    resp.subscribe(report => this.dataSourceBM.data = report as Subject[])
  }

  public openForm() {
    let form = document.getElementById('myForm')
    if(form) (form as HTMLFormElement).style.display="block"; 
}

public closeForm() {
  let form = document.getElementById('myForm')
  if(form) (form as HTMLFormElement).style.display="none";
}




  @ViewChild(MatSort) sort = new MatSort();

  ngAfterViewInit() {
    this.dataSourceBM.sort = this.sort;
    this.dataSourceEFZ.sort = this.sort;
  }

  announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

}





