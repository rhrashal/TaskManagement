import { Component } from "@angular/core";
import { AuthService } from "../Service/auth.service";


@Component({
  selector: 'Home',
  templateUrl: './Home.component.html'
})
export class HomeComponent {
 

  constructor(private authsarvice : AuthService){}



  logedOut(){
    this.authsarvice.clear();
  }

}