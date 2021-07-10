using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithQuizzes
{
    public class Checkbox : Question
    {
        public int score;
        public List<char> userAnswers = new List<char>();
        public List<char> possibleAnswersKey = new List<char>();

        public Checkbox(string questionPrompt, Dictionary<char, string> correctAnswers, Dictionary<char, string> possibleAnswers)
        {
            this.QuestionType = "Checkbox";
            this.Prompt = questionPrompt;
            this.CorrectAnswer = correctAnswers;
            this.PossibleAnswers = possibleAnswers;
            foreach (KeyValuePair<char, string> possAnswer in PossibleAnswers)
            {
                possibleAnswersKey.Add(possAnswer.Key);
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
                GetUserAnswer();
            }
            userInputChar = char.Parse(userInput);
            while (!possibleAnswersKey.Contains(userInputChar))
            {
                Console.WriteLine("Select a valid character.");
                GetUserAnswer();
            }
            if (!userAnswers.Contains(userInputChar))
            {
                userAnswers.Add(userInputChar);
            }
            Console.WriteLine("Would you like to select another choice?");
            string selectAnother = Console.ReadLine().ToLower();
            if (selectAnother == "yes" || selectAnother == "y" || selectAnother == "yeah" || selectAnother == "ye" || selectAnother == "yea")
            {
                GetUserAnswer();
            }
            
            //userAnswers.Add('B');
        }
        public override int GradeQuestion()
        {
            foreach (KeyValuePair<char, string> answer in CorrectAnswer)
            {
                if (userAnswers.Contains(answer.Key)) score++;
            }
            return score;
        }
    }
}
