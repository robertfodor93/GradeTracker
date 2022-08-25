import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  title= "Profil";
  
  constructor() { }

  ngOnInit(): void {
  }

   isReadOnly: boolean = true;
  update(){
    return this.isReadOnly = !this.isReadOnly;
  }

}
