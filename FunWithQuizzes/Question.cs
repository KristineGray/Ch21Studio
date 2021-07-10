using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithQuizzes
{
    public abstract class Question
    {
        private int _id;
        private static int QuestID = 0;
        public int totalScore;

        public int ID { get { return _id; } }
        public string QuestionType { get; set; }
        public string Prompt { get; set; }
        public Dictionary<char, string> CorrectAnswer { get; set; }
        public Dictionary<char, string> PossibleAnswers { get; set; }

        public Question()
        {
            QuestID++;
            _id = QuestID;
        }

        public void PrintQuestion()
        {
            Console.WriteLine($"{ID}: {Prompt}");
            PrintPossibleAnswers();
            Console.WriteLine();
        }
        public void PrintPossibleAnswers()
        {
            foreach (KeyValuePair<char, string> answer in PossibleAnswers)
            {
                Console.WriteLine($"{answer.Key}. {answer.Value}");
            }
        }
        public void PrintCorrectAnswer()
        {
            Console.WriteLine("Correct answer(s):");
            foreach (KeyValuePair<char, string> answer in CorrectAnswer)
            {
                Console.WriteLine($"{answer.Key}. {answer.Value}");
            }
        }
        public Dictionary<char, string> GetCorrectAnswer()
        {
            return CorrectAnswer;
        }
        public abstract int GradeQuestion();
        public abstract void GetUserAnswer();
        public abstract void PrintUserAnswers();
    }
}
