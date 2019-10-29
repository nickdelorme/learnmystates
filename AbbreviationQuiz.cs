using System;
using System.Linq;
using System.Collections.Generic;

namespace nick
{
    public class AbbreviationQuiz
    {
        List<State> _states;
        Random _random;
        List<KeyValuePair<State, string>> _answers;

        public AbbreviationQuiz(List<State> states)
        {
            this._states = states;
             _random = new Random();
             _answers = new List<KeyValuePair<State, string>>();
        }

        public void AskQuestion()
        {
            // Get a random state question.
            State state = PrintQuestion();

            // Get the user's answer.
            string answer = GetAnswer(state);

            if (CheckAnswer(answer, state) == true)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Sorry, that's not correct.");
            }
        }

        public void PrintScore()
        {
            int correct = _answers.Where(a => CheckAnswer(a.Value, a.Key)).Count();
            int total = _answers.Count();

            Console.WriteLine($"You answered {correct} correct out of {total} states.");
        }

        private State PrintQuestion()
        {
            State state = GetRandomState();

            string question = $"Type the abbreviation for {state.Name} and press <ENTER>: ";
            Console.Write(question);   
            
            return state;         
        }

        private State GetRandomState()
        {
            int index = _random.Next(0, _states.Count - 1);
            State state = _states[index];
            
            if (AlreadyAnsweredCorrectly(state))
            {
                return GetRandomState();
            }
            else
            {
                return state;
            }
        }

        private bool AlreadyAnsweredCorrectly(State state)
        {
            return _answers.Exists(kvp => kvp.Key == state && CheckAnswer(kvp.Value, kvp.Key));
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
                Console.WriteLine("Please provide a valid abbreviation and press <ENTER>: ");
                return false;
            }

            return (answer.Trim().ToUpper() == state.Abbreviation.ToUpper());
        }
    }
}