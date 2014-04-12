using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrimeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PrimeLib.Tests
{
    [TestClass]
    public class RefactoringTests
    {
        /*[TestMethod]
        public void FormatLinesTest()
        {
            Assert.Fail();
        }*/

        private readonly string[] _codeBlocks =
        {
            "{0}BEGIN{1}{2}{3}END{4}", "{0}IFERR{1}{2}{3}END{4}", "{0}IF{1}{2}{3}END{4}", "{0}IF{1}{2}ELSE{3}END{4}", "{0}IFERR{1}{2}ELSE{3}END{4}",
            "{0}FOR X FROM 1 TO 10 DO{1}{2}{3}END{4}", "{0}FOR X FROM 1 TO 10 STEP 1 DO{1}{2}{3}END{4}", "{0}REPEAT{1}{2}{3}UNTIL 1{4}"
        };

        private const string CRLF = "\n\r", LineWithComments = "// Line with comments" + CRLF, IndentationString = "\t";

        [TestMethod]
        public void FormatLines_Simple_Test()
        {
            TestBlocksThatShouldNotChange(new object[] { String.Empty, ' ', String.Empty, String.Empty, ';' });
        }

        [TestMethod]
        public void FormatLines_Simple_Multiline_Test()
        {
            TestBlocksThatShouldNotChange(new object[] { String.Empty, String.Empty, String.Empty, CRLF, ';' });
        }

        [TestMethod]
        public void FormatLines_Simple_Multiline_With_Outer_Comments_Test()
        {
            TestBlocksThatShouldNotChange(new object[] { LineWithComments, String.Empty, String.Empty, CRLF, ';' + LineWithComments });
        }

        private void TestBlocksThatShouldNotChange(object[] args)
        {
            foreach (var l in _codeBlocks)
            {
                var tmp = String.Format(l, args);
                var original = new List<string>(tmp.Split(new[] { CRLF }, StringSplitOptions.None));
                var test = new List<string>(tmp.Split(new[] { CRLF }, StringSplitOptions.None));

                Refactoring.FormatLines(ref test, IndentationString);
                CollectionAssert.AreEqual(original, test);
            }
        }

        [TestMethod]
        public void FormatLines_IF_Sentence_Test()
        {
            // Test when is not indented
            FormatAndCheck(new[] { "IF TRUE THEN", "// NOP", "END;" }.ToList(), 
                new[] { "IF TRUE THEN", IndentationString+ "// NOP", "END;" }.ToList());

            // TODO: Should ELSE be considered as inside the IF?
            FormatAndCheck(new[] { "IF TRUE THEN", "// NOP","ELSE", "// NOP", "END;" }.ToList(),
                new[] { "IF TRUE THEN", IndentationString + "// NOP", IndentationString + "ELSE", IndentationString + "// NOP", "END;" }.ToList());

            // Test when is badly indented
            FormatAndCheck(new[] {"IF TRUE THEN", IndentationString + IndentationString + "// NOP", "END;"}.ToList(),
                new[] {"IF TRUE THEN", IndentationString + "// NOP", "END;"}.ToList());
        }

        [TestMethod]
        public void FormatLines_IFERR_Sentence_Test()
        {
            // Test when is not indented
            FormatAndCheck(new[] { "IFERR TRUE THEN", "// NOP", "END;" }.ToList(),
                new[] { "IFERR TRUE THEN", IndentationString + "// NOP", "END;" }.ToList());

            // TODO: Should ELSE be considered as inside the IF?
            FormatAndCheck(new[] { "IFERR TRUE THEN", "// NOP", "ELSE", "// NOP", "END;" }.ToList(),
                new[] { "IFERR TRUE THEN", IndentationString + "// NOP", IndentationString + "ELSE", IndentationString + "// NOP", "END;" }.ToList());

            // Test when is badly indented
            FormatAndCheck(new[] { "IFERR TRUE THEN", IndentationString + IndentationString + "// NOP", "END;" }.ToList(),
                new[] { "IFERR TRUE THEN", IndentationString + "// NOP", "END;" }.ToList());
        }

        [TestMethod]
        public void FormatLines_FOR_Sentence_Test()
        {
            // Pending
        }

        [TestMethod]
        public void FormatLines_BEGIN_Sentence_Test()
        {
            // Test when is not indented
            FormatAndCheck(new[] { "BEGIN", "// NOP", "END;" }.ToList(),
                new[] { "BEGIN", IndentationString + "// NOP", "END;" }.ToList());

            // TODO: Should ELSE be considered as inside the IF?
            FormatAndCheck(new[] { "BEGIN", "// NOP", "ELSE", "// NOP", "END;" }.ToList(),
                new[] { "BEGIN", IndentationString + "// NOP", IndentationString + "ELSE", IndentationString + "// NOP", "END;" }.ToList());

            // Test when is badly indented
            FormatAndCheck(new[] { "BEGIN", IndentationString + IndentationString + "// NOP", "END;" }.ToList(),
                new[] { "BEGIN", IndentationString + "// NOP", "END;" }.ToList());
        }

        [TestMethod]
        public void FormatLines_REPEAT_Sentence_Test()
        {
            // Pending
        }

        [TestMethod]
        public void FormatLines_WHILE_Sentence_Test()
        {
            // Pending
        }

        private static void FormatAndCheck(List<string> actual, List<string> expected)
        {
            Refactoring.FormatLines(ref actual, IndentationString);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
