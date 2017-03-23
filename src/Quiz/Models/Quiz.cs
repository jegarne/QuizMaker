using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class Quiz
    {
        private Regex rgx = new Regex("[^a-zA-Z]");

        private Dictionary<int, string> userAnswers = new Dictionary<int, string>();  // holds question number and choice text
        public Dictionary<int, Question> Questions { get; set; } = new Dictionary<int, Question>();


        /// <summary>
        /// Sets the user's answer so it can be graded.
        /// </summary>
        /// <param name="questionNumber">the number of the answered question</param>
        /// <param name="answerLetters">the letter(s) the user chose as the correct answer</param>
        public void SetUserAnswer(int questionNumber, string answerLetters)
        {
            string answerText = "";
            answerLetters = rgx.Replace(answerLetters, ""); // remove anything that's not a letter
                        
            foreach (var letter in answerLetters)
            {
                var choiceText = Questions[questionNumber].Choices[letter.ToString()];
                answerText += String.IsNullOrEmpty(answerText) ? choiceText : "," + choiceText;
                userAnswers[questionNumber] = answerText;
            }
        }

        public List<string> GetResults()
        {
            int correctAnswers = 0;
            var results = new List<string>();

            // start at one as the keys are the question numbers
            for (int i = 1; i <= userAnswers.Count; i++)
            {
                if (userAnswers[i] == Questions[i].CorrectAnswer)
                {
                    results.Add($"{i}. \"{userAnswers[i]}\" was correct!");
                    correctAnswers++;
                }
                else
                {
                    results.Add($"{i}. Sorry, \"{Questions[i].CorrectAnswer}\" was the correct answer.");
                }
            }

            results.Add($"You got {correctAnswers} of {Questions.Count} correct.");
            return results;
        }
    }
}
