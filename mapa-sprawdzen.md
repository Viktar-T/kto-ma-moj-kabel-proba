# Mapa sprawdzeń

Swobodnie: Najbardziej boję się o K1. Trzy pożyczki wróciły już raz bez dat po zamianie magazynu, a każda następna zmiana w logice znowu dotknie zapisu — i nikt nie będzie tego sprawdzał co wieczór.

## K1: pamięta po zamknięciu
Gdzie mieszka: logika
Rodzaj: integracyjny
Sprawdza: maszyna
Dlaczego: wynik da się zapisać z góry (trzy pożyczki do pliku, trzy z tymi samymi datami z powrotem) i zawsze wychodzi taki sam; będzie potrzebny po każdej zmianie magazynu.
Test albo kiedy: jeszcze nie ma

## K2: przeżywa błąd użytkownika
Gdzie mieszka: oba
Rodzaj: jednostkowy (logika), okno (komunikat)
Sprawdza: maszyna — logika: puste „co” nie jest dodawane; człowiek — komunikat w oknie
Dlaczego: odrzucenie pustego „co” to reguła z wynikiem z góry; brzmienie i miejsce komunikatu jeszcze się zmienią i trzeba je zobaczyć.
Test albo kiedy: jeszcze nie ma; komunikat — po każdej zmianie okna

## K3: pozycja na liście z datą
Gdzie mieszka: oba
Rodzaj: jednostkowy (logika), okno (lista)
Sprawdza: maszyna — data zostaje przy pożyczce; człowiek — lista na ekranie się odświeża
Dlaczego: data to wartość, którą test porówna; czy lista się odświeżyła, widzi tylko oko.
Test albo kiedy: jeszcze nie ma; lista — po każdej zmianie okna

## K4: zwrot skraca listę
Gdzie mieszka: logika
Rodzaj: jednostkowy
Sprawdza: maszyna
Dlaczego: policzyć przed i po — wynik z góry, zawsze taki sam.
Test albo kiedy: jeszcze nie ma

## K5: najstarsza pierwsza
Gdzie mieszka: logika
Rodzaj: jednostkowy
Sprawdza: maszyna
Dlaczego: kolejność dat to czysta reguła logiki, także przy tej samej dacie (kolejność wpisania).
Test albo kiedy: jeszcze nie ma

## K6: pusta lista mówi, że nic nie jest na zewnątrz
Gdzie mieszka: oba
Rodzaj: jednostkowy (logika), okno (zdanie)
Sprawdza: maszyna — logika mówi „pusto”; człowiek — zdanie zamiast listy
Dlaczego: „pusto” to wartość; czy zdanie stoi tam, gdzie była lista, trzeba zobaczyć.
Test albo kiedy: jeszcze nie ma; zdanie — przed tagiem

## Czego nie sprawdzi nic z tej listy
Czy pole daty jest tam, gdzie osoba z pracowni go szuka — to pokazała dopiero opinia, i pokaże następna.
