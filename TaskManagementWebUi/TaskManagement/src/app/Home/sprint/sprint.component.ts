import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RestDataSource } from 'src/app/Service/data.Service';
import { Sprint } from 'src/app/Service/Model';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
declare var $:any;

@Component({
  selector: 'app-sprint',
  templateUrl: './sprint.component.html'
})
export class SprintComponent implements OnInit {

  submitted:boolean = false;
  SprintList:any = []
  Sprint : Sprint = {
    Id : 0,
    ProjectId: 0,
    SprintTitle: null,
    StartDate:null,
    EndDate:null,
    IsSupport:false,
    IsStart:false,
    Completed:false,
    SprintStartDate:null,
    SprintEndDate: null
  };
  projectList:any = []
  minDate:Date = new Date;
  minDateEnd:Date = new Date;

  constructor(private http : HttpClient, private rest : RestDataSource,private toastr: ToastrService) { 

    this.Sprint = new Sprint()
  }

  ngOnInit() {
    this.getProjectList();
    this.getSprintList();
  }

dateChange(){
  this.minDateEnd = new Date(this.Sprint.StartDate);
  console.log(this.minDateEnd);
}

  getSprintList(){
    this.http.get<any>(environment.apiUrl+'TaskManagement/GetAllSprint', this.rest.getOptions())
    .subscribe(res=>{
      this.SprintList =[];
      this.SprintList = res.results;
      console.log(this.SprintList);    
      this.toastr.show(this.SprintList.length+ " Data found",'Status!');
    });
  }

  getProjectList(){
    this.http.get<any>(environment.apiUrl+'TaskManagement/GetAllProject', this.rest.getOptions())
    .subscribe(res=>{
      this.projectList =[];
      this.projectList = res.results;
      console.log(this.projectList);    
    });
  }

  onSubmit(form: NgForm) {
    if (form.invalid) {
      console.log(this.Sprint); 
      this.toastr.warning("Fill Requred Field",'Status!');
      return;
    }    
    this.Sprint.ProjectId = Number(this.Sprint.ProjectId)
    console.log(this.Sprint); 
    console.log(this.rest.getOptions());
    if(this.Sprint.Id>0){
      console.log(this.Sprint);
      this.http.put<any>(environment.apiUrl+'TaskManagement/UpdateSprint', this.Sprint, this.rest.getOptions())
      .subscribe(res=>{
        console.log(res); 
        this.getSprintList();               
          $('.modal').modal('hide');       
      },error=>{
        console.log(error); 
      });
    }else{
      this.http.post<any>(environment.apiUrl+'TaskManagement/AddSprint',JSON.stringify(this.Sprint), this.rest.getOptions())
      .subscribe(res=>{
        console.log(res); 
        this.getSprintList();   
        $('.modal').modal('hide');           
      },error=>{
        console.log(error); 
      });    
    }      
}

  resetFrom(){
    this.Sprint = {};
    this.submitted = false;
  }


  editClick(data){
    console.log(data);    
    this.Sprint.Id = data.id;
    this.Sprint.SprintTitle =  data.sprintTitle;
    this.Sprint.ProjectId= data.projectId;
    this.Sprint.SprintStartDate =   new Date(data.startDate).toString();
    this.Sprint.SprintEndDate =  new Date( data.endDate).toString();
    this.Sprint.IsSupport=data.isSupport;
    console.log(this.Sprint);
  }

  deleteProject(id){
    if(confirm('Are you sure??')){
      if(id > 0){
        this.http.delete<any>(environment.apiUrl+'TaskManagement/deleteSprint/'+ id, this.rest.getOptions())
          .subscribe(res=>{
            console.log(res); 
            this.getProjectList();
          }); 
      }
    }
    
  }
}
