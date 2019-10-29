using System;
using System.Collections.Generic;

namespace nick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<State> states = CreateStates();
            // PrintStates(states);
            AbbreviationQuiz quiz = new AbbreviationQuiz(states);
            
            Console.WriteLine("Starting your quiz.");
            for (int i = 0; i < 10; i++)
            {
                quiz.AskQuestion();
            }
            quiz.PrintScore();
            Console.WriteLine("All Done!");
        }

        static List<State> CreateStates()
        {
            List<State> states = new List<State>();
            
            states.Add(new State() {
                    Name = "Florida",
                    Abbreviation = "FL",
                    Capital = "Tallahassee"
            });

            states.Add(new State() {
                Name = "Louisianna",
                Abbreviation = "LA",
                Capital = "Baton Rouge"
            });

            states.Add(new State() {
                Name = "Arkansas",
                Abbreviation = "AR",
                Capital = "Little Rock"
            });

            states.Add(new State() {
                Name = "Kentucky",
                Abbreviation = "KY",
                Capital = "Frank Fort"
            });

            states.Add(new State() {
                Name = "Alabama",
                Abbreviation = "AL",
                Capital = "Montgomery"
            });

            states.Add(new State() {
                Name = "Georgia",
                Abbreviation = "GA",
                Capital = "Atlanta"
            });
            
            states.Add(new State() {
                Name = "North Carolina",
                Abbreviation = "NC",
                Capital = "Raleigh"
            });

           states.Add(new State() {
                Name = "South Carolina",
                Abbreviation = "NC",
                Capital = "Columbia"
            }); 

           states.Add(new State() {
                Name = "Mississippi",
                Abbreviation = "MS",
                Capital = "Jackson"
            }); 
            
           states.Add(new State() {
                Name = "Tennessee",
                Abbreviation = "TN",
                Capital = "Nashville"
            });
                      
            states.Add(new State() {
                Name = "Virginia",
                Abbreviation = "VA",
                Capital = "Richmond"
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
