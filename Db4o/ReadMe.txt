Osoby(Imie i nazwisko jednoznaczeni identyfikują)
=========================	
-imie : string
-nazwisko : string
-adres : Adres
-telefony : list<telefon>

Adres
=================
ulica : string
kodPocztowy : string
miasto : string

Telefon(numer identyfikuje)
===============
numer : string
operator : string
rodzaj : string

osoba - - - - - adres
osoba - - - - - telefon

0. program konsolowy.
1. Dodaj/usuń/modyfikuj osobę - adres, telefon nie są obowiązkowe.
2. Dodaj/usuń/modyfikuj adres wskazanej osoby.
3. Dodaj/usuń/modyfikuj telefon do listy telefonów.
// przy usuwaniu osoby należy usunąć wszystkie jej adresy i telefony
// modyfikacja modyfikuje obiekt a nie tworzy nowy.
4. Pokazanie danych konkretnej osoby.
5. Statystyka - wyświetlenie iczbby obiektów poszczególnych klas.