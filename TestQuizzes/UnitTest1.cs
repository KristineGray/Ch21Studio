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
            Assert.AreEqual(5, testTFTwo.ID);
        }
        [TestMethod]
        public void TestTrueOrFalsePromptQuestion()
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

        [TestMethod]
        public void TestCheckboxPossibleAnswers()
        {
            Dictionary<char, string> testPossibleAnswers = new Dictionary<char, string> { { 'A', "One" }, { 'B', "Two" }, { 'C', "Three" }, { 'D', "Four" } };
            Checkbox testCBOne = new Checkbox("Which of the below are even numbers between 1 and 5?", new Dictionary<char, string> { { 'B', "Two"}, { 'D', "Four" } }, testPossibleAnswers);
            foreach (KeyValuePair<char, string> answer in testCBOne.PossibleAnswers)
            {
                Assert.AreEqual(testPossibleAnswers[answer.Key], answer.Value);
            }
        }
        
        [TestMethod]
        public void TestCheckboxGradeQuestion()
        {
            Dictionary<char, string> testPossibleAnswers = new Dictionary<char, string> { { 'A', "One" }, { 'B', "Two" }, { 'C', "Three" }, { 'D', "Four" } };
            Checkbox testCBTwo = new Checkbox("What is the number between 1 and 3?", new Dictionary<char, string> { { 'B', "Two"} }, testPossibleAnswers);
            testCBTwo.GetUserAnswer();
            Assert.AreEqual(1, testCBTwo.GradeQuestion());
        }
        
    }
}
