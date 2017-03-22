using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public abstract class Question
    {
        protected const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

        public string Text { get; private set; }
        public Dictionary<string, string> Choices { get; set; } = new Dictionary<string, string>();
        public string CorrectAnswer { get; private set; }

        public Question(string text)
        {
            this.Text = text;
        }

        public virtual string GetInstructions()
        {
            return null;
        }

        protected void SetChoices(string choices)
        {
            string[] choice = choices.Split(',');

            for (int i = 0; i < choice.Length; i++)
            {
                choice[i] = SetCorrectAnswer(choice[i]);
                var letter = Alphabet[i].ToString();
                Choices[letter] = choice[i];
            }

            // if we got this far and don't have a correct answer yet, throw an exception
            if(String.IsNullOrEmpty(CorrectAnswer))
            {
                throw new Exception("You did not provide a correct answer.  Please mark the correct answer with an apostrophe.");
            }
        }

        private string SetCorrectAnswer(string choice)
        {
            if (choice.Contains('*'))
            {
                choice = choice.Replace("*", "");
                //if there is already a correct answer, append a comma and the next correct answer
                CorrectAnswer += String.IsNullOrEmpty(CorrectAnswer) ? choice : "," + choice;
            }
            return choice;
        }
    }
}
