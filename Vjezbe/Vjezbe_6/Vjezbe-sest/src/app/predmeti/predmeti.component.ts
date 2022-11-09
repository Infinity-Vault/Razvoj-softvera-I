import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-predmeti',
  templateUrl: './predmeti.component.html',
  styleUrls: ['./predmeti.component.css']
})
export class PredmetiComponent implements OnInit {
  prosjek: any;
  nazivPredmeta: any;
  predmetiArray: any;

  constructor(private server: HttpClient) { }

  ngOnInit(): void {

  }
  fetchpredmeti(){
    this.server.get("https://localhost:7174/Predmet/GetAll?nazivPredmeta="+this.nazivPredmeta+"&minProsjek="+this.prosjek)
      .subscribe((predmeti:any)=>{
        this.predmetiArray=predmeti;
      })
  }
}
