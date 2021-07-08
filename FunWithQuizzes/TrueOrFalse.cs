using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithQuizzes
{
    public class TrueOrFalse : Question
    {
        string userAnswer;
        public int score;

        public TrueOrFalse() { }
        public TrueOrFalse(string questionPrompt, Dictionary<char, string> correctAnswer, string questionType="True/False")
        {
            this.QuestionType = questionType;
            this.Prompt = questionPrompt;
            this.CorrectAnswer = correctAnswer;
            this.PossibleAnswers = new Dictionary<char, string> {
                {'A', "true" },
                {'B', "false" }
            };
        }
        public void GetUserAnswer()
        {
            Console.WriteLine("True / False?");
            userAnswer = "false";
            //userAnswer = Console.ReadLine().ToLower();
        }
        public override int GradeQuestion()
        {
            foreach (KeyValuePair<char, string> correct in CorrectAnswer)
            {
                if (userAnswer == correct.Value) 
                    score++;
            }
            return score;
        }
    }
}
