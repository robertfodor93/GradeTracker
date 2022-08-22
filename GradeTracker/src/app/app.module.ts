import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GoalOverviewComponent } from './goal-overview/goal-overview.component';
import { GradeOverviewComponent } from './grade-overview/grade-overview.component';
import { SubjectModuleOverviewComponent } from './subject-module-overview/subject-module-overview.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SidenavComponent } from './sidenav/sidenav.component';

import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table'
import { MatTabsModule } from '@angular/material/tabs'





@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    DashboardComponent,
    GoalOverviewComponent,
    GradeOverviewComponent,
    SubjectModuleOverviewComponent,
    SidenavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,

    MatFormFieldModule,
    MatCardModule,
    MatIconModule,
    MatInputModule,
    MatTableModule,
    MatTabsModule



  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
