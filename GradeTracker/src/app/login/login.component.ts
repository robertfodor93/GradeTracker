import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  title="Login";
  loginForm: FormGroup;

  constructor(private authService: AuthService, private router: Router, private formBuilder: FormBuilder) {
    this.loginForm = this.formBuilder.group({
      username: [null, [Validators.required]],
      password: [null, [Validators.required]],
    })
   }

  ngOnInit(): void {
  }

  onSubmit() {
    if(this.loginForm.invalid) {
      return;
    }
    this.authService.login(this.loginForm.value).pipe(
      map(token => this.router.navigate(['dashboard']))
    ).subscribe()
  }
}
