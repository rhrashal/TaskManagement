import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RestDataSource } from 'src/app/Service/data.Service';
import { Project } from 'src/app/Service/Model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html'
  // ,
  // styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  projectList: Project[] = []

  constructor(private http : HttpClient, private rest : RestDataSource) { }

  ngOnInit() {
    this.getProjectList();
  }

  getProjectList(){
    this.http.get<any>(environment.apiUrl+'TaskManagement/GetAllProject', this.rest.getOptions())
    .subscribe(res=>{
      this.projectList =[];
      this.projectList.push( res);
      console.log(this.projectList);
    });
  }
 



}
