using System;
using System.Linq;

namespace QuizMaker.Models
{
    public class MultipleChoiceQuestion : Question
    {
        /// <summary>
        /// Creates a multiple choice question
        /// </summary>
        /// <param name="question">the question text</param>
        /// <param name="choices">a string containing all the answer choices separated with commas - mark one correct answer with *</param>
        public MultipleChoiceQuestion(string question, string choices) : base(question)
        {
            // Using LINQ: https://msdn.microsoft.com/en-us/library/bb397678.aspx
            if (choices.Count(c => c == '*') > 1)
            {
                throw new ArgumentException("A multiple choice question can only have one correct answer.  Please use only one apostrophe.");            
            }
            else
            {
                SetChoices(choices);
            }
        }

        public override string GetInstructions()
        {
            return "Enter the letter of the correct answer.";
        }
    }
}
