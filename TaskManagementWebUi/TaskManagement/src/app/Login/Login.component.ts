import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../Service/auth.service";

@Component({
  selector: 'login',
  templateUrl: './Login.component.html'
})
export class loginComponent {

  title = 'Login';
  public username: string;
  public password: string;
  public errorMessage: string;

  constructor(private router: Router, private auth: AuthService) { }
  
  authenticate(form: NgForm) {
    if (form.valid) {
      this.auth.authenticate(this.username, this.password)
        .subscribe(response => {                    
          if (response) {
            this.router.navigateByUrl("/Home");
            //location.reload();
          }
          this.errorMessage = "Authentication Failed";
        })
    } else {
      this.errorMessage = "Form Data Invalid";
    }
  }
}
