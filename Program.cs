using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            /* var p = new Program();
             * Program.Main(args);
             */ //this will loop infinitely till the program crashes.

            //create a new variable book which adds grades then computes the min, max and average grade
            var book = new Book("Nompilo gradebook");

            while (true)
            {
                //adding grades by user input
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                 
                if(input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                

            }
            

            //adding grades manually
            //book.AddGrade(84.5);
            //book.AddGrade(90.5);
            //book.AddGrade(77.3);
            //book.GetStatistics();

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter is {stats.letter}");

            /*Book book2 = new Book("mellow");
            book2.AddGrade(90.1);
            */
        }
    }
}

