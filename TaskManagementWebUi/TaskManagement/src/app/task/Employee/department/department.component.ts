import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoadingBarService } from '@ngx-loading-bar/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ToastrService } from 'ngx-toastr';
import { DataService } from 'src/app/Service/data.service';
import { EmpDepartment } from 'src/app/Service/model';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
declare var $:any;

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html'
})
export class DepartmentComponent implements OnInit {

  @BlockUI() blockUI : NgBlockUI;
  loader = this.loadingBar.useRef();

  submitted:boolean = false;
  DepartmentList:any = []
  Department : EmpDepartment = {
    DepartmentID : 0,
    DepartmentName : "",
    DisOrder:0
  };


  page = 1;
  count = 0;
  tableSize = 7;
  tableSizes = [5, 10, 20, 50];
  filterText:string=""; 
  constructor(private http : HttpClient, private rest : DataService,private toastr: ToastrService, private loadingBar: LoadingBarService ) { 

    this.Department = new EmpDepartment()
  }

  ngOnInit() {
    this.loader.start();
  // this.blockUI.start("loading..");
    this.getDepartmentList();
    //this.blockUI.stop();
    this.loader.complete();
    
  }

  onTableDataChange(event){
    this.page = event;
  }  

  onTableSizeChange(event): void {
    this.tableSize = event.target.value;
    this.page = 1;
  }



  getDepartmentList(){
    this.http.get<any>(environment.apiUrl+'Employee/GetAllDepartment', this.rest.getOptions())
    .subscribe(res=>{
      this.DepartmentList =[];
      this.DepartmentList = res.results;
      console.log(this.DepartmentList);    
    });
  }

  onSubmit(form: NgForm) {
    if (form.invalid) {
      console.log(this.Department); 
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Fill Requred Field!',
        footer: '<a href>Why do I have this issue?</a>'
      })
      // this.toastr.warning("",'Status!');
      return;
    }    
    
    this.blockUI.start('Loading...');
    if(this.Department.DepartmentID>0){
      console.log(this.Department);
      this.http.put<any>(environment.apiUrl+'Employee/UpdateDepartment', this.Department, this.rest.getOptions())
      .subscribe(res=>{
        console.log(res); 
        this.getDepartmentList();               
          $('.modal').modal('hide'); 
          this.blockUI.stop();    
          this.toastr.success("Successfully updated", "Status")    
      },error=>{
        console.log(error); 
       this.blockUI.stop();      
      });
    }else{
      this.http.post<any>(environment.apiUrl+'Employee/AddDepartment',JSON.stringify(this.Department), this.rest.getOptions())
      .subscribe(res=>{
        console.log(res); 
        this.getDepartmentList();   
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
    this.Department = {};
    this.submitted = false;
  }


  editClick(data){
     console.log(data);    
    this.Department.DepartmentID = data.departmentID;
    this.Department.DepartmentName =  data.departmentName;
    this.Department.DisOrder =  data.disOrder;
       console.log(this.Department);
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
          this.http.delete<any>(environment.apiUrl+'Employee/DeleteDepartment/'+ id, this.rest.getOptions())
            .subscribe(res=>{
              console.log(res); 
              this.getDepartmentList();   
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
