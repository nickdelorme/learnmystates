using System;
using System.Linq;
using System.Collections.Generic;

namespace nick
{
    /// <summary>
    /// Abstract base class for states quizes.
    /// </summary>
    public abstract class StatesQuiz
    {
        protected List<State> _states;
        protected List<KeyValuePair<State, string>> _answers;
        protected Random _random;

        public StatesQuiz(List<State> states)
        {
            _states = states;
            _answers = new List<KeyValuePair<State, string>>();
            _random = new Random();
        }

        public abstract void AskQuestion();

        protected abstract bool CheckAnswer(string answer, State state);

        protected abstract State PrintQuestion(State state);

        protected State GetRandomState()
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

        protected string GetAnswer(State state)
        {
            string answer = Console.ReadLine();
            
            // Keep track of unique state answers.
            _answers.Add(new KeyValuePair<State, string>(state, answer));    

            return answer;        
        }        

        public void PrintScore()
        {
            int correct, total;
            GetScore(out correct, out total);

            PrintLine($"You answered {correct} correct out of {total} states.", ConsoleColor.Yellow);
        }

        protected void GetScore(out int correct, out int total)
        {
            correct = _answers.Where(a => CheckAnswer(a.Value, a.Key)).Count();
            total = _answers.Count();
        }

        protected void PrintLine(string message, ConsoleColor color)
        {
            Print(message + "\n", color);
        }

        protected void Print(string message, ConsoleColor color)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = previousColor;
        }
    }
}