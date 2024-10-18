# Správa pacientov
Vypracovaná úloha pre záujemcov o pozíciu junior C# .NET vývojára

## Vypracované úlohy v projekte SoftProgres.PatientRegistry.Desktop

1. V súbore `Converters/SexEnumToStringConverter` vytvorený IValueConverter, ktorý na vstupe dostane enum reprezentujúci
pohlavie pacienta.
2. V súbore `Views/Pages/PatientRegistryPage.xaml` vyriešené zobrazovanie hodnôt v 3 stĺpcoch v DataGrid-e:
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
