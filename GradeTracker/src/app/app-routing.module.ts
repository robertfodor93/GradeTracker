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
  
  {path: `subjectoverview`, component: SubjectModuleOverviewComponent, data:{title:'Modulübersicht'}, canActivate: [AuthGuard]},
  {path:`registration`, component:RegistrationComponent, data:{title:'Registrieren'}},
  {path:`login`, component:LoginComponent, data:{title:'Login'}},
  {path:`dashboard`, component:DashboardComponent, data:{title:'Dashboard'}, canActivate: [AuthGuard]},
  {path:`goaloverview`, component:GoalOverviewComponent, data:{title:'Zielübersicht'}, canActivate: [AuthGuard]},
  {path:`gradeoverview`, component:GradeOverviewComponent, data:{title:'Notenüberischt'}, canActivate: [AuthGuard]},
  {path:`profile`, component:ProfileComponent, data:{title:'Profil'}, canActivate: [AuthGuard]},
  {path: '',   redirectTo: '/registration', pathMatch: 'full'},



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
