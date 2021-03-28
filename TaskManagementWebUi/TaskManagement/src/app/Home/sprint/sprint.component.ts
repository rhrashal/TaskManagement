import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RestDataSource } from 'src/app/Service/data.Service';
import { Sprint } from 'src/app/Service/Model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-sprint',
  templateUrl: './sprint.component.html'
})
export class SprintComponent implements OnInit {

  SprintList:any = []
  Sprint : Sprint = {
    Id : 0,
    ProjectId: 0,
    SprintTitle: null,
    StartDate:null,
    EndDate:null,
    IsSupport:false,
  };


  constructor(private http : HttpClient, private rest : RestDataSource) { }

  ngOnInit() {
    this.getProjectList();
  }



  getProjectList(){
    this.http.get<any>(environment.apiUrl+'TaskManagement/GetAllSprint', this.rest.getOptions())
    .subscribe(res=>{
      this.SprintList =[];
      this.SprintList = res.results;
      console.log(this.SprintList);    

    });
  }
  onSubmit() {

    // stop here if form is invalid
    console.log("ggfjg"); 
        return;
 
    // if(this.project.Id>0){
    //   console.log(this.project);
    //   this.http.put<any>(environment.apiUrl+'TaskManagement/UpdateProject/'+ this.project.Id,this.registerForm.value, this.rest.getOptions())
    //   .subscribe(res=>{
    //     console.log(res); 
    //     this.getProjectList();               
    //       $('.modal').modal('hide');       
    //   });
    // }else{
    //   this.http.post<any>(environment.apiUrl+'TaskManagement/AddProject',this.registerForm.value, this.rest.getOptions())
    //   .subscribe(res=>{
    //     console.log(res); 
    //     this.getProjectList();   
    //     $('.modal').modal('hide');           
    //   });    
    // }
    
    //alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value))
}
  resetFrom(){
    this.Sprint = {};
  }
}
