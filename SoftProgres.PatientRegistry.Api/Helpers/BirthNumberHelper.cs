﻿using SoftProgres.PatientRegistry.Api.ServiceModel.Types;

namespace SoftProgres.PatientRegistry.Api.Helpers;

public class BirthNumberHelper : IBirthNumberHelper
{
    /// <summary>
    /// Získa dátum narodenia osoby z rodného čísla.
    /// Rodné číslo nie je potrebné validovať, predpokladajte, že je validné.
    /// </summary>
    /// <param name="birthNumber">Validné rodné číslo v tvare s lomkou alebo bez lomky.</param>
    /// <returns>Dátum narodenia osoby</returns>
    public DateTime GetDateOfBirthFromBirthNumber(string birthNumber)
    {
        // rozdelenie roku narodenia na rok, mesiac a dní
        int year = int.Parse(birthNumber.Substring(0, 2));
        int month = int.Parse(birthNumber.Substring(2, 2));
        int day = int.Parse(birthNumber.Substring(4, 2));

        // Ženy majú mesiace navýšené o 50
        month -= (month > 50) ? 50 : 0;

        // Určenie plného roku
        year += (birthNumber.Replace("/", "").Length == 9 || year >= 54) ? 1900 : 2000;

        return new DateTime(year, month, day);
    }

    /// <summary>
    /// Získa dátum narodenia osoby z rodného čísla.
    /// Rodné číslo nie je potrebné validovať, predpokladajte, že je validné.
    /// </summary>
    /// <param name="birthNumber">Validné rodné číslo v tvare s lomkou alebo bez lomky.</param>
    /// <returns>Vek osoby</returns>
    public int GetAgeFromBirthNumber(string birthNumber)
    {
        int years = DateTime.Today.Year - GetDateOfBirthFromBirthNumber(birthNumber).Year;

        // Kontrola, či už tento rok už boli narodeniny (ak nie, odpočítat 1) a vratenie veku
        return GetDateOfBirthFromBirthNumber(birthNumber).Date > DateTime.Today.AddYears(-years) ? years-- : years; 
    }
     
    /// <summary>
    /// Získa pohlavie osoby z rodného čísla.
    /// Rodné číslo nie je potrebné validovať, predpokladajte, že je validné.
    /// </summary>
    /// <param name="birthNumber">Validné rodné číslo v tvare s lomkou alebo bez lomky.</param>
    /// <returns>Pohlavie osoby</returns>
    public Sex GetSexFromBirthNumber(string birthNumber)
    {
        return int.Parse(birthNumber.Substring(2, 2)) > 50 ? Sex.Female : Sex.Male;
    }
}