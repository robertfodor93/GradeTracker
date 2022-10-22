import { EducationTypeGoal } from './../_models/educationTypeGoal';
import { EducationTypeGoalService } from '../_services/education-type-goal.service';
import { User } from './../_models/user';
import { EducationTypeService } from './../_services/education-type.service';
import { EducationType } from './../_models/educationType';
import { Router } from '@angular/router';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators} from '@angular/forms';

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
  registerForm : FormGroup;
  educationTypeGoalForm: FormGroup
  loading = false;
  educationTypes : EducationType[]
  user : User = new User
  educationTypeGoal: EducationTypeGoal = new EducationTypeGoal

  constructor(private authService: AuthService, private router : Router, private formBuilder: FormBuilder, private educationTypeService: EducationTypeService, private educationTypeGoalService: EducationTypeGoalService) {
   }

  ngOnInit() {
      this.registerForm = this.formBuilder.group({
        educationTypeId : [null],
        username: [null, [Validators.required]],
        password: [null, [Validators.required, CustomValidators.passwordContainsNumber!]],
        confirmPassword: [null, [Validators.required]]
      },{
        validators : CustomValidators.passwordMatch
      })
      this.educationTypeService.getAll().subscribe(response =>{
        this.educationTypes = response
      })
  }

  onSubmit(){
    if(this.registerForm.invalid) {
      return;
    }
    this.loading = true;
    this.authService.register(this.registerForm.value).subscribe(response =>{
        this.user = response
        this.educationTypeGoal.userId = this.user.id
        this.educationTypeGoal.educationTypeId = this.registerForm.controls['educationTypeId'].value as number
        
    })
    console.warn(this.educationTypeGoal)
    this.educationTypeGoalService.create(this.educationTypeGoal).subscribe(response => {
      console.warn(response)
    })
  }
}
