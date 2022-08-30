import { Router } from '@angular/router';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators} from '@angular/forms';
import { map } from 'rxjs/operators';
import { EducationtypeService } from '../services/educationtype.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  title = "Registration"
  posts: any;
  registerForm : FormGroup;

  constructor(private authService: AuthService, private router : Router, private formBuilder: FormBuilder, private educationTypeService: EducationtypeService) {
    this.registerForm = this.formBuilder.group({
      username: [null, [Validators.required]],
      password: [null, [Validators.required]],
    })
   }

  ngOnInit() {
    this.service.getEducationTypes()
      .subscribe(response => {
        this.posts = response;
      });
  }

  onSubmit(){
    if(this.registerForm.invalid) {
      return;
    }
    console.log(this.registerForm.value);
    this.authService.register(this.registerForm.value).pipe(
      map(user => this.router.navigate(['registration']))
    ).subscribe()
  }
}
