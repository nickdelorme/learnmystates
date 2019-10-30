using System;
using System.Linq;
using System.Collections.Generic;

namespace nick
{
    /// <summary>
    /// Tests the users knowledge of state capitals.
    /// </summary>
    public class CapitalQuiz : StatesQuiz
    {
        public CapitalQuiz(List<State> states) : base(states)
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
                PrintLine("\tCorrect!", ConsoleColor.Green);
            }
            else
            {
                PrintLine($"\tThe correct answer is {state.Capital}.", ConsoleColor.Red);
                //CheckSpelling()
            }
        }

        protected override State PrintQuestion(State state)
        {
            string question = $"Type the state capital for {state.Name} and press <ENTER>: ";
            Print(question, ConsoleColor.White);   
            
            return state;         
        }

        protected override bool CheckAnswer(string answer, State state)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                return false;
            }

            return (answer.Trim().ToUpper() == state.Capital.ToUpper());
        }
    }
}