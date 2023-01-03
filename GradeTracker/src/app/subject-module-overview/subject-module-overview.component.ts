import { FormBuilder, FormGroup } from '@angular/forms';
import { CompetenceArea } from './../_models/competenceArea';
import { EducationType } from './../_models/educationType';
import { Mark } from './../_models/mark';
import { Component, OnInit, ViewChild, AfterViewInit, ViewChildren } from '@angular/core';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Module } from '../_models/module';
import { ModuleService } from '../_services/module.service';
import {MatDialog} from '@angular/material/dialog';
import { NewSubjectModuleComponent } from '../new-subject-module/new-subject-module.component';
import { HttpClient } from '@angular/common/http';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';

@Component({
  selector: 'app-subject-module-overview',
  templateUrl: './subject-module-overview.component.html',
  styleUrls: ['./subject-module-overview.component.scss']
})




export class SubjectModuleOverviewComponent implements AfterViewInit, OnInit {

  displayedColumns = ['name', 'educationType' ,'competenceArea', 'teacher', 'averageMark', 'marks', 'showOnDashboard'];

  subject: string | undefined;
  datum: Date | undefined;
  bez:string | undefined;
  gewichtung:number | undefined;
  note:number | undefined;
  posts: any;


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

  title:string = "Fach-/Modulübersicht";
  dataArray : Module[]
  marksData : Mark[]
  dataSource = new MatTableDataSource<Module>()

  constructor(private _liveAnnouncer: LiveAnnouncer, 
    private moduleService : ModuleService, 
    public dialog: MatDialog, 
    private http: HttpClient, ) {
      
    }

  ngOnInit() {
    this.moduleService.getAll().subscribe(response => {
      this.dataArray = response
      this.dataArray.forEach(p => {
        this.marksData = p.marks as Mark[]
        let weighedMark = this.marksData.map(p => p.grade! * p.weighting!).reduce((a,b) => a+b, 0)
        let sumOfWeights = this.marksData.map(p => p.weighting).reduce((a,b) => a!+b!, 0)
        let calculationResult = weighedMark! / sumOfWeights!
        p.averageMark = parseFloat(calculationResult.toFixed(2))
        p.numberOfMarks = this.marksData.length
      })
      this.dataSource = new MatTableDataSource<Module>(this.dataArray)
    })
  }
  
  applyFilter(filterValue:string){
    filterValue = filterValue.trim()
    filterValue = filterValue.toLowerCase()
    this.dataSource.filter = filterValue
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
    this.dataSource.sort = this.sort;
  }

  announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

}