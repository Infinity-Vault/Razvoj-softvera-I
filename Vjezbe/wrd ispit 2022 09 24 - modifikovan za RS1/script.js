//Vars za boje:
let ErrorBackgroundColor = "#FE7D7D";
let OkBackgroundColor = "#DFF6D8";

let preuzmi = () => {
  let divDest = document.getElementById("destinacije");
  divDest.innerHTML = ""; //Brisanje postojeceg sadrzaja;

  let nazivFirme = document.getElementById("firma").value; //Pokupimo trenutno odabranu firmu iz cmb-a;
  let url =
    "https://restapiexample.wrd.app.fit.ba/Ispit20220924/GetPonuda?travelfirma=" +
    nazivFirme; //Uradimo GET na API sa trenutno odabranom firmom;

  //Fetch JSON objekta sa API-a:
  fetch(url)
    .then((response) => {
      if (response.status != 200) {
        alert("Doslo je do greske na serveru, kod greske: " + response.text);
        return;
      } else {
        response.json().then((responseJSONBody) => {
          for (const ponuda of responseJSONBody.podaci) {
            //Iteriramo kroz pojedinacnu ponudu date firme

            //Punjenje individualnog combobox-a:
            let cmb = "";
            for (const opcija of ponuda.opcije) {
              //Prodjemo kroz niz opcija
              cmb += `<option>${opcija}</option>`; //Dodamo individualno svaku kao option tag;
            }
            let noviGenerisaniCode =
              //Spremimo sve u main div destinacija
              `
                  <article class="offer">
                  <div class="akcija">${ponuda.akcijaPoruka}</div>
                  <div  class="offer-image" style="background-image: url('${ponuda.imageUrl}');" ></div>
                  <div class="offer-details">
                      <div class="offer-destination">${ponuda.mjestoDrzava}</div>
                      <div class="offer-price">$${ponuda.cijenaDolar}</div>
                      <div class="offer-description">${ponuda.opisPonude}</div>
                      <div class="offer-firma">${ponuda.travelFirma.naziv}</div>
                      <select class="offer-option">${cmb}</select>
                  </div>
                  <div class="ponuda-dugme-1" onclick='fetchDestinacija1("${ponuda.mjestoDrzava}",${ponuda.cijenaDolar},this)'>Odaberi za destinaciju 1</div>
                  <div class="ponuda-dugme-2" onclick='fetchDestinacija2("${ponuda.mjestoDrzava}",${ponuda.cijenaDolar},this)'>Odaberi za destinaciju 2</div>
                  
                  </article>
              `;
            divDest.innerHTML += noviGenerisaniCode;
          }
        });
      }
    })
    .catch((error) => {
      alert("Doslo je do neocekivane greske: " + error);
    });
};

//Definicija funkcija za 2 ponude:
let fetchDestinacija1 = (mjesto, cijena, kliknutoDugme) => {
  //Kreiramo dugme koje treba da uzme odabranu sobu iz comboboxa:
  let soba = kliknutoDugme.parentElement.querySelector(".offer-option").value;
  document.getElementById("destinacija-1").value = mjesto + " " + soba;
  document.getElementById("cijena-1").value = cijena;
  //Racunanje ukupne cijene:
  document.getElementById("cijena-ukupno").value =
    cijena + Number(document.getElementById("cijena-2").value);
};

let fetchDestinacija2 = (mjesto, cijena, kliknutoDugme) => {
  //Kreiramo dugme koje treba da uzme odabranu sobu iz comboboxa:
  let soba = kliknutoDugme.parentElement.querySelector(".offer-option").value;
  document.getElementById("destinacija-2").value = mjesto + " " + soba;
  document.getElementById("cijena-2").value = cijena;
  document.getElementById("cijena-ukupno").value =
    cijena + Number(document.getElementById("cijena-1").value);
};
let resetOkvir = () => {
  //dodatak: ovo nije traženo u ispitnom zadatku
  document
    .querySelectorAll(".offer")
    .forEach((a) => (a.style.border = "4px solid rgba(0,0,0,0)"));
};

let test_email = () => {
  let txt = document.getElementById("email");
  if (!/^[a-z]+(\.|\-|\_)?[a-z]*\@edu.fit.ba$/.test(txt.value)) {
    txt.style.backgroundColor = ErrorBackgroundColor;
    return "Email nije u ispravnom formatu!\n";
  } else {
    txt.style.backgroundColor = OkBackgroundColor;
    return "";
  }
};
let test_phone = () => {
  let txt = document.getElementById("phone");
  if (!/\+\d{3}\-\d{2}\-\d{3}\-\d{3}$/.test(txt.value)) {
    txt.style.backgroundColor = ErrorBackgroundColor;
    return "Telefon nije u ispravnom formatu!\n";
  } else {
    txt.style.backgroundColor = OkBackgroundColor;
    return "";
  }
};

let posalji = () => {
  let error = "";
  let urlPOST = "https://restapiexample.wrd.app.fit.ba/Ispit20220924/Add";
  error += test_phone(); //Dodavanje funkcija koje ce se izvrsiti sa operatorom +=
  error += test_email(); //Dodavanje funkcija koje ce se izvrsiti sa operatorom +=

  if (error !== "") {
    //Ukoliko je error ispunjen nekom porukom
    alert(error); //Ispisi tu poruku;
    return;
  } else {
    //Ukoliko je sve okej, koristi fetch sa POST na odgovarajuci API

    let korisnik = new Object(); //Kreiramo novi anonimni objekt
    korisnik.destinacija1Soba = document.getElementById("destinacija-1").value;
    korisnik.destinacija2Soba = document.getElementById("destinacija-2").value;
    korisnik.imeGosta = document.getElementById("first-name").value;
    korisnik.prezimeGosta = document.getElementById("last-name").value;
    korisnik.poruka = document.getElementById("messagetxt").value;
    korisnik.email = document.getElementById("email").value;
    korisnik.telefon = document.getElementById("phone").value;
    console.log(korisnik);
    fetch(urlPOST, {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-type": "application/json",
      },
      body: JSON.stringify(korisnik), //Pretvorimo iz JSON u string citav objekt;
    })
      .then((response) => {
        if (response.status != 200) {
          alert("Doslo je do greske na serveru, kod greske: " + response.text);
          return;
        } else {
          response.json().then((responseMess) => {
            alert(
              "Rezervacija je: " +
                responseMess.poruka +
                "\n" +
                "Rezervacija izvrsena: " +
                Date(responseMess.vrijeme) +
                "\n" +
                "Kod rezervacije je: " +
                responseMess.brojRezervacije +
                "."
            );
          });
        }
      })
      .catch((error) => {
        alert("Doslo je do neocekivane greske: " + error);
        return;
      });
  }
};
