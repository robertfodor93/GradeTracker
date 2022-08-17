import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { SubjectModuleOverviewComponent } from './subject-module-overview/subject-module-overview.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GoalOverviewComponent } from './goal-overview/goal-overview.component';
import { GradeOverviewComponent } from './grade-overview/grade-overview.component';

const routes: Routes = [
  
  {path: `subjectoverview`, component: SubjectModuleOverviewComponent},
  {path:`registration`, component:RegistrationComponent},
  {path:`login`, component:LoginComponent},
  {path:`dashboard`, component:DashboardComponent},
  {path:`goaloverview`, component:GoalOverviewComponent},
  {path:`gradeoverview`, component:GradeOverviewComponent},
  {path: '',   redirectTo: '/registration', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
