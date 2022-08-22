import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-goal-overview',
  templateUrl: './goal-overview.component.html',
  styleUrls: ['./goal-overview.component.scss']
})
export class GoalOverviewComponent implements OnInit {

  title="Zielüberischt";

  constructor() { }

  ngOnInit(): void {
  }

}
