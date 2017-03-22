using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class CheckboxQuestion : Question
    {
        public CheckboxQuestion(string question, string choices) : base(question)
        {
            SetChoices(choices);
        }

        public override string GetInstructions()
        {
            return "Enter the letter of all correct answers.";
        }
    }
}
