import { Component, OnInit } from '@angular/core';
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../Service/auth.service";
import { ToastrService } from 'ngx-toastr';
import { BlockUI, NgBlockUI } from 'ng-block-ui';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  @BlockUI() blockUI: NgBlockUI;
  title = 'Login';
  public username: string;
  public password: string;
  public errorMessage: string;
  submit:boolean = false;

  constructor(private router: Router, private auth: AuthService,private toastr: ToastrService) { }
  
  authenticate(form: NgForm) {
    console.log("test")
    if (form.valid) {
      this.blockUI.start('Loading...'); // Start blocking
 
      setTimeout(() => {
        this.blockUI.stop(); // Stop blocking
      },500);
      this.auth.authenticate(this.username, this.password)
        .subscribe(response => {                    
          if (response) {
            this.router.navigateByUrl("/Task/Dashboard");
            //location.reload();
            //alert("Successfully Log In");            
            this.toastr.success('Login Successfull!', 'Toastr fun!');
            this.blockUI.stop();
          }
          this.errorMessage = "Authentication Failed";

        },error =>{
          this.toastr.warning('Incorrect username or password!', 'Toastr fun!');
          this.blockUI.stop();
        })
    } else {
      this.errorMessage = "Form Data Invalid";
    }
  }

  ngOnInit(): void {
  }

}
