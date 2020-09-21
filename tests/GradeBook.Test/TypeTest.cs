using NUnit.Framework;
using System;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace GradeBook.Test
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTest
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;
            var result = log("hey");
            Assert.AreEqual(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void PassByValueTest()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.AreEqual(42, x);
        }
        private int GetInt()
        {
            return 3;
        }
        private void SetInt(ref int z)
        {
            z = 42;
        }

        [Fact]
        //passing a parameter to a method 2
        public void CSharpIsCanPassByRef()
        {
            var book1 = GetBook("BOOK 1");
            GetBookSetName(ref book1, "BOOK 1");

            Assert.AreEqual("BOOK 1", book1.Name);
        }
        //Passing parameter by reference
        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        //passing a parameter to a method 
        public void CSharpIsCanPassByValue()
        {
            var book1 = GetBook("BOOK 1");
            GetBookSetName1(book1, "New Name");

            Assert.AreEqual("BOOK 1", book1.Name);
        }
        //Passing a parameter to a method 1
        private void GetBookSetName1(Book book, String name)
        {
            book = new Book(name);
        }
        [Fact]
        //passing a parameter to a method 2
        public void CSharpIsPassedByValue()
        {
            var book1 = GetBook("BOOK 1");
            GetBookSetName2(book1, "New Name");

            Assert.AreEqual("BOOK 1", book1.Name);
        }
        //Passing a parameter to a method 1
        private void GetBookSetName2(Book book, String name)
        {
            book = new Book(name);
        }

        [Fact]
        //passing a parameter to a method 2
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("BOOK 1");
            SetName(book1, "BOOK 1");

            Assert.AreEqual("BOOK 1", book1.Name);
        }
        //Passing a parameter to a method 1
        private void SetName(Book book, String name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("BOOK 1");
            var book2 = GetBook("BOOK 2");

            Assert.AreEqual("BOOK 1", book1.Name);
            Assert.AreEqual("BOOK 2", book2.Name);
            Assert.AreNotSame(book1, book2);
        }

        [Fact]
        //Two different variables that reference the same object
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("BOOK 1");
            var book2 = book1;

            Assert.AreSame(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Nompilo";
            var upper = MakeUpperCase(name);

            //Assert.Equal("Nompilo", name);
            Assert.AreEqual("NOMPILO", upper);
        }

        private String MakeUpperCase(string name)
        {
            return name.ToUpper();
        }


    }

}
