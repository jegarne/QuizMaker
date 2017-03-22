using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class CheckboxQuestion : Question
    {
        /// <summary>
        /// Creates a question with more than one correct answer
        /// </summary>
        /// <param name="question">the question text</param>
        /// <param name="choices">a string containing all the answer choices separated with commas - mark any correct answers with *</param>
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
