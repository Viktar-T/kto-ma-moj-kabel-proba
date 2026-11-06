# Kto ma mój kabel

Dziennik pożyczek: co, komu, kiedy — i czy wróciło. Dla osoby z pracowni,
która pożycza sprzęt i po tygodniu nie pamięta komu.

## Pierwsza wersja

- dodaje pożyczkę: co, komu, data
- oznacza zwrot
- pokazuje, co jest na zewnątrz, od najstarszej
- pamięta po zamknięciu
- mówi, kiedy nic nie jest na zewnątrz

## Później

- lista osób, żeby nie wpisywać za każdym razem tego samego
- ile dni rzecz jest na zewnątrz

## Jak uruchomić

Potrzebne na komputerze: .NET SDK 10 ze strony dotnet.microsoft.com
Polecenie: dotnet run --project KtoMaMojKabel.Desktop
Gdzie powstaje plik z danymi: folder danych użytkownika, KtoMaMojKabel\pozyczki.json
Pierwsze uruchomienie pokazuje: puste pola i zdanie „Nic nie jest na zewnątrz.”
