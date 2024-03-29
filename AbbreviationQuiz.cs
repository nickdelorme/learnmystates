using System;
using System.Linq;
using System.Collections.Generic;

namespace nick
{
    /// <summary>
    /// Tests the users knowledge of state abbreviations.
    /// </summary>
    public class AbbreviationQuiz : StatesQuiz
    {
        public AbbreviationQuiz(List<State> states) : base(states)
        {}

        public override void AskQuestion()
        {
            // Get a state in random order.
            State state = GetRandomState();

            if (state == null)
            {
                // No more states to ask questions for.
                return;
            }

            // Ask the question.
            PrintQuestion(state);

            // Get the answer.
            string answer = GetAnswer(state);

            // Check if it was correct or not.
            if (CheckAnswer(answer, state) == true)
            {
                if (!answer.All(char.IsUpper))
                {
                    PrintLine("\tState abbreviations should be capitalzed.", ConsoleColor.Yellow);
                }                
                PrintLine("\tCorrect!", ConsoleColor.Green);
            }
            else
            {
                PrintLine("\tSorry, that's not correct.", ConsoleColor.Red);
            }
        }

        protected override State PrintQuestion(State state)
        {
            string question = $"Type the abbreviation for {state.Name} and press <ENTER>: ";
            Print(question, ConsoleColor.White);   
            
            return state;         
        }

        protected override bool CheckAnswer(string answer, State state)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                return false;
            }

            return (answer.Trim().ToUpper() == state.Abbreviation.ToUpper());
        }
    }
}