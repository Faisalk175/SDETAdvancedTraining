namespace LambdaLab_Lib
{
    public class Exercsises
    {
        public static int CountTotalNumberOfSpartans(List<Spartan> spartans) => spartans.Count;

        public static int CountTotalNumberOfSpartansInUKAndUSA(List<Spartan> spartans)
            => spartans.Where(s => s.Country == "U.K." || s.Country == "U.S.A.").Count();

        public static int NumberOfSpartansBornAfter1980(List<Spartan> spartans)
            => spartans.Where(s => s.DateOfBirth > new DateOnly(1980, 1, 1)).Count();

        public static int SumOfAllSpartaMarksMoreThan50Inclusive(List<Spartan> spartans) 
            => spartans.Where(s => s.SpartaMark >= 50).Sum(s => s.SpartaMark);

        //To 2 decimal points
        public static double AverageSpartanMark(List<Spartan> spartans) 
            => Math.Round(spartans.Average(s => s.SpartaMark),2);

        public static List<Spartan> SortByAlphabeticallyByLastName(List<Spartan> spartans) 
            => spartans.OrderBy(s => s.LastName).ToList();

        public static List<string> ListAllDistinctCities(List<Spartan> spartans) 
            => spartans.Select(s => s.City).Distinct().ToList();

        public static List<Spartan> ListAllSpartansWithIdBeginingWithB(List<Spartan> spartans)
            => spartans.Where(s => s.SpartanId[0] == 'B').ToList();
    }
}