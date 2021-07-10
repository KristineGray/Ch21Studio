using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithQuizzes
{
    public class MultipleChoice : Question
    {
        public List<char> possibleAnswersKey = new List<char>();
        public char userAnswer;
        public int score;

        public MultipleChoice() { }
        public MultipleChoice(string questionPrompt, Dictionary<char, string> correctAnswer, Dictionary<char, string> possibleAnswers)
        {
            this.QuestionType = "Multiple Choice";
            this.Prompt = questionPrompt;
            this.CorrectAnswer = correctAnswer;
            this.PossibleAnswers = possibleAnswers;
            foreach (KeyValuePair<char, string> answer in PossibleAnswers)
            {
                this.possibleAnswersKey.Add(answer.Key);
            }
        }

        public override void GetUserAnswer()
        {
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
            
            //userAnswer = 'A';
        }

        public override int GradeQuestion()
        {
            if (this.CorrectAnswer.ContainsKey(this.userAnswer)) this.score++;
            return score;
        }
        public override void PrintUserAnswers()
        {
            Console.WriteLine($"\nYour answer: {userAnswer}");
        }
    }
}
