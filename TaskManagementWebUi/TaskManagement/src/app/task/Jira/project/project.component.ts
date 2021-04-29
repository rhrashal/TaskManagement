import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataService } from 'src/app/Service/data.service';
import { Project } from 'src/app/Service/model';

import Swal from 'sweetalert2/dist/sweetalert2.js';
import { FilterDataPipe } from 'src/app/service/filter-data.pipe';
import { ToastrService } from 'ngx-toastr';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { LoadingBarService } from '@ngx-loading-bar/core';

declare var $:any;


@Component({
  selector: 'app-project',
  templateUrl: './project.component.html'
})
export class ProjectComponent implements OnInit {
  @BlockUI() blockUI: NgBlockUI;
  loader = this.loadingBar.useRef();

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

  page = 1;
  count = 0;
  tableSize = 7;
  tableSizes = [3, 6, 9, 12];

  constructor(private http : HttpClient, private rest : DataService,
              private formBuilder: FormBuilder,
              private toastr: ToastrService,
              private loadingBar: LoadingBarService,              
              ) {

    this.minDate = new Date();
   }
//
  ngOnInit() {
    this.loader.start()
    this.getProjectList();    
    this.registerForm = this.formBuilder.group({
      ProjectName: ['', Validators.required],
      ExpireDate: ['', Validators.required],
      IsSupport: ['', Validators.required]
    });
  this.loader.complete();
  }

  onTableDataChange(event){
    this.page = event;
    this.getProjectList();    
  }  

  onTableSizeChange(event): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.getProjectList();    
  }  

 // convenience getter for easy access to form fields
    get f() { return this.registerForm.controls; }

    filterText:string=""; 
    filterPipe = new FilterDataPipe();
    fiteredArr :any=[];
    filterFunction(){
       this.fiteredArr = this.filterPipe.transform(this.projectList,this.filterText); //https://stackoverflow.com/questions/39653630/how-to-use-pipe-in-ts-not-html/50693592
    }

  getProjectList(){
    this.http.get<any>(environment.apiUrl+'TaskManagement/GetAllProject', this.rest.getOptions())
    .subscribe(res=>{
      this.projectList =[];
      this.projectList = res.results;
      console.log(this.projectList);    
      this.filterFunction();
      //this.toastr.success(this.projectList.length + " Data found", "Status")
    });
  }
  //this.paging.
  pageOfItems: Array<any>;
  onChangePage(pageOfItems: Array<Project>) {
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
              this.toastr.success("Successfully updated", "Status")  
          });
        }else{
          this.http.post<any>(environment.apiUrl+'TaskManagement/AddProject',this.registerForm.value, this.rest.getOptions())
          .subscribe(res=>{
            console.log(res); 
            this.getProjectList();   
            $('.modal').modal('hide');  
            this.toastr.success("Save successfull.", "Status")         
          });    
        }
        
        //alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value))
    }

    editClick(data){
      this.loader.start()
      this.blockUI.start(); // Start blocking
 
      // setTimeout(() => {
      //   this.blockUI.stop();// Stop blocking
      // },200);
      //console.log(data);
      this.project.Id = data.id;
      this.project.ProjectName= data.projectName;
      this.project.ExpireDate = new Date( data.expireDate);
      this.project.IsSupport=data.isSupport;
      console.log(this.project);
      this.blockUI.stop();
      this.loader.complete();

     // this.registerForm.value.ProjectName = data.projectName;
    }

    // deleteProject(id){
    //   if(confirm('Are you sure??')){
    //     if(id > 0){
    //       this.http.delete<any>(environment.apiUrl+'TaskManagement/deleteProject/'+ id, this.rest.getOptions())
    //         .subscribe(res=>{
    //           console.log(res); 
    //           this.getProjectList();
    //         }); 
    //     }
    //   }
      
    // }

  deleteProject(id){
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this imaginary file!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        this.blockUI.start();
        if(id > 0){
          this.http.delete<any>(environment.apiUrl+'TaskManagement/deleteProject/'+ id, this.rest.getOptions())
            .subscribe(res=>{
              console.log(res); 
              this.getProjectList(); 
              Swal.fire(
                'Deleted!',
                'Your imaginary file has been deleted.',
                'success'
              )
              this.blockUI.stop();
            },error=>{
              Swal.fire(
                'Your imaginary file is safe :'+ error.message +')',
              )
              this.blockUI.stop();
            }); 
        }
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelled',
          'Your imaginary file is safe :)',
          'error'
        )
      }
    })
    
  }


    resetFrom(){
      this.project = {};
    }
}
