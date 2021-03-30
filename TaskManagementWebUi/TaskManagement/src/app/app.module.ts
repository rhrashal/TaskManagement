import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import {  HttpClientModule } from '@angular/common/http';


import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';  

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { routing } from "./app.routing";
import { loginComponent } from './Login/Login.component';
import { NotFoundComponent } from './Login/NotFound.component';
import { HomeComponent } from './Home/Home.Component';
import { AuthService } from './Service/auth.service';
import { AuthGuard } from './Service/auth.guard';
import { RestDataSource } from './Service/data.Service';
import { ProjectComponent } from './Home/project/project.component';
import { SprintComponent } from './Home/sprint/sprint.component';

@NgModule({
  declarations: [
    AppComponent,loginComponent,NotFoundComponent,HomeComponent, ProjectComponent, SprintComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,RouterModule, FormsModule, BrowserAnimationsModule,
     ReactiveFormsModule,BsDatepickerModule.forRoot(),ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
     routing
  ],
  providers: [ AuthService, AuthGuard,RestDataSource],
  bootstrap: [AppComponent]
})
export class AppModule { }
