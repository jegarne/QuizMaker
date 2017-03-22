using QuizMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizMaker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tf = new TrueFalseQuestion("You know the rules and so do I.", true);
            var mc = new MultipleChoiceQuestion("What am I never gonna do?", "Give you up*,Let you out,Dessert you");
            var cb = new CheckboxQuestion("Which of the following am I never gonna do?", "Make you cry*,Say goodbye*,Tell a lie*,Hurt you*");

            // exception handling tests
            //var badMc1 = new MultipleChoiceQuestion("What am I never gonna do?", "Give you up*,Let you out*,Dessert you");
            var badMc2 = new MultipleChoiceQuestion("What am I never gonna do?", "Give you up,Let you out,Dessert you");

            Quiz quiz = new Quiz();

            quiz.Questions.Add(1, tf);
            quiz.Questions.Add(2, mc);
            quiz.Questions.Add(3, cb);

            quiz.TakeQuiz();

            quiz.GradeQuiz();

            Console.ReadLine();
        }
    }
}
