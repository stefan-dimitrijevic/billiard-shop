# BilliardShop
## Dokumentacija
### Projekat: BilliardShop - online prodavnica bilijarske opreme
### Student: Stefan Dimitrijevic 57/16

### Tema projekta:
Aplikacija je zamišljena kao online prodavnica bilijarske opreme.

### Opis:
Korišćen je code first pristup.

API predstavlja skup endpointa preko kojih korisnik može da se registruje i autorizuje (upotrebom JWT-a) i izvršava privilegije (UseCases).

Granulacija privilegija je na nivou svakog korisnika, gde adminitrator svakom pojedinačnom korisniku može dodati ili oduzeti privilegiju.
Takođe, pokriven je CRUD za sve entitete. Implementirana je paginacija i pretraga za sve entitete.

Registracijom korisnik dobija mogućnost da kreira svoje porudžbine, pregleda, menja i otkazuje. Nakon uspešne registracije korisniku će stići mejl o uspešnosti.

Mapiranje Dto objekata realizovano je preko Automapper-a.

Validacija podataka pri upisu i izmeni realizovana je preko FluentValidation biblioteke.

Administrator ima pristup pokušajima izvršavanja slučaja korišćenja koji su zabeleženi u tabeli koja predstavlja audit log. Moguća je i pretraga audit log-a.

Implementirana je i Swagger specifikacija.

### Dodatna uputstva za pregledanje:

Kredencijali:

Administrator: Email: admin@gmail.rs ; Password: admin123

Autorizovani korisnik: Email: stefan@gmail.com ; Password: stefan123

### Napomene:

Pri upisu novog proizvoda podatke slati preko Body / form-data.

Nakon migracije i Update-Database komande pogoditi PopulateController (POST) radi inserta inicijalnih podataka.

Slika dijagrama baze podataka se nalazi u root-u projekta.

