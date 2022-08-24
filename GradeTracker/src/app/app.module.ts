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
import { MatDividerModule } from '@angular/material/divider';

import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatRow } from '@angular/material/table';
import { MatHeaderRow } from '@angular/material/table';
import { MatCell } from '@angular/material/table';
import { MatHeaderCell } from '@angular/material/table';
import { ProfileComponent } from './profile/profile.component';
import { MatToolbarModule } from '@angular/material/toolbar';

import { Title } from '@angular/platform-browser';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MatSortModule } from '@angular/material/sort';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    DashboardComponent,
    GoalOverviewComponent,
    GradeOverviewComponent,
    SubjectModuleOverviewComponent,
    SidenavComponent,
    ProfileComponent,


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,

    MatFormFieldModule,
    MatCardModule,
    MatIconModule,

    MatDividerModule,


    MatInputModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,

    MatOptionModule,
    MatSelectModule,

    HttpClientModule,

    MatSortModule,




  ],
  providers: [HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
