import { Component, OnInit, ViewChild, AfterViewInit, ViewChildren } from '@angular/core';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { GoalService, Goal } from '../services/goal.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NewSubjectModuleComponent } from '../new-subject-module/new-subject-module.component';

@Component({
  selector: 'app-goal-overview',
  templateUrl: './goal-overview.component.html',
  styleUrls: ['./goal-overview.component.scss']
})

export class GoalOverviewComponent implements AfterViewInit,OnInit {

  title:string='Zielübersicht';

  displayedColumns = ['name', 'teacher', 'goal', 'needed'];

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
  protected GOAL_DATA: Goal[] = []
  

  dataSourceGoal = new MatTableDataSource<Goal>(this.GOAL_DATA);
 


  constructor(private _liveAnnouncer: LiveAnnouncer, private service: GoalService,public dialog: MatDialog,) { }

  ngOnInit() {
    this.service.getGoals();
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