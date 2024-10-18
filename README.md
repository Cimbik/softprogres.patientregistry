# Správa pacientov
Vypracovaná úloha pre záujemcov o pozíciu junior C# .NET vývojára

## Vypracované úlohy v projekte SoftProgres.PatientRegistry.Api

1. V súbore `Validators/BirthNumberValidator.cs` je implementovaná validácia rodného čísla.
   - Za validný vstupný formát sa považuje reťazec reprezentujúci rodné číslo s lomkou aj bez lomky
   - Validácia spĺňa pravidlá definované v [zákone 301/1995 Z. z. o rodnom čísle § 2](https://www.slov-lex.sk/pravne-predpisy/SK/ZZ/1995/301/#paragraf-2)
   - V súbore `ServiceInterface/PatientService.cs` je volaná funkcia validácie (validátor je v premennej
   `_birthNumberValidator`) pri vytváraní pacienta (metóda `Post`) a aktualizácií údajov o pacientovi (metóda `Put`).
2. V súbore `Helpers/BirthNumberHelper.cs` je implementovaná funkcionalita na získavanie dátumu narodenia, veku 
a pohlavia osoby z rodného čísla.
   - Za validný vstupný formát sa považuje reťazec reprezentujúci rodné číslo s lomkou aj bez lomky
   - Predpokladame, že rodné číslo na vstupe je už validné podľa [zákona 301/1995 Z. z. o rodnom čísle § 2](https://www.slov-lex.sk/pravne-predpisy/SK/ZZ/1995/301/#paragraf-2).
   - V súbore `Database/DataProvider.cs` sú volané pomocné funkcie (helper je v premennej `_birthNumberHelper`) 
   pri vytváraní pacienta (metóda `CreatePatientAsync`) a aktualizácii údajov o pacientovi (metóda `UpdatePatientAsync`).

## Vypracované úlohy v projekte SoftProgres.PatientRegistry.Desktop

1. V súbore `Converters/SexEnumToStringConverter` je vytvorený IValueConverter, ktorý na vstupe dostane enum reprezentujúci
pohlavie pacienta.
2. V súbore `Views/Pages/PatientRegistryPage.xaml` je vyriešené zobrazovanie hodnôt v 3 stĺpcoch v DataGrid-e:
   - Stĺpec `Pohlavie` zobrazuje hodnotu s použitím convertera vytvoreného v 1. úlohe
   - Stĺpec `Dátum narodenia` zobrazuje hodnotu, ktorá je v bindingu naformátovaná do tvaru `dd.mm.rrrr`
   - Stĺpec `Adresa` zobrazuje v sebe kombináciu kompletnej adresy zo 4 premenných v tvare 
   "Ulica, PSČ Mesto, Štát", čiže napr. "Nálepková 123/13, 921 01 Piešťany, Slovensko".
3. V súbore `ViewModels/PatientRegistryViewModel.cs` je implementované vo funkcii `DeletePatientAsync` volanie systémového
`MessageBox`, ktorý vyžiada užívateľské potvrdenie zmazania pacienta.
4. V súbore `ViewModels/PatientRegistryViewModel.cs` je implementovaná vo funkcii `ExportToCsvAsync` funkcionalita exportu 
dát aktuálneho zoznamu pacientov do CSV súboru.
5. V súbore `Views/Pages/EditPatientPage.xaml` je vytvorený jednoduchý formulár, ktorý aktualizuje pacientské údaje 
nachádzajúce sa v premennej ViewModel-u `CurrentPatient`.
