# 001 — Kto ma mój kabel: pierwsza wersja

Swobodnie: Osoba z pracowni pożycza sprzęt — kabel, miernik, zasilacz — i po tygodniu nie pamięta komu. Otwiera program, wpisuje co, komu i kiedy; kiedy rzecz wraca, oznacza zwrot. Lista pokazuje, co jest na zewnątrz, od najstarszej pożyczki.

## Cel
Cel: zastępuje kartkę przy drzwiach pracowni, na której nikt nie zapisuje zwrotów.

## Dla kogo
Dla kogo: osoba z pracowni.

## Co robi
1. dodaje pożyczkę: co, komu, data
2. oznacza zwrot
3. pokazuje, co jest na zewnątrz, od najstarszej
4. pamięta po zamknięciu
5. mówi, kiedy nic nie jest na zewnątrz

## Czego nie robi
- nie trzyma listy osób (Później)
- nie liczy dni (Później)
- nie wysyła niczego poza komputer (nigdy)

## Kryteria akceptacji
K1 — pamięta po zamknięciu: Kiedy wpiszę trzy pożyczki i zamknę aplikację krzyżykiem, to po ponownym otwarciu lista ma trzy pozycje z tymi samymi datami. Sprawdzenie: policzyć pozycje po otwarciu.
K2 — przeżywa błąd użytkownika: Kiedy zostawię puste pole „co” i kliknę „zapisz”, to aplikacja zostaje na ekranie, nic nie dopisuje i mówi, że trzeba wpisać, co pożyczam. Sprawdzenie: kliknąć z pustym polem; policzyć pozycje.
K3: Kiedy wpiszę „miernik”, „osoba z pracowni” i dzisiejszą datę i kliknę „zapisz”, to pozycja jest na liście z tą datą. Sprawdzenie: zobaczyć listę.
K4: Kiedy oznaczę pożyczkę jako zwróconą, to znika z listy rzeczy na zewnątrz, a lista jest o jedną krótsza. Sprawdzenie: policzyć przed i po.
K5: Kiedy na liście są trzy pożyczki z różnymi datami, to najstarsza jest pierwsza; przy tej samej dacie w kolejności wpisania. Sprawdzenie: porównać daty od góry.
K6: Kiedy nie ma żadnej pożyczki, to lista mówi, że nic nie jest na zewnątrz. Sprawdzenie: zwrócić ostatnią rzecz i spojrzeć na listę.

## Do ustalenia
- brak

## Zmiany
- 2026-11-03 — K5 — dopowiedzenie o tej samej dacie, bo agent ułożył alfabetycznie
