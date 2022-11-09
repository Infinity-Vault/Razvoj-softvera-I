import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {
  studentArray: any=[];
  filter: string="";

  constructor(private server:HttpClient) { }

  ngOnInit(): void {
    this.server.get("https://localhost:7174/Student/GetAll").subscribe((students:any)=>{
      this.studentArray=students;
    })
  }

  filtriraniStudenti() {
    return this.studentArray.filter((student:any)=>student.ime.toLowerCase().startsWith(this.filter.toLowerCase()));
  }
}
