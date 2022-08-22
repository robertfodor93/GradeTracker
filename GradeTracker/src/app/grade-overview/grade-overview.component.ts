import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-grade-overview',
  templateUrl: './grade-overview.component.html',
  styleUrls: ['./grade-overview.component.scss']
})
export class GradeOverviewComponent implements OnInit {

  title="Notenübersicht";

  constructor() { }

  ngOnInit(): void {
  }

}
