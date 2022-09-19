import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Subject } from '../services/module.service';
import { ModuleService } from '../services/module.service';
import { Goal, GoalService } from '../services/goal.service';

@Component({
  selector: 'app-newgoal',
  templateUrl: './newgoal.component.html',
  styleUrls: ['./newgoal.component.scss']
})



export class NewgoalComponent implements OnInit {
  newGoal: FormGroup;
  posts: any;


  constructor(
    public dialogRef: MatDialogRef<NewgoalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Goal,
    private http: HttpClient,
    private service: ModuleService, private serviceGoal: GoalService) {
  }

  onClick() {
    this.postGrade(this.data);
    console.log(this.data);
    this.dialogRef.close();
  }

postGrade(data : Goal){
    const headers = { 'content-type': 'application/json'} 
    const averageDesiredMark = data.averageDesiredMark;
    const fach = JSON.stringify(data.fach);
    console.log(averageDesiredMark);
    console.log(fach);
    console.log('https://localhost:7290/api/Module/update?id=' + fach)
    this.http.put('https://localhost:7290/api/Module/update?id=' + fach, averageDesiredMark, {'headers':headers}).subscribe((result)=>{
      console.warn("result", result);
      
    });
  }


  ngOnInit() {
    this.service.getModule()
      .subscribe(response => {
        this.posts = response;
      });
    console.log(this.posts)
  }


  onNoClick(): void {
    this.dialogRef.close();
  }

}
