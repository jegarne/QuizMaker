using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class MultipleChoiceQuestion : Question
    {
        public MultipleChoiceQuestion(string question, string choices) : base(question)
        {
            if (choices.Count(c => c == '*') > 1)
            {
                throw new Exception("A multiple choice question can only have one correct answer.  Please use only one apostrophe.");            
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
