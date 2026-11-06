# Plan — 001

## Co aplikacja wie
Pożyczka: przedmiot, osoba, data, czy zwrócona.

## Co umie
Dodać pożyczkę; oznaczyć zwrot; pokazać niezwrócone od najstarszej;
powiedzieć, że nic nie jest na zewnątrz.

## Gdzie mieszka każde kryterium
- K1: logika — zapis i odczyt pliku; okno tylko pokazuje listę po otwarciu.
- K2: oba — logika odrzuca puste „co”, okno pokazuje komunikat.
- K3: oba — logika dodaje, okno przyjmuje pola i odświeża listę.
- K4: logika — zwrot zmienia stan pożyczki; okno pokazuje krótszą listę.
- K5: logika — kolejność od najstarszej.
- K6: oba — logika mówi „pusto”, okno pokazuje zdanie zamiast listy.

## Projekty
KtoMaMojKabel.Logika: pożyczka, lista pożyczek, zapis i odczyt pliku.
KtoMaMojKabel.Desktop (Avalonia): jedno okno z listą, polami i przyciskiem;
korzysta z Logiki.

## Magazyn
JSON — jedna lista jednego rodzaju rzeczy. Lista osób z „Później” byłaby drugim
rodzajem, który odwołuje się do pożyczek; wtedy SQLite.

## Plik z danymi
pozyczki.json w folderze danych użytkownika (ApplicationData); nazwa w .gitignore.

## Sprawdzenie z konstytucją
Punkt 6: zwrot zmienia pole „czy zwrócona”, nie usuwa wpisu.
