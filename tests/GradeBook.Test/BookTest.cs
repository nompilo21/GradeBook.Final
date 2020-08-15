using NUnit.Framework;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace GradeBook.Tests
{
    public class BookTest
    {
        [Fact]
        public void BookCalculatesAverageGrade()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(84.5);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //expected 

            //actual
            var result = book.GetStatistics();

            //assert
            Assert.AreEqual(84.1, result.Average, 1);
            Assert.AreEqual(90.5, result.High, 1);
            Assert.AreEqual(77.3, result.Low, 1);
            Assert.AreEqual('B', result.letter);
        }
    }
}
