import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GoalOverviewComponent } from './goal-overview/goal-overview.component';
import { GradeOverviewComponent } from './grade-overview/grade-overview.component';
import { SubjectModuleOverviewComponent } from './subject-module-overview/subject-module-overview.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SidenavComponent } from './sidenav/sidenav.component';
import { ProfileComponent } from './profile/profile.component';
import { NewGradeComponent } from './new-grade/new-grade.component';
import { NewSubjectModuleComponent } from './new-subject-module/new-subject-module.component';

import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table'
import { MatTabsModule } from '@angular/material/tabs'
import { MatTableDataSource} from '@angular/material/table';
import { MatRow } from '@angular/material/table';
import { MatHeaderRow } from '@angular/material/table';
import { MatCell } from '@angular/material/table';
import { MatHeaderCell } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import {MatDialogModule} from '@angular/material/dialog';

import { Title } from '@angular/platform-browser';

import { JwtHelperService, JWT_OPTIONS } from "@auth0/angular-jwt";
import { JwtInterceptor } from './_interceptors/jwt.interceptor';

import { ModuleService } from './services/module.service';

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
    NewGradeComponent,
    NewSubjectModuleComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
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
    MatSortModule,
    MatDialogModule
  ],
  providers: [ 
    JwtHelperService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    HttpClient,
    Title
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
