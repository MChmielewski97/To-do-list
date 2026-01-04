WpfCrudApp – Lista zadań (WPF, .NET)

1. Opis projektu

Aplikacja okienkowa napisana w technologii WPF (.NET), umożliwiająca zarządzanie listą zadań do wykonania. Program pozwala na dodawanie, wyświetlanie, wyszukiwanie, edycję oraz usuwanie obiektów, 
a także zapis i odczyt danych z pliku przy ponownym uruchomieniu aplikacji.

2. Funkcjonalności
- dodawanie nowych zadań
- wyświetlanie listy zadań
- edycja istniejących zadań
- usuwanie zadań
- wyszukiwanie zadań po tytule
- walidacja danych wejściowych (wymagany tytuł zadania)
- zapis danych do pliku JSON
- automatyczny odczyt danych przy uruchomieniu aplikacji

3. Struktura obiektu

Każde zadanie składa się z następujących pól:
- Title – tytuł zadania (pole wymagane)
- Description – opis zadania
- DueDate – termin wykonania

4. Zapis danych

Dane zapisywane są lokalnie do pliku tasks.json w katalogu projektu przy użyciu serializacji JSON. Plik jest automatycznie tworzony i aktualizowany podczas dodawania, 
edycji lub usuwania obiektów. Przy starcie aplikacji dane są wczytywane z pliku.

5. Technologie

- .NET (6 / 7 / 8)
- WPF (Windows Presentation Foundation)
- C#
- System.Text.Json

6. Uruchomienie projektu

  6.1. Upewnić się, że zainstalowane jest .NET SDK
  6.2. Otworzyć katalog projektu w terminalu
  6.3. Wykonać polecenie: "dotnet run"

  

  
