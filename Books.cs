using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject: Object
        //inheritance base class
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public class Book: NamedObject //inheritance
    {
        //add constructor with parameter...note a constructor has no return type
        public Book(string name) : base(name)
        {
            //method for class book which creates a list of the double property.
            grades = new List<double>();
            //uses this to store the variable name to the instance or field name declared in the code.
            Name = name;
        }

        //Method to add letter grade, eg) A, B or C
        //Switch statements
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                default:
                    AddGrade(0);
                    break;

            }
        }

        //add method
        public void AddGrade(double grade)
        {
            //method for class book which adds grade of the double property.
            //learning about if statements
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                //throwing exceptions
                throw new ArgumentException($"invalid {nameof(grade)}");
            }

        }



        public event GradeAddedDelegate GradeAdded;

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            //var index = 0;
            foreach (var grade in grades)
            {
                //jumping with break and continue
                //if (grades[index] == 42.1)
                //{
                //break;
                //continue;
                //goto done;
                //you can either break or continue or goto done(generally where code execution ends)
                //}
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            //assign each grade to a symbol
            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.letter = 'D';
                    break;

                default:
                    result.letter = 'F';
                    break;

            }
            //done;
            return result;
        }
        //add field
        private List<double> grades;
        //defining properties using getters and setters
        public const string Category = "science";
    }
}

