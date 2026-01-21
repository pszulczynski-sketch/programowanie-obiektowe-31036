Projekt Bank (Wersja konsolowa)
Ten zaawansowany system konsolowy służy do kompleksowego zarządzania operacjami bankowymi, wykorzystując programowanie obiektowe oraz mechanizmy bezpiecznej autoryzacji. Aplikacja rozróżnia uprawnienia pracowników (Kasjer, Kierownik, Dyrektor), dostosowując widoczne funkcje — od prostych wpłat i wypłat, przez edycję danych, aż po automatyczną analizę zdolności kredytowej. Całość logiki opiera się na trwałości danych w formacie JSON, co pozwala na prowadzenie szczegółowej historii transakcji i generowanie tekstowych potwierdzeń operacji dla każdego klienta.


Kluczowe informacje o strukturze danych:
- Autoryzacja (Plik JSON): Plik users.json (zawierający loginy takie jak KASJER1, DYREKTOR1) musi znajdować się w tym samym folderze co plik wykonywalny programu.
- Hasła (Testy): W celach testowych i poglądowych, hasła operatorów są zapisane w zwykłym pliku tekstowym w katalogu głównym projektu (choć system weryfikuje je jako bezpieczne skróty BCrypt).
- Baza Danych (Folder Baza-danych): Funkcję bazy danych pełnią foldery nazywane numerami PESEL klientów, w których przechowywane są pliki dane.json, historia-transakcji.json oraz generowane dokumenty .txt.


Krótka charakterystyka wszystkich klas projektu Bank:
Klasa: Program (Main)
Główny punkt wejścia aplikacji, który odpowiada za inicjalizację zabezpieczeń systemowych (blokada przycisku zamknięcia) oraz wyświetlenie interfejsu startowego. Realizuje logikę autoryzacji użytkownika i poprzez mechanizm polimorfizmu uruchamia menu odpowiednie dla przypisanej roli: Kasjera, Kierownika lub Dyrektora. Program działa w nieskończonej pętli, zapewniając ciągłość pracy terminala po wylogowaniu użytkownika.


Klasy: UserMenu, CashierMenu, ManagerMenu i DirectorMenu
Zastosowanie wzorca projektowego Metody Szablonowej oraz Polimorfizmu pozwala na eleganckie zarządzanie uprawnieniami w systemie bankowym. Klasa abstrakcyjna UserMenu definiuje szkielet działania interfejsu (pętla Run, nagłówek, wylogowywanie), natomiast klasy pochodne precyzują, jakie operacje są dostępne dla konkretnych rang pracowników.


Klasa: LogIn
Klasa zarządzająca bezpieczeństwem dostępu, która odpowiada za autoryzację operatorów systemowych poprzez weryfikację skrótów haseł (BCrypt) zapisanych w pliku JSON. Wykorzystuje metodę GetHiddenConsoleInput do bezpiecznego wprowadzania hasła (ukrywanie znaków w konsoli) oraz automatycznie parsuje identyfikator użytkownika, aby zwrócić jego rolę w systemie. Posiada rygorystyczne reguły walidacji (długość loginu i hasła) oraz wbudowaną obsługę wyjątków, co chroni terminal przed nieautoryzowanym dostępem.


Klasa: BlockExit
Klasa techniczna wykorzystująca mechanizm P/Invoke do komunikacji z systemowymi bibliotekami Windows (user32.dll oraz kernel32.dll). Jej zadaniem jest pobranie uchwytu okna konsoli i zmodyfikowanie jego menu systemowego w celu dezaktywacji przycisku zamknięcia ("X") oraz skrótu Alt+F4. Zwiększa to bezpieczeństwo terminala, uniemożliwiając przypadkowe lub nieautoryzowane wyłączenie aplikacji przez operatora.


Klasa: CheckPesel
Statyczna klasa pomocnicza służąca do walidacji formatu numeru PESEL wprowadzanego przez operatora. Zawiera zapętloną metodę, która wymusza podanie niepustego ciągu znaków o długości dokładnie 11 cyfr, wykorzystując przy tym klasy SuccessMessage oraz FailMessage do informowania użytkownika o wyniku weryfikacji.


Klasa: Client
Model danych reprezentujący profil klienta banku, zawierający kluczowe informacje osobowe, adresowe oraz stan konta (Balance). Klasa służy jako struktura do mapowania danych w procesach tworzenia nowych kont, modyfikacji istniejących rekordów oraz serializacji danych do formatu JSON.


Klasa: CreateAccount
Klasa procesowa odpowiedzialna za rejestrację nowych klientów, która zapewnia unikalność numeru PESEL poprzez weryfikację istnienia odpowiednich katalogów w bazie danych. Implementuje interfejs IPrintable, co pozwala na generowanie tekstowego potwierdzenia otwarcia rachunku, równolegle zapisując pełne dane klienta do pliku dane.json. Posiada wbudowany mechanizm zatwierdzania danych przez operatora, co minimalizuje ryzyko wprowadzenia błędnych informacji do systemu.


