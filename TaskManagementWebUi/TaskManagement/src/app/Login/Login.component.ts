import { Component } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../Service/auth.service";
import { ToastrService } from 'ngx-toastr';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

@Component({
  selector: 'login',
  templateUrl: './Login.component.html'
})
export class loginComponent {

  title = 'Login';
  public username: string;
  public password: string;
  public errorMessage: string;
  submit:boolean = false;
  @BlockUI() blockUI : NgBlockUI;

  constructor(private router: Router, private auth: AuthService,private toastr: ToastrService) { }
  
  authenticate(form: NgForm) {
    if (form.valid) {
      this.blockUI.start("loading..");
      this.auth.authenticate(this.username, this.password)
        .subscribe(response => {                    
          if (response) {
            this.router.navigateByUrl("/Home");
            //location.reload();
            this.toastr.success("Successfully Log In");
          }
          this.errorMessage = "Authentication Failed";
          this.blockUI.stop();
        },error =>{
          this.toastr.error(error.message);
          this.blockUI.stop();
        })
    } else {
      this.errorMessage = "Form Data Invalid";
    }
  }
}
