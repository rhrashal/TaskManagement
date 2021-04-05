import { Component, OnInit } from '@angular/core';
import { AuthService } from '../Service/auth.service';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html'
})
export class TaskComponent implements OnInit {

  constructor(private authsarvice : AuthService) { }

  ngOnInit(): void {
  }
  logedOut(){
    this.authsarvice.clear();
  }

}
