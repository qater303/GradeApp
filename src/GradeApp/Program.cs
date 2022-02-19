using System;
using System.Collections.Generic;
using System.IO;

namespace GradeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TvSeries tvSeries1 = new TvSeries("Cobra Kai", "obyczajowy");
            tvSeries1.AddSeason();
            tvSeries1.AddSeason();
            tvSeries1.GradeAdded += LowGradeAdded;
            tvSeries1.GradeAdded += HighGradeAdded;
            tvSeries1.GradeAdded += AnyGradeAdded;

            InFileMovie inFileMovie1 = new InFileMovie("The Matrix", "sci-fi");
            inFileMovie1.GradeAdded += LowGradeAdded;
            inFileMovie1.GradeAdded += HighGradeAdded;
            inFileMovie1.GradeAdded += AnyGradeAdded;

            GetAllMoviesAndTvSeries();

            // Oceny serialu
            System.Console.WriteLine($"Dodaj oceny dla serialu: {tvSeries1.Tittle}");

            System.Console.WriteLine("Podaj swoje oceny- Aby wyjść naciśnij 'q'");
            while (true)
            {
                System.Console.WriteLine($"Podaj sezon serialu: {tvSeries1.Tittle}");
                var actualSeason = Console.ReadLine();
                if (actualSeason == "q")
                {
                    break;
                }
                try
                {
                    tvSeries1.SetActualSeason(int.Parse(actualSeason));
                }
                catch (Exception exp)
                {
                    System.Console.WriteLine(exp.Message);
                    break;
                }
                System.Console.WriteLine("Podaj ocenę");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    tvSeries1.AddGrade(input);
                }
                catch (Exception exp)
                {
                    System.Console.WriteLine(exp.Message);
                }
            }
            System.Console.WriteLine("Podaj sezon dla któego wyświetlić statystyki");
            var actualSeasonStat = Console.ReadLine();
            try
            {
                PrintStatistics(tvSeries1, int.Parse(actualSeasonStat));
                Console.ReadKey();
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
                Console.ReadKey();
            }


            //Oceny filmu
            System.Console.WriteLine($"Dodaj oceny dla filmu {inFileMovie1.Tittle}");
            System.Console.WriteLine("Podaj swoje oceny- Aby wyjść naciśnij 'q'");
            while (true)
            {
                System.Console.WriteLine("Podaj ocenę");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    inFileMovie1.AddGrade(input);
                }
                catch (Exception exp)
                {
                    System.Console.WriteLine(exp.Message);
                }
            }
            try
            {
                PrintStatistics(inFileMovie1, 0);
                Console.ReadKey();
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
                Console.ReadKey();
            }
        }

        static void GetAllMoviesAndTvSeries()
        {
            var listOfMovies = new List<string>();
            string[] filesList = Directory.GetFiles(@".", "*.txt");

            foreach (string s in filesList)
            {
                listOfMovies.Add(Path.GetFileNameWithoutExtension(s));
            }
            System.Console.WriteLine("Lista istniejących filmów");
            for (int i = 0; i < listOfMovies.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}-{listOfMovies[i]}");
            }
        }
        static void PrintStatistics(IMovie movie, int seasonNumber)
        {
            if (movie is TvSeries)
            {
                System.Console.WriteLine($"Statystyki dla serialu: {movie.Tittle} sezon: {seasonNumber}");
            }
            else if (movie is InFileMovie)
            {
                System.Console.WriteLine($"Statystyki dla filmu: {movie.Tittle}");
            }

            var stat = movie.GetStatistics();
            System.Console.WriteLine($"Ogólna ocena: {stat.Stars}");
            System.Console.WriteLine($"Średnia ocen: {stat.Average}");
            System.Console.WriteLine($"Najwyższa ocena: {stat.High}");
            System.Console.WriteLine($"Najniższa ocena: {stat.Low}");
        }
        static void LowGradeAdded(object sender, MovieGradeAddedEventArgs args)
        {
            if (args.Grade < 3)
            {
                Console.WriteLine("Szkoda, że  nie podobał Ci się seans");
            }
        }
        static void AnyGradeAdded(object sender, MovieGradeAddedEventArgs args)
        {
            System.Console.WriteLine("Dzięki za ocenę !!");
        }
        static void HighGradeAdded(object sender, MovieGradeAddedEventArgs args)
        {
            if (args.Grade == 10)
            {
                System.Console.WriteLine("Dzięki za njawyższą ocenę");
            }
        }
    }
}
