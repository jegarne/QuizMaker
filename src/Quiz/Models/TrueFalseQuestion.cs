using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMaker.Models
{
    public class TrueFalseQuestion : Question
    {
        /// <summary>
        /// Creates a true or false question
        /// </summary>
        /// <param name="question">the question text</param>
        /// <param name="answer">a boolean value representing the correct answer</param>
        public TrueFalseQuestion(string question, bool answer) : base(question)
        {
            if (answer)
            {
                SetChoices("true*,false");
            }
            else
            {
                SetChoices("true,false*");
            }
        }

        public override string GetInstructions()
        {
            return "Enter \"a\" or \"b\".";
        }
    }
}
