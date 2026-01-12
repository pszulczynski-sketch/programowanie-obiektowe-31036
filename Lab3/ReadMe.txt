System Obsługi Komisu Samochodowego (Lab3)


Prosta i niezawodna aplikacja konsolowa napisana w języku C#, służąca do zarządzania bazą pojazdów w komisie. Program pozwala na pełną kontrolę nad danymi (CRUD) i przechowuje je w formacie JSON.


Główne Funkcje
- Dodawanie pojazdów: Rejestracja marki, silnika oraz mocy (KM) z automatyczną weryfikacją unikalności numeru rejestracyjnego.
- Modyfikacja danych: Możliwość edycji konkretnych parametrów auta (np. tylko marka lub tylko silnik) bez konieczności wpisywania wszystkiego od nowa.
- Usuwanie: Szybkie usuwanie pojazdów z bazy na podstawie numeru rejestracyjnego.
- Podgląd bazy: Przejrzysta lista wszystkich zarejestrowanych aut z licznikiem ilości aut.


Bezpieczeństwo i Logika
Projekt został zaprojektowany z dużą dbałością o stabilność:
- Automatyczne tworzenie bazy: Program sam sprawdza obecność pliku ListaAut.json. Jeśli go nie znajdzie, utworzy nowy plik przy dodaniu pierwszego auta.
- Zaawansowana walidacja: Dzięki dedykowanej klasie walidującej, system nie pozwoli na wprowadzenie pustych danych lub samych spacji.
- Unikalność kluczy: System uniemożliwia dodanie dwóch aut o tym samym numerze rejestracyjnym, co zapobiega dublowaniu się danych.
- Odporność na błędy (Fail-safe): Każda operacja na plikach (odczyt/zapis) jest zabezpieczona blokami try-catch. W razie uszkodzenia pliku lub braku uprawnień, program wyświetli profesjonalny komunikat zamiast nagłego zamknięcia.
- Obsługa Nullable Types: Kod jest zgodny z nowoczesnymi standardami C#, eliminując ryzyko wystąpienia błędów typu NullReferenceException.


Struktura Plików
Program korzysta z formatu JSON, co pozwala na łatwy podgląd bazy w dowolnym edytorze tekstu. Dane są zorganizowane w strukturze słownikowej: Klucz (Rejestracja) -> Wartości (Lista cech).


Technologia
- Język: C#
- Format danych: JSON
- Architektura: Programowanie obiektowe (OOP) z podziałem na klasy statyczne i instancyjne.