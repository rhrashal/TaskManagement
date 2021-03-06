import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private datasource: DataService) { }
    
  baseURL : string  = this.datasource.baseUrl;
  AuthBearerToken  = this.datasource.getOptions

  authenticate(username: string, password: string): Observable<boolean> {       
      return this.datasource.authenticate(username, password);
  }
  get authenticated(): boolean {     
      //console.log(atob((this.datasource.auth_token).toString())); 
      //return this.datasource.auth_token != null;
      //console.log(this.datasource.Role,localStorage.getItem('rolename'));        
      return sessionStorage.getItem('rolename') != null;        
  }
  clear() {
      //this.datasource.auth_token = null;
      localStorage.clear();
      sessionStorage.clear();
      location.reload();
  }
}
