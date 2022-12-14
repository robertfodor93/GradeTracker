import { Component, OnInit, ViewChild, AfterViewInit, ViewChildren } from '@angular/core';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Module } from '../_models/module';
import { ModuleService } from '../_services/module.service';
import {MatDialog} from '@angular/material/dialog';
import { NewSubjectModuleComponent } from '../new-subject-module/new-subject-module.component';
import { FormBuilder, FormGroup } from '@angular/forms';

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
  protected MODULE_DATA: Module[] = []

  dataSourceModule = new MatTableDataSource<Module>(this.MODULE_DATA)

  title:string = "Fach-/Modulübersicht";


  constructor(
    private _liveAnnouncer: LiveAnnouncer, 
    private moduleService: ModuleService,
    public dialog: MatDialog,
    private formBuilder : FormBuilder) { 
    }

  ngOnInit() {
    this.moduleService.getAll().subscribe((response) => {
      this.dataSourceModule.data = response
    })
  }
  onChange($event:any){
    const filterValue = $event.value;
    this.dataSourceModule.filter = filterValue.trim().toLowerCase();
  }

  applyFilter(event:Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSourceModule.filter = filterValue.trim().toLowerCase();
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
    this.dataSourceModule.sort = this.sort;
  }

  announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

}