import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RestDataSource } from 'src/app/Service/data.Service';
import { Project } from 'src/app/Service/Model';
import { environment } from 'src/environments/environment';
import { toArray, take } from 'rxjs/operators';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
declare var $:any;

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html'
  // ,
  // styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {
  registerForm: FormGroup;
  submitted = false;
  projectList:any = []
  project : Project = {
    Id : 0,
    ProjectName: "",
    ExpireDate: null,
    IsSupport:false
  };
  minDate: Date;
  pageOfItems: Array<any>;
  constructor(private http : HttpClient, private rest : RestDataSource,private formBuilder: FormBuilder) {
    this.minDate = new Date();
   }

  ngOnInit() {
    this.getProjectList();

    this.registerForm = this.formBuilder.group({
      ProjectName: ['', Validators.required],
      ExpireDate: ['', Validators.required],
      IsSupport: ['', Validators.required]
  });
  }
 // convenience getter for easy access to form fields
    get f() { return this.registerForm.controls; }


  getProjectList(){
    this.http.get<any>(environment.apiUrl+'TaskManagement/GetAllProject', this.rest.getOptions())
    .subscribe(res=>{
      this.projectList =[];
      this.projectList = res.results;
      console.log(this.projectList);    

    });
  }
 
  onChangePage(pageOfItems: Array<Project>) {
    // update current page of items
    this.pageOfItems = pageOfItems;
}

onSubmit() {
        this.submitted = true;
        // stop here if form is invalid
        if (this.registerForm.invalid) {
            return;
        }
        console.log(this.registerForm.value);
        if(this.project.Id>0){
          console.log(this.project);
          this.http.put<any>(environment.apiUrl+'TaskManagement/UpdateProject/'+ this.project.Id,this.registerForm.value, this.rest.getOptions())
          .subscribe(res=>{
            console.log(res); 
            this.getProjectList();               
              $('.modal').modal('hide');       
          });
        }else{
          this.http.post<any>(environment.apiUrl+'TaskManagement/AddProject',this.registerForm.value, this.rest.getOptions())
          .subscribe(res=>{
            console.log(res); 
            this.getProjectList();   
            $('.modal').modal('hide');           
          });    
        }
        
        //alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value))
    }

    editClick(data){
      //console.log(data);
      this.project.Id = data.id;
      this.project.ProjectName= data.projectName;
      this.project.ExpireDate = new Date( data.expireDate);
      this.project.IsSupport=data.isSupport;
      console.log(this.project);
     // this.registerForm.value.ProjectName = data.projectName;
    }

    deleteProject(id){
      if(confirm('Are you sure??')){
        if(id > 0){
          this.http.delete<any>(environment.apiUrl+'TaskManagement/deleteProject/'+ id, this.rest.getOptions())
            .subscribe(res=>{
              console.log(res); 
              this.getProjectList();
            }); 
        }
      }
      
    }

    resetFrom(){
      this.project = {};
    }

}
