using System;
using System.Collections.Generic;

namespace nick
{
    class State 
    {
        public string Capital;
        public string StateCode;
        public string Name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<State> states = CreateStates();
            PrintStates(states);
        }

        static List<State> CreateStates()
        {
            List<State> states = new List<State>();
            
            states.Add(new State() {
                    Name = "Florida",
                    StateCode = "FL",
                    Capital = "Tallahassee"
            });

            states.Add(new State() {
                Name = "Louisianna",
                StateCode = "LA",
                Capital = "Baton Rouge"
            });

            states.Add(new State() {
                Name = "New York",
                StateCode = "NY",
                Capital = "Albany"
            });

            return states;
        }

        static void PrintStates(List<State> states)
        {
            foreach(State state in states)
            {
                Console.WriteLine(state.Name);
            }
        }
    }
}
