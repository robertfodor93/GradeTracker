import { Observable } from 'rxjs';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  authenticated$: Observable<boolean> | undefined;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  checkAuthentication() {
    this.authenticated$ = this.authService.checkAuthentication;
    return this.authenticated$;
  }
  logout() {
    this.authService.logout();
  }
}
