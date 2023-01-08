import { IModule } from './../_models/module';
import { Mark, IMark } from './../_models/mark';
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ModuleService } from '../_services/module.service';
import { Module } from '../_models/module';
import {MatDialog} from '@angular/material/dialog';
import { NewgoalComponent } from '../newgoal/newgoal.component';

@Component({
  selector: 'app-goal-overview',
  templateUrl: './goal-overview.component.html',
  styleUrls: ['./goal-overview.component.scss']
})

export class GoalOverviewComponent implements AfterViewInit,OnInit {

  title:string='Zielübersicht';
  dataArray : Module[]
  marksData : Mark[]
  averageMark : number
  displayedColumns: string[] = ['module', 'averageDesiredMark', 'reached'];
  dataSource = new MatTableDataSource<Module>()
  module: string;
  averageDesiredMark:number;

  openDialog(): void {
    const dialogRef = this.dialog.open(NewgoalComponent, {
      width: '40%' ,height:'70%',
      data: {module: this.module, goal: this.averageDesiredMark},
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');;
    });
  }

  constructor(private _liveAnnouncer: LiveAnnouncer, private moduleService: ModuleService,public dialog: MatDialog,) { }

  ngOnInit() {
    this.moduleService.getAll().subscribe(response => {
      this.dataArray = response
      this.dataArray.forEach(p => {
        this.marksData = p.marks as Mark[]
        let weighedMark = this.marksData.map(p => p.grade!* p.weighting!).reduce((a, b) => a+b)
        let sumOfWeights = this.marksData.map(p => p.weighting).reduce((a,b) => a!+b!)
        let calculationResult = weighedMark! / sumOfWeights!
        p.averageMark = parseFloat(calculationResult.toFixed(2))
      })
      this.dataSource = new MatTableDataSource<Module>(this.dataArray);
      console.warn(this.dataSource.data)
    })
  }

  onChange($event:any){
    const filterValue = $event.value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
   
  }

  applyFilter(event:Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

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