import { Router } from '@angular/router';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators} from '@angular/forms';
import { map } from 'rxjs/operators';
import { EducationtypeService } from '../_services/educationtype.service';

class CustomValidators {
  static passwordContainsNumber(control: AbstractControl): ValidationErrors {
    const regex = /\d/;

    if(regex.test(control?.value) && control?.value !== null) {
      return null as any;
    } else {
      return {passwordInvalid: true};
    }
  }

  static passwordMatch(control: AbstractControl): ValidationErrors {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value

    if((password === confirmPassword) && (password !== null && confirmPassword !== null)) {
      return null as any
    } else {
      return {passwordsNotMatching: true}
    }
  }
}

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  title = "Registration"
  posts: any;
  registerForm : FormGroup;
  loading = false;

  constructor(private authService: AuthService, private router : Router, private formBuilder: FormBuilder, private educationTypeService: EducationtypeService) {
   }

  ngOnInit() {
    this.educationTypeService.getEducationTypes()
      .subscribe(response => {
        this.posts = response;
      });

      this.registerForm = this.formBuilder.group({
        username: [null, [Validators.required]],
        password: [null, [Validators.required, CustomValidators.passwordContainsNumber!]],
        confirmPassword: [null, [Validators.required]]
      },{
        validators : CustomValidators.passwordMatch
      })
  }

  onSubmit(){
    if(this.registerForm.invalid) {
      return;
    }
    this.loading = true;
    this.authService.register(this.registerForm.value).pipe(
      map(user => this.router.navigate(['registration']))
    ).subscribe()
  }
}
