using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithQuizzes
{
    public class TrueOrFalse : Question
    {
        public List<char> possibleAnswersKey = new List<char>();
        public char userAnswer;
        public int score;

        public TrueOrFalse() { }
        public TrueOrFalse(string questionPrompt, Dictionary<char, string> correctAnswer)
        {
            this.QuestionType = "True Or False";
            this.Prompt = questionPrompt;
            this.CorrectAnswer = correctAnswer;
            this.PossibleAnswers = new Dictionary<char, string> { {'A', "true" }, {'B', "false" } };
            foreach (KeyValuePair<char, string> answer in PossibleAnswers)
            {
                this.possibleAnswersKey.Add(answer.Key);
            }
        }
        public override void GetUserAnswer()
        {
            Console.WriteLine("Select one of the possible choices:");
            PrintAnswerList(possibleAnswersKey);
            string userInput = Console.ReadLine().ToUpper();
            char userInputChar;
            while (!char.TryParse(userInput, out userInputChar))
            {
                Console.WriteLine("Enter a valid character");
                GetUserAnswer();
            }
            userInputChar = char.Parse(userInput);
            while (!possibleAnswersKey.Contains(userInputChar))
            {
                Console.WriteLine("Select a valid character.");
                GetUserAnswer();
            }
            userAnswer = userInputChar;
            //userAnswer = ValidateInputChar(userInput);
        }
        public void PrintAnswerList(List<char> answerList)
        {
            foreach (char answer in answerList)
            {
                Console.WriteLine(answer);
            }
        }
        public override int GradeQuestion()
        {
            if (CorrectAnswer.ContainsKey(userAnswer))
            {
                score++;
            }
            return score;
        }
    }
}
