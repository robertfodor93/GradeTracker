import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './_guards/auth.guard';

import { SubjectModuleOverviewComponent } from './subject-module-overview/subject-module-overview.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GoalOverviewComponent } from './goal-overview/goal-overview.component';
import { GradeOverviewComponent } from './grade-overview/grade-overview.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
  
  {path: '',   redirectTo: '/login', pathMatch: 'full' },
  {path:`login`, component:LoginComponent},
  {path:`registration`, component:RegistrationComponent},
  {path:`subjectoverview`, component: SubjectModuleOverviewComponent, canActivate: [AuthGuard]},
  {path:`dashboard`, component:DashboardComponent, canActivate: [AuthGuard]},
  {path:`goaloverview`, component:GoalOverviewComponent, canActivate: [AuthGuard]},
  {path:`gradeoverview`, component:GradeOverviewComponent, canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
