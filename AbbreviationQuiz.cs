using System;
using System.Linq;
using System.Collections.Generic;

namespace nick
{
    /// <summary>
    /// Tests the users knowledge of state abbreviations.
    /// </summary>
    public class AbbreviationQuiz
    {
        List<State> _states;
        List<KeyValuePair<State, string>> _answers;
        Random _random;

        public AbbreviationQuiz(List<State> states)
        {
            _states = states;
            _answers = new List<KeyValuePair<State, string>>();
            _random = new Random();
        }

        public void AskQuestion()
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

        public void PrintScore()
        {
            int correct, total;
            GetScore(out correct, out total);

            PrintLine($"You answered {correct} correct out of {total} states.", ConsoleColor.Yellow);
        }

        private void GetScore(out int correct, out int total)
        {
            correct = _answers.Where(a => CheckAnswer(a.Value, a.Key)).Count();
            total = _answers.Count();
        }

        private State PrintQuestion(State state)
        {
            string question = $"Type the abbreviation for {state.Name} and press <ENTER>: ";
            Print(question, ConsoleColor.White);   
            
            return state;         
        }

        private State GetRandomState()
        {
            State state = null;
            do {
                if (_states.Count == _answers.Count)
                    break;
                
                int index = _random.Next(0, _states.Count);
                state = _states[index];

            } while (AlreadyAnswered(state)); 

            return state;
        }

        private bool AlreadyAnswered(State state)
        {
            return _answers.Exists(kvp => kvp.Key == state);
        }

        private string GetAnswer(State state)
        {
            string answer = Console.ReadLine();
            
            // Keep track of unique state answers.
            _answers.Add(new KeyValuePair<State, string>(state, answer));    

            return answer;        
        }

        private bool CheckAnswer(string answer, State state)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                return false;
            }

            return (answer.Trim().ToUpper() == state.Abbreviation.ToUpper());
        }

        private void PrintLine(string message, ConsoleColor color)
        {
            Print(message + "\n", color);
        }

        private void Print(string message, ConsoleColor color)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = previousColor;
        }
    }
}