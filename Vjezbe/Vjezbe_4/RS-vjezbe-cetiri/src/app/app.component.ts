import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title:string = 'RS-vjezbe-cetiri';//Varijabla za naslov prikazan u h2 taggu;
  nazivPredmeta:string = 'Ra';//Varijabla kasnije koristena za fetch isto kao i minProsjek;
  minProsjek = 0.0;
  podaci:any=[];//Napravimo prazni niz bilo koje tipa podatka;

  //Metoda koja radi fetch sa servera;
  PreuzmiPredmete(naziv:string,prosjek:any) {
    //Poprimimo vrijednosti;
    if (naziv!=null)
      this.nazivPredmeta=naziv;
    if(prosjek!=null)
      this.minProsjek=prosjek;

    let url:string='https://localhost:7174/Predmet/GetAll?nazivPredmeta='+this.nazivPredmeta+'&'+this.minProsjek;

    fetch(url).then(response=>{
      if(response.status!==200)
        alert('Greska na serveru,'+ response.statusText);
      else{
        response.json().then(responseBody=>{
        this.podaci=responseBody;//Preuzmemo niz podataka (predmeta);
        })
      }
    }).catch(err=>{
      alert('Doslo je do nepoznate greske,'+ err.message())
    })
  }

  odabraniPredmet:any;
  Edituj(predmet:any) {
    this.odabraniPredmet=predmet;//Poprimimo predmet koji smo kliknuli;

  }
}
