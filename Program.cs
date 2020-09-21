using System;

namespace GradeBook
{
    class Program
    {

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        private static void EnterGrades(ref Book book)
        {
            while (true)
            {
                //adding grades by user input
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                //catching exceptions
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    Console.WriteLine("correct grade");
                }


            }
        }

        static void Main(string[] args)
        {
            /* var p = new Program();
             * Program.Main(args);
             */ //this will loop infinitely till the program crashes.

            //create a new variable book which adds grades then computes the min, max and average grade
            var book = new Book("Nompilo gradebook");
            //handle gradebook event
            book.GradeAdded += OnGradeAdded;
            //book.GradeAdded -= OnGradeAdded;

            EnterGrades(ref book);



            //adding grades manually
            //book.AddGrade(84.5);
            //book.AddGrade(90.5);
            //book.AddGrade(77.3);
            //book.GetStatistics();

            var stats = book.GetStatistics();
            //book.Name = "";

            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter is {stats.letter}");
            Console.WriteLine(Book.Category);

            /*Book book2 = new Book("mellow");
            book2.AddGrade(90.1);
            */
        }
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("grade added");
        }
    }
}

