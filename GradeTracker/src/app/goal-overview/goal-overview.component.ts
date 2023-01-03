import { Component, OnInit, ViewChild, AfterViewInit, ViewChildren } from '@angular/core';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { GoalService, Goal } from '../services/goal.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NewgoalComponent } from '../newgoal/newgoal.component';

@Component({
  selector: 'app-goal-overview',
  templateUrl: './goal-overview.component.html',
  styleUrls: ['./goal-overview.component.scss']
})

export class GoalOverviewComponent implements AfterViewInit,OnInit {

  title:string='Zielübersicht';

  displayedColumns = ['fach', 'averageDesiredMark', 'needed'];

  fach: string;
  averageDesiredMark:number;
  needed:number;

  openDialog(): void {
    const dialogRef = this.dialog.open(NewgoalComponent, {
      width: '40%' ,height:'70%',
      data: {subject: this.fach, goal: this.averageDesiredMark},
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');;
    });
  }
  protected GOAL_DATA: Goal[] = []
  

  dataSourceGoal = new MatTableDataSource<Goal>(this.GOAL_DATA);
 


  constructor(private _liveAnnouncer: LiveAnnouncer, private service: GoalService,public dialog: MatDialog,) { }

  ngOnInit() {
    this.service.getGoals();
    console.log(this.service.getGoals())
  }

  onChange($event:any){
    const filterValue = $event.value;
    this.dataSourceGoal.filter = filterValue.trim().toLowerCase();
   
  }

  applyFilter(event:Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSourceGoal.filter = filterValue.trim().toLowerCase();

  }

  public getModule() {
    let resp = this.service.getGoals();
    resp.subscribe(report => this.dataSourceGoal.data = report as Goal[])
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
    this.dataSourceGoal.sort = this.sort;
  }

  announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

}