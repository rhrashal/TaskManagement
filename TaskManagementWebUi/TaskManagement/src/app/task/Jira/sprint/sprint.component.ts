import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DataService } from 'src/app/Service/data.service';
import { Sprint } from 'src/app/Service/Model';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { FilterDataPipe } from 'src/app/service/filter-data.pipe';
import { ToastrService } from 'ngx-toastr';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
declare var $:any;

@Component({
  selector: 'app-sprint',
  templateUrl: './sprint.component.html'
})
export class SprintComponent implements OnInit {

  @BlockUI() blockUI : NgBlockUI;

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

  constructor(private http : HttpClient, private rest : DataService,private toastr: ToastrService) { 

    this.Sprint = new Sprint()
  }

  ngOnInit() {
   this.blockUI.start("loading..");
    this.getProjectList();
    this.getSprintList();    
    this.blockUI.stop();
    
  }

  
  filterPipe = new FilterDataPipe();
  filterText:string=""; 
  fiteredArr :any=[];
  filterFunction(){
     this.fiteredArr = this.filterPipe.transform(this.SprintList,this.filterText); 
  }
  pageOfItems: Array<any>;
  onChangePage(pageOfItems: Array<Sprint>) {
    this.pageOfItems = pageOfItems;
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
      this.filterFunction();   
     //this.toastr.success(this.SprintList.length+ " Data found",'Status!');
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
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Fill Requred Field!',
        footer: '<a href>Why do I have this issue?</a>'
      })
      // this.toastr.warning("",'Status!');
      return;
    }    
    this.Sprint.ProjectId = Number(this.Sprint.ProjectId)
   // console.log(this.Sprint); 
    //console.log(this.rest.getOptions());
    this.blockUI.start('Loading...');
    if(this.Sprint.Id>0){
      console.log(this.Sprint);
      this.http.put<any>(environment.apiUrl+'TaskManagement/UpdateSprint', this.Sprint, this.rest.getOptions())
      .subscribe(res=>{
        console.log(res); 
        this.getSprintList();               
          $('.modal').modal('hide'); 
          this.blockUI.stop();    
          this.toastr.success("Successfully updated", "Status")    
      },error=>{
        console.log(error); 
       this.blockUI.stop();      
      });
    }else{
      this.http.post<any>(environment.apiUrl+'TaskManagement/AddSprint',JSON.stringify(this.Sprint), this.rest.getOptions())
      .subscribe(res=>{
        console.log(res); 
        this.getSprintList();   
        $('.modal').modal('hide'); 
        this.toastr.success("Save successfull.", "Status")   
        this.blockUI.stop();              
      },error=>{
        console.log(error); 
        this.blockUI.stop();      
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
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this imaginary file!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {

        if(id > 0){
          this.http.delete<any>(environment.apiUrl+'TaskManagement/deleteSprint/'+ id, this.rest.getOptions())
            .subscribe(res=>{
              console.log(res); 
              this.getSprintList();   
              Swal.fire(
                'Deleted!',
                'Your imaginary file has been deleted.',
                'success'
              )
            },error=>{
              Swal.fire(
                'Your imaginary file is safe :'+ error.message +')',
              )
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

}
