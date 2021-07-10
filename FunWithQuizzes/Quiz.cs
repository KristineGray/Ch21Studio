﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithQuizzes
{
    public class Quiz
    {
        public List<Question> Questions = new List<Question>();
        //List<Question> defaultQs = new List<Question> {new TrueOrFalse("Is H2O water?", new Dictionary<char, string> { {'A', "true"} }), new MultipleChoice("What is the square root of 4?", new Dictionary<char, string> { { 'B', "Two"} }, new Dictionary<char, string> { { 'A', "One"}, { 'B', "Two"}, { 'C', "Three"}, { 'D', "Four"} }), new Checkbox("Which word(s) is an animal?", new Dictionary<char, string> {{ 'A', "Cat"}, { 'B', "Dog"}, { 'D', "Mouse"} }, new Dictionary<char, string> { { 'A', "Cat"}, { 'B', "Dog"}, { 'C', "Box"}, { 'D', "Mouse"}, { 'E', "Coffee"} })};
        
        public int totalScore;
        public int maxScore;
        public double gradePercentage;


        public Quiz() { }
        public Quiz(List<Question> questions)
        {
            this.Questions = questions;
        }

        public void GetMaxScore()
        {
            foreach (Question question in Questions)
            {
                int points = question.CorrectAnswer.Count;
                maxScore += points;
            }
        }

        public void UserOptions ()
        {
            Console.Clear();
            Console.WriteLine("1 - See current list of questions\n2 - Add a question\n3 - Remove a question\n4 - Run the quiz");
            int userSelection = int.Parse(Console.ReadLine());
            switch (userSelection)
            {
                case 1:
                    PrintQuestions(Questions);
                    break;
                case 2:
                    AddQuestion();
                    break;
                case 3:
                    RemoveQuestion();
                    break;
                case 4:
                default:
                    RunQuiz();
                    break;
            }
        }

        public void AddQuestion()
        {
            Console.Clear();
            Console.WriteLine("Which type of question would you like to add?");
            Console.WriteLine("1. True or False\n2. Checkbox\n3. Multiple Choice");
            string userInput = Console.ReadLine();
            int userChoice;
            while (!int.TryParse(userInput, out userChoice))
            {
                AddQuestion();
            }
            while (userChoice < 1 || userChoice > 3)
            {
                AddQuestion();
            }
            if (userChoice == 1)
            {
                Console.WriteLine("What is your true or false question?");
                string qPrompt = Console.ReadLine();
                Console.WriteLine("\nIs the correct answer true or false?");
                string isTrue = Console.ReadLine();
                bool isBoolTrue;
                while (!bool.TryParse(isTrue, out isBoolTrue)) 
                {
                    Console.WriteLine("true or false...");
                    isTrue = Console.ReadLine();
                }
                isBoolTrue = bool.Parse(isTrue);
                char answerKey;
                string answerValue;
                if (isBoolTrue)
                {
                    answerKey = 'A';
                    answerValue = "True";
                }
                else
                {
                    answerKey = 'B';
                    answerValue = "False";
                }
                Questions.Add(new TrueOrFalse(qPrompt, new Dictionary<char, string> { { answerKey, answerValue } }));
            }
            else if (userChoice == 2)
            {
                Console.WriteLine("What is your checkbox question?");
                string qPrompt = Console.ReadLine();
                Console.WriteLine("How many possible answers will there be for this question?");
                int numPossAnswers = int.Parse(Console.ReadLine());

                Dictionary<char, string> addPossAnswers = new Dictionary<char, string>();
                Dictionary<char, string> addCorrectAnswers = new Dictionary<char, string>();
                for (int i = 0; i < numPossAnswers; i++)
                {
                    char key = (char)('A' + i);
                    Console.WriteLine($"What is possible answer {key}");
                    string value = Console.ReadLine();
                    addPossAnswers.Add(key, value);
                    Console.WriteLine("\nIs this a correct answer?");
                    string addingToCorrectDict = Console.ReadLine();
                    if (addingToCorrectDict == "yes" || addingToCorrectDict == "y")
                    {
                        addCorrectAnswers.Add(key, value);
                    }
                }

                Questions.Add(new Checkbox(qPrompt, addCorrectAnswers, addPossAnswers));
            }
            else
            {
                Console.WriteLine("What is your multiple choice question?");
                string qPrompt = Console.ReadLine();

                Console.WriteLine("How many possible answers will there be for this question?");
                int numPossAnswers = int.Parse(Console.ReadLine());

                Dictionary<char, string> addPossAnswers = new Dictionary<char, string>();
                Dictionary<char, string> addCorrectAnswers = new Dictionary<char, string>();
                for (int i = 0; i < numPossAnswers; i++)
                {
                    char key = (char)('A' + i);
                    Console.WriteLine($"What is possible answer {key}");
                    string value = Console.ReadLine();
                    addPossAnswers.Add(key, value);
                    if (addCorrectAnswers.Count < 1)
                    {
                        Console.WriteLine("\nIs this a correct answer?");
                        string addingToCorrectDict = Console.ReadLine();
                        if (addingToCorrectDict == "yes" || addingToCorrectDict == "y")
                        {
                            addCorrectAnswers.Add(key, value);
                        }
                    }
                }

                Questions.Add(new MultipleChoice(qPrompt, addCorrectAnswers, addPossAnswers));
            }
            PressToContinue();
            UserOptions();
        }

        public void RemoveQuestion()
        {
            Console.Clear();
            Console.WriteLine($"Which of the above questions would you like to remove? 1-{Questions.Count}");
            Console.WriteLine("\n=================\n");
            foreach (Question question in Questions)
            {
                question.PrintQuestion();
            }
            Console.WriteLine("\n=================");
            int removeQ = int.Parse(Console.ReadLine());
            Console.WriteLine($"Removing question: {Questions[removeQ - 1]}");
            Questions.RemoveAt(removeQ - 1);
            PressToContinue();
            UserOptions();
        }

        public void PrintQuestions(List<Question> questions)
        {
            Console.Clear();
            foreach(Question question in questions)
            {
                Console.WriteLine($"{question.ID}. {question.Prompt}");
                question.PrintPossibleAnswers();
                Console.WriteLine();
            }
            PressToContinue();
            UserOptions();
        }

        public void RunQuiz()
        {
            GetMaxScore();
            Console.Clear();
            Console.WriteLine("\n===== QUIZ =====\n");
            foreach (Question question in Questions)
            {
                question.PrintQuestion();
                Console.WriteLine(); //Spacing
                if (question.QuestionType == "True Or False")
                {
                    (question as TrueOrFalse).GetUserAnswer();
                    totalScore += (question as TrueOrFalse).GradeQuestion();
                }
                else if (question.QuestionType == "Checkbox")
                {
                    (question as Checkbox).GetUserAnswer();
                    totalScore += (question as Checkbox).GradeQuestion();
                }
                else if (question.QuestionType == "Multiple Choice")
                {
                    (question as MultipleChoice).GetUserAnswer();
                    totalScore += (question as MultipleChoice).GradeQuestion();
                }
                Console.WriteLine("\n"); //Spacing
            }
            GradeQuiz();
            PressToContinue();
        }

        public void GradeQuiz()
        {
            gradePercentage = (totalScore / maxScore) * 100;
            Console.WriteLine($"Grade: {Math.Round(gradePercentage, 2)}%. You earned {totalScore} out of {maxScore} points.");
        }

        public void PressToContinue()
        {
            Console.WriteLine("\n\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