Klasa: DepositMoney
Klasa realizująca proces deponowania gotówki na istniejące konto klienta poprzez pobranie danych z pliku JSON i aktualizację salda obiektu Client. Oprócz zapisu nowego stanu konta do bazy danych, automatycznie wywołuje system logowania transakcji (LogTransaction) oraz generuje fizyczny plik potwierdzenia wpłaty w formacie .txt. Proces jest zabezpieczony walidacją kwoty (musi być liczbą dodatnią) oraz obsługą wyjątków przy dostępie do plików systemowych.


Klasa: FailMessage
Statyczna klasa narzędziowa odpowiedzialna za standaryzację komunikatów o błędach w całym systemie. Metoda FMessage przyciąga uwagę operatora za pomocą niskotonowego sygnału dźwiękowego oraz czerwonego koloru tekstu, a następnie wstrzymuje działanie programu na 5 sekund przed wyczyszczeniem konsoli, co zapewnia czytelność i porządek w interfejsie terminala.


Interfejs: IPrintable
Definiuje ustandaryzowany kontrakt dla wszystkich klas generujących dokumenty, wymagając od nich implementacji metody DocumentContent(). Dzięki temu interfejsowi system wymusza spójność w przygotowywaniu treści do wydruku (np. potwierdzeń wpłat czy wniosków), co ułatwia zarządzanie generowaniem plików tekstowych w różnych modułach aplikacji.


Klasa: IsDataEmpty
Uniwersalna klasa walidująca, która zapobiega przesyłaniu pustych ciągów znaków do pól tekstowych takich jak imię, nazwisko czy adres. Dzięki zastosowaniu pętli while(true), metoda CheckData skutecznie wymusza na operatorze podanie poprawnych danych przed przejściem do kolejnego kroku, co gwarantuje integralność informacji przechowywanych w bazie danych.


Klasa: LoanApplication
Klasa realizująca logikę scoringu kredytowego, która podejmuje automatyczną decyzję o przyznaniu pożyczki na podstawie analizy historycznej liczby wpłat klienta. Implementując interfejs IPrintable, generuje dokument tekstowy z wynikiem analizy i statusem wniosku (od "Nie przyznano" po "Przyznano"), bazując na danych zdeserializowanych z pliku historia-transakcji.json.


Klasa: LogTransaction
Statyczna klasa pomocnicza odpowiedzialna za rejestrowanie każdej operacji finansowej w trwałej historii klienta. Metoda NewLog automatycznie zarządza plikiem historia-transakcji.json – odczytuje istniejącą listę zdarzeń, dopisuje nową transakcję (data, typ, kwota, saldo końcowe) i zapisuje zaktualizowany zbiór z powrotem na dysku. Jest to kluczowy moduł dla zachowania pełnego audytu operacji, wykorzystywany później m.in. przy analizie wniosków o pożyczkę.


Klasa: PaycheckMoney
Klasa procesowa obsługująca wypłaty gotówkowe, która przed dokonaniem transakcji weryfikuje dostępność środków na koncie klienta oraz poprawność kwoty. W przypadku pozytywnej walidacji aktualizuje saldo w pliku dane.json, generuje tekstowe potwierdzenie operacji oraz rejestruje zdarzenie w historii transakcji. Dzięki implementacji interfejsu IPrintable, zapewnia spójny format generowanych dokumentów potwierdzających pobranie gotówki.


Klasa: SuccessMessage
Statyczna klasa narzędziowa służąca do wyświetlania pozytywnych komunikatów systemowych po udanych operacjach bankowych. Metoda SMessage wyróżnia sukces poprzez sygnał dźwiękowy o wysokiej częstotliwości oraz utrzymuje informację na ekranie przez 5 sekund, zapewniając użytkownikowi czas na przeczytanie potwierdzenia przed automatycznym wyczyszczeniem konsoli.


Klasa: Transaction
Model danych reprezentujący pojedynczy wpis w historii operacji finansowych klienta. Przechowuje kluczowe informacje o zdarzeniu: dokładną datę i godzinę, typ operacji (np. wpłata/wypłata), kwotę oraz stan salda po zakończeniu transakcji. Klasa ta jest niezbędna do poprawnej serializacji i deserializacji historii działań w formacie JSON.


Klasa: TransactionList
Klasa służąca do przeglądania i eksportowania historii operacji finansowych danego klienta, która pobiera dane z pliku JSON i wyświetla w konsoli 10 ostatnich transakcji. Implementuje interfejs IPrintable, co umożliwia wygenerowanie kompletnego, sformatowanego wykazu wszystkich operacji w formie pliku tekstowego wykaz-historii-transakcji.txt.


Klasa: UpdateAccount
Klasa ta udostępnia interaktywny interfejs menu, który pozwala na selektywną modyfikację danych osobowych i adresowych istniejącego klienta. Po weryfikacji numeru PESEL, operator może edytować poszczególne pola (imię, nazwisko, adres, miasto), korzystając z walidacji klasy IsDataEmpty. Dzięki implementacji IPrintable, każda zatwierdzona zmiana skutkuje nie tylko aktualizacją pliku dane.json, ale również wygenerowaniem fizycznego potwierdzenia aktualizacji konta.