import { Component, OnInit } from '@angular/core';
import { EducationtypeService } from '../services/educationtype.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  title = "Registration"

  posts: any;

  constructor(private service: EducationtypeService) { }

  ngOnInit() {
    this.service.getEducationTypes()
      .subscribe(response => {
        this.posts = response;
      });
  }
}
