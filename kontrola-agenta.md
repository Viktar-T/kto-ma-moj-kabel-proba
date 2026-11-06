# Kontrola pracy agenta

Swobodnie: Zaskoczyło mnie, że test do K5 był najkrótszy z trzech i wyglądał najpewniej — dwa Assert.That i żadnego porównania kolejności. Gdybym go nie zepsuł, zostałby.

## Test: K3_dodana_pozycja_jest_na_liscie_z_data
Kryterium: K3 — pozycja na liście z datą
Co zepsute: w Dodaj data zapisana jako kiedy.AddDays(1) — o jeden dzień później
Padł: tak (razem z ręcznym K5, bo przesunęły się wszystkie daty)
Werdykt: zostaje — bo sprawdza dokładnie to, co obiecuje kryterium: nazwę i datę

## Test: K6_pusta_lista_mowi_ze_nic_nie_jest_na_zewnatrz
Kryterium: K6 — pusta lista mówi, że nic nie jest na zewnątrz
Co zepsute: JestPusto zwraca prawdę przy jednej pożyczce zamiast przy zerze
Padł: tak
Werdykt: zostaje — bo padł na dokładnie tej linii, od której zależy kryterium

## Test: K5_przy_tej_samej_dacie_kolejnosc_wpisania
Kryterium: K5 — dopowiedzenie: przy tej samej dacie w kolejności wpisania
Co zepsute: kolejność listy odwrócona (Reverse po OrderBy)
Padł: nie — padły dwa testy ręczne, K4 i K5; ten został zielony
Werdykt: poprawiony — bo sprawdzał tylko, że lista istnieje i ma dwie pozycje; po poprawce porównuje kolejność nazw i na tym samym zepsuciu pada

## Przegląd modelu
Narzędzie i data: (wypełniane po przeglądzie)
- Uwaga: (wypełniane po przeglądzie) · Kubełek: … · Jak sprawdzone: …
Czego model nie zauważył, a ty tak: (wypełniane po przeglądzie)
