import { HttpClient } from '@angular/common/http';
import { from } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  constructor( private http:HttpClient) { }
  
  values: any;

  name='';

  ngOnInit(){
   return this.http.get("https://localhost:44349/api/Student").subscribe(response=>{
     //console.log(response);
     this.values = response;
   },error =>{
     console.log(error);
   });
  }

  registerForm: FormGroup;

  onSubmit(){
    
    alert($('input[name ="sid"]').val())
  }
  
}
