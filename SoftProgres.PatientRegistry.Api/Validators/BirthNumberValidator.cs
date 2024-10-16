namespace SoftProgres.PatientRegistry.Api.Validators;

public class BirthNumberValidator : IBirthNumberValidator
{
    /// <summary>
    /// Implementácia validácie rodného čísla podľa zákona 301/1995 Z. z. o rodnom čísle § 2
    /// </summary>
    /// <param name="birthNumber">Vstupné rodné číslo. Za správny vstupný formát sa považuje RČ s lomkou aj bez lomky.</param>
    /// <returns>True ak je rodné číslo v správnom formáte a validné podľa zákona, inak false.</returns>
    public bool IsBirthNumberValid(string birthNumber)
    {
        // Odstránenie lomítka
        string cleanBirthNumber = birthNumber.Replace("/", "");

        // Kontrola dĺžky rodného čísla. Rodné čislo by malo mať 9, alebo 10 znakov
        if (cleanBirthNumber.Length != 9 && cleanBirthNumber.Length != 10)
        {
            return false;
        }

        // prevod rodného čísla typu string na long a zároveň kontrola čí rodné číslo obsahuje iba čísla
        long cleanBirthNumberInt;
        if (!long.TryParse(cleanBirthNumber, out cleanBirthNumberInt))
        {
            return false;
        }

        // kontrola deliteľnosti rodného čísla 11 po roku 1954
        if (cleanBirthNumber.Length == 10 && cleanBirthNumberInt % 11 != 0)
        {
            return false;
        }

        // rozdelenie roku narodenia na rok, mesiac a dní
        int year = int.Parse(cleanBirthNumber.Substring(0, 2));
        int month = int.Parse(cleanBirthNumber.Substring(2, 2));
        int day = int.Parse(cleanBirthNumber.Substring(4, 2));

        // Ženy majú mesiace navýšené o 50
        month -= (month > 50) ? 50 : 0;

        // Určenie plného roku
        year += (cleanBirthNumber.Length == 9) ? 1900 : 2000;

        // kontrola platnosti dátumu narodenia
        try
        {
            DateTime birthDate = new DateTime(year, month, day);
        }
        catch
        {
            return false; 
        }

        return true;
    }
}