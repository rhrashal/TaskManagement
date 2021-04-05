import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './login/not-found/not-found.component';
import { AuthGuard } from './Service/auth.guard';
import { DashboardComponent } from './task/dashboard/dashboard.component';
import { EmpCategoryComponent } from './task/Employee/emp-category/emp-category.component';
import { ProjectComponent } from './task/Jira/project/project.component';
import { SprintComponent } from './task/Jira/sprint/sprint.component';
import { TaskComponent } from './task/task.component';

const routes: Routes = [
  { path: "login", component: LoginComponent},
  { path: "Task", component: TaskComponent,  canActivate: [AuthGuard],
      children: [
                      // { path: '', redirectTo: 'Project', pathMatch: 'full' },
                      { path: 'Dashboard', component: DashboardComponent},
                      { path: 'Project', component: ProjectComponent},
                      { path: 'Sprint', component: SprintComponent },
                      { path: 'Category', component: EmpCategoryComponent }
               ]
  },
  { path: "", redirectTo: "Task/Dashboard", pathMatch: "full" },
  { path: "**", component: NotFoundComponent }
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
