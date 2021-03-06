import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class DataService {
  baseUrl: string;
  auth_token: string;
  Username: string;
  Role: string;

  constructor(private http: HttpClient) {
      // this.baseUrl = `${PROTOCOL}://${location.hostname}:${PORT}/`;
      this.baseUrl = environment.apiUrl;

  }

  authenticate(user: string, pass: string): Observable<boolean> {
      return this.http.post<any>(this.baseUrl + "Account/login", {
          username: user, password: pass
      }).pipe(map(response => {
          this.auth_token = response ? response.token : null;
          var tokenMainPart = this.auth_token.split(".", 3);
          var decodedToken = atob(tokenMainPart[1])
          this.Username = decodedToken.split(",", 6)[0].split(":", 3)[2];
          this.Role = decodedToken.split(",", 6)[2].split(":", 3)[2];
          //localStorage.setItem("username", this.Username);
          localStorage.setItem("token", this.auth_token);
          sessionStorage.setItem("username", this.Username);
          sessionStorage.setItem("rolename", this.Role);
          // console.log(this.Username, this.Role);
          // console.log(this.baseUrl);
          return response;
      }));
  }


  public getOptions() {
      let a = localStorage.getItem('token');
      let token = a;
      // console.log(token);
      return {
          headers: new HttpHeaders({
              'Content-Type': 'application/json',
              'Authorization': 'Bearer ' + token
          })
      }
  }
}
