using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimeCommTest
{
    [TestClass]
    public class PrimeLibRefactoringTests
    {
        private readonly string[] _codeBlocks =
        {
            "{0}BEGIN{1}{2}{3}END{4}", "{0}IFERR{1}{2}{3}END{4}", "{0}IF{1}{2}{3}END{4}", "{0}IF{1}{2}ELSE{3}END{4}", "{0}IFERR{1}{2}ELSE{3}END{4}",
            "{0}FOR X FROM 1 TO 10 DO{1}{2}{3}END{4}", "{0}FOR X FROM 1 TO 10 STEP 1 DO{1}{2}{3}END{4}", "{0}REPEAT{1}{2}{3}UNTIL 1{4}"
        };

        [TestMethod]
        public void TestWellFormedSimpleOneLinerCodeIndentation()
        {
            TestBlocksThatShouldNotChange(new object[] {String.Empty, ' ', String.Empty, String.Empty, ';'});
        }

        [TestMethod]
        public void TestWellFormedSimpleMultilineCodeIndentation()
        {
            TestBlocksThatShouldNotChange(new object[] { String.Empty, '\n', String.Empty, String.Empty, ';' });
        }

        private void TestBlocksThatShouldNotChange(object[] args)
        {
            foreach (var l in _codeBlocks)
            {
                var tmp = String.Format(l, args);
                var original = new List<string>(tmp.Split(new[] {'\r'}));
                var test = new List<string>(tmp.Split(new[] {'\r'}));

                Refactoring.FormatLines(ref test, "\t");
                CollectionAssert.AreEqual(original, test);
            }
        }
    }
}
