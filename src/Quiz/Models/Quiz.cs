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

        public void TakeQuiz()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine($"{question.Key.ToString()}. {question.Value.Text}");

                foreach (var choice in question.Value.Choices)
                {
                    Console.WriteLine($"{choice.Key}. {choice.Value}");
                }

                Console.WriteLine("");
                Console.WriteLine(question.Value.GetInstructions());

                var answer = Console.ReadLine();
                SetUserAnswer(question.Key, answer);

                Console.WriteLine("");
            }
        }

        public void GradeQuiz()
        {
            int correctAnswers = 0;

            // start at one as the keys are the question numbers
            for (int i = 1; i <= userAnswers.Count; i++)
            {
                if (userAnswers[i] == Questions[i].CorrectAnswer)
                {
                    Console.WriteLine($"{i}. \"{userAnswers[i]}\" was correct!");
                    correctAnswers++;
                }
                else
                {
                    Console.WriteLine($"{i}. Sorry, \"{Questions[i].CorrectAnswer}\" was the correct answer.");
                }
            }

            Console.WriteLine($"You got {correctAnswers} of {Questions.Count} correct.");
        }

        private void SetUserAnswer(int questionNumber, string answerLetters)
        {
            string answerText = "";
            answerLetters = rgx.Replace(answerLetters, ""); // remove anything that's not a letter

            // get the actual choice text even if there is more than one user choice
            foreach (var letter in answerLetters)
            {
                var choiceText = Questions[questionNumber].Choices[letter.ToString()];
                answerText += String.IsNullOrEmpty(answerText) ? choiceText : "," + choiceText;
                userAnswers[questionNumber] = answerText;
            }
        }
    }
}
