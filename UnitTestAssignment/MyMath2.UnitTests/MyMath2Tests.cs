using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MyMathConsoleApp;

namespace MyMath2.UnitTests
{
    [TestFixture]
    public class MyMath2Tests
    {
        [Test]
        public void Add_SumWithinByteRange_ReturnCorrectSum()
        {
            Assert.That(MyMathConsoleApp.MyMath2.Add(101, 99), Is.EqualTo(200)); ;
        }

        [Test]
        public void Add_SumOutsideByteRange_ThrowsException()
        {
            Assert.That(() => MyMathConsoleApp.MyMath2.Add(101, 201), Throws.Exception);
        }


    }
}
