import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TaskComponent } from './task/task.component';
import { EmpCategoryComponent } from './task/Employee/emp-category/emp-category.component';
import { ProjectComponent } from './task/Jira/project/project.component';
import { SprintComponent } from './task/Jira/sprint/sprint.component';
import { FilterDataPipe } from './service/filter-data.pipe';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './login/not-found/not-found.component';
import { AuthGuard } from './Service/auth.guard';
import { AuthService } from './Service/auth.service';
import { DataService } from './Service/data.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from './task/dashboard/dashboard.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';  //https://valor-software.com/ngx-bootstrap/#/datepicker
import { ToastrModule } from 'ngx-toastr';                      //https://www.npmjs.com/package/ngx-toastr
                                                                //Sweet alert => https://www.itsolutionstuff.com/post/how-to-use-sweetalert2-in-angularexample.html
import { BlockUIModule } from 'ng-block-ui';                    //https://www.npmjs.com/package/ng-block-ui
//import { JwPaginationModule } from 'jw-angular-pagination';     //https://jasonwatmore.com/post/2018/04/26/npm-jw-angular-pagination-component
import { LoadingBarModule } from '@ngx-loading-bar/core';       //https://github.com/aitboudad/ngx-loading-bar
import { DepartmentComponent } from './task/Employee/department/department.component';
import { DesignationComponent } from './task/Employee/designation/designation.component';

import { NgxPaginationModule } from 'ngx-pagination'; //https://www.positronx.io/angular-server-side-pagination-with-ngx-pagination-example/

@NgModule({
  declarations: [
    AppComponent,    TaskComponent,    ProjectComponent,    SprintComponent,    FilterDataPipe,
    LoginComponent,    NotFoundComponent,    DashboardComponent, EmpCategoryComponent, DepartmentComponent, DesignationComponent
  ],
  imports: [
    BrowserModule,    AppRoutingModule, HttpClientModule,FormsModule,ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    ToastrModule.forRoot(),
    BlockUIModule.forRoot(),    
    LoadingBarModule,
    NgxPaginationModule
  ],
  providers: [AuthGuard,AuthService,DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
