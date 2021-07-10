using System;
using System.Collections.Generic;

namespace FunWithQuizzes
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Project should:
                1. create several questions, 
                2. present them to the user, 
                3. accept the user’s responses, and then 
                4. tell them whether their answers were correct or incorrect
             */
            List<Question> defaultQs = new List<Question> { new TrueOrFalse("Is H2O water?", new Dictionary<char, string> { { 'A', "true" } }), new MultipleChoice("What is the square root of 4?", new Dictionary<char, string> { { 'B', "Two" } }, new Dictionary<char, string> { { 'A', "One" }, { 'B', "Two" }, { 'C', "Three" }, { 'D', "Four" } }), new Checkbox("Which word(s) is an animal?", new Dictionary<char, string> { { 'A', "Cat" }, { 'B', "Dog" }, { 'D', "Mouse" } }, new Dictionary<char, string> { { 'A', "Cat" }, { 'B', "Dog" }, { 'C', "Box" }, { 'D', "Mouse" }, { 'E', "Coffee" } }) };

            Quiz quiz = new Quiz(defaultQs);
            quiz.UserOptions();
        }
    }
}
