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
            this.QuestionType = "True/False";
            this.Prompt = questionPrompt;
            this.CorrectAnswer = correctAnswer;
            this.PossibleAnswers = new Dictionary<char, string> { {'A', "true" }, {'B', "false" } };
            foreach (KeyValuePair<char, string> answer in PossibleAnswers)
            {
                this.possibleAnswersKey.Add(answer.Key);
            }
        }
        public void GetUserAnswer()

        {
            /*
            Console.WriteLine("Enter A or B");
            string userInput = Console.ReadLine();
            this.userAnswer = userInput.ToUpper();
            */
            char userInputChar;
            Console.WriteLine($"Select one of the possible choices: {possibleAnswersKey}");
            string userInput = Console.ReadLine().ToUpper();
            while (!char.TryParse(userInput, out userInputChar))
            {
                Console.WriteLine("Enter a valid character");
                this.GetUserAnswer();
            }
            userInputChar = char.Parse(userInput);
            while (!this.possibleAnswersKey.Contains(userInputChar))
            {
                Console.WriteLine("Select a valid character.");
                this.GetUserAnswer();
            }
            this.userAnswer = userInputChar;
        }
        public override int GradeQuestion()
        {
            if (this.CorrectAnswer.ContainsKey(this.userAnswer)) this.score++;
            return score;
            /*
            this.userCharAnswer = char.Parse(userAnswer);
            foreach (KeyValuePair<char, string> correct in CorrectAnswer)
            {
                if (this.userCharAnswer == correct.Key) 
                    this.score++;
            }
            return this.score;
            */
        }
    }
}
