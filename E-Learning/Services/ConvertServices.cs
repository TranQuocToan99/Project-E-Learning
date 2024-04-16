using E_Learning.Models;
using System.ComponentModel;

namespace E_Learning.Services
{
    public static class ConvertServices
    {
        public static string ConvertDayToString(this Day dayOfWeek)
        {
            return dayOfWeek switch
            {
                Day.Monday => "Monday",
                Day.Tuesday => "Tuesday",
                Day.Thursday => "Thursday",
                Day.Wednesday => "Wednesday",
                Day.Friday => "Friday",
                Day.Saturday => "Saturday",
                Day.Sunday => "Sunday",
                _ => throw new InvalidEnumArgumentException()
            } ;
        }

        public static string ConvertSectionToString(this Section sectionType)
        {
            return sectionType switch
            {
                Section.Section1 => "7h30 - 9h30",
                Section.Section2 => "9h30 - 11h30",
                Section.Section3 => "12h30 - 14h30",
                Section.Section4 => "14h30 - 16h30",
                _ => throw new InvalidEnumArgumentException()
            };
        }

        public static string ConvertClassifyToString(this Classify classType)
        {
            return classType switch
            {
                Classify.Theory => "Theory",
                Classify.Pratice => "Pratical",
                _ => throw new InvalidEnumArgumentException()
            };
        }
    }
}
