using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FunWithQuizzes;

namespace TestQuizzes
{
    [TestClass]
    public class UnitTest1
    {
        /*
        [TestMethod]
        public void TestQuestionID()
        {
            Question testQuestionOne = new Question();
            Question testQuestionTwo = new Question();
            Question testQuestionThree = new Question();
            Assert.AreEqual(1, testQuestionOne.ID);
            Assert.AreEqual(2, testQuestionTwo.ID);
            Assert.AreEqual(3, testQuestionThree.ID);
            Assert.IsFalse(testQuestionOne.ID == testQuestionTwo.ID);
        }
        */
        [TestMethod] //Gotta watch which order in testing playlist this one is
        public void TestTrueOrFalseID()
        {
            TrueOrFalse testTFOne = new TrueOrFalse();
            TrueOrFalse testTFTwo = new TrueOrFalse();
            Assert.AreEqual(3, testTFTwo.ID);
        }
        [TestMethod]
        public void TestTrueOrFalsePrintQuestion()
        {
            Assert.AreEqual("Is this a test?", new TrueOrFalse("Is this a test?", new Dictionary<char, string> { { 'A', "true" } }).Prompt);
        }
        [TestMethod]
        public void TestTrueOrFalseGradeQuestion() 
        {
            //Remember to switch commented line from 28 to 27 after testing before actual use
            TrueOrFalse testTFThree = new TrueOrFalse("Is this a graded test?", new Dictionary<char, string> { { 'A', "true" } });
            testTFThree.GetUserAnswer();
            Assert.AreEqual(0, testTFThree.score);
        }
    }
}
