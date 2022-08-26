import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { SubjectModuleOverviewComponent } from './subject-module-overview/subject-module-overview.component';
import { RegistrationComponent } from './registration/registration.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GoalOverviewComponent } from './goal-overview/goal-overview.component';
import { GradeOverviewComponent } from './grade-overview/grade-overview.component';
import { ProfileComponent } from './profile/profile.component';

const routes: Routes = [
  
  {path: `subjectoverview`, component: SubjectModuleOverviewComponent},
  {path:`registration`, component:RegistrationComponent, data:{title:'Registrieren'}},
  {path:`login`, component:LoginComponent, data:{title:'Login'}},
  {path:`dashboard`, component:DashboardComponent, data:{title:'Dashboard'}},
  {path:`goaloverview`, component:GoalOverviewComponent, data:{title:'Zielübersicht'}},
  {path:`gradeoverview`, component:GradeOverviewComponent, data:{title:'Notenüberischt'}},
  {path:`profile`, component:ProfileComponent, data:{title:'Profil'}},
  {path: '',   redirectTo: '/registration', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
