import { Component, OnInit,Inject } from '@angular/core';
import { ModuleService} from '../_services/module.service';
import {MatDialogRef} from '@angular/material/dialog';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MarkService } from '../_services/mark.service';


@Component({
  selector: 'app-new-grade',
  templateUrl: './new-grade.component.html',
  styleUrls: ['./new-grade.component.scss']
})
export class NewGradeComponent implements OnInit {

  newMarkForm : FormGroup
  modules : any
  
  constructor(
    public dialogRef: MatDialogRef<NewGradeComponent>,
    private moduleService: ModuleService, private markService: MarkService, private formBuilder : FormBuilder
  ) {
    
  }

  onSubmit() {
    this.markService.createMark(this.newMarkForm.value).subscribe()
    console.warn(this.newMarkForm.value)
  }

  ngOnInit() {
    this.moduleService.getAll()
      .subscribe(response => {
        this.modules = response;
      });
    console.log(this.modules)

    this.newMarkForm = this.formBuilder.group({
      grade: [null],
      description : [null],
      weighting : [null],
      date : [null],
      moduleId : [null]
    })
  }
}
