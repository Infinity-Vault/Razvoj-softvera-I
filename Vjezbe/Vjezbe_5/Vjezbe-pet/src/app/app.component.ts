import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MyServer} from "./MyServer";
import {filter} from "rxjs";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Student application';
  filterData: string=""; //String koji cemo koristiti za filter;
  students:any= []; //Kreiramo prazan inicijaliziran niz;
  editedStudent: any;//Kreiramo lokalnu varijablu za studenta koji se edituje;

  ngOnInit() {
    this.fetchStudents();//Pozovemo metodu da se izvrsi odmah nakon inicijaliziranja komponente;
  }

  //Napravimo konstruktor u koji pomocu dependency injection-a dodamo objekat tipa HttpClientModule


  constructor(private fetch:HttpClient) {//Ukoliko field ucinimo private on se automatski inicijalizuje i nema potrebe da isto radimo u ctor;
  }
  fetchStudents() {
    this.fetch.get(MyServer.path+"/Student/GetAll").subscribe(response=>{
      this.students=response;
    })
  }

  //Metoda koja spasi promjene studenta:
  saveChanges() {
    this.fetch.post(MyServer.path+"/Student/UpdateOrAdd",this.editedStudent).subscribe((message:any)=>{
      alert(message.ime+"  "+message.prezime+" je uspjesno dodan/editovan!");
    })
    this.filterStudents();//Osvjezavanje iz nove promijenjene baze;
  }

  //Metoda koja filtrira studente po imenu:
  filterStudents() {
    return this.students.filter((s:any)=>s.ime.toLowerCase().startsWith(this.filterData.toLowerCase()))
  }
}
