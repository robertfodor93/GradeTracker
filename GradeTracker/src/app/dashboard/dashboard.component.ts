import { AuthService } from './../_services/auth.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent  {

title: string ="Dashboard"
  
 @Output() titleEvent = new EventEmitter<string>();

  constructor(private authService : AuthService) { }

  sendTitle() {
    this.titleEvent.emit(this.title)
  }



  ngOnInit() {
    this.authService.getCurrentUser().subscribe((user) => {
      console.warn(user)
    })
  }

}