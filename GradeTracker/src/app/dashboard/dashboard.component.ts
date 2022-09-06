import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent  {

title: string ="Dashboard"
  
 @Output() titleEvent = new EventEmitter<string>();

  constructor() { }

  sendTitle() {
    this.titleEvent.emit(this.title)
  }



}