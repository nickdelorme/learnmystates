using System;
using System.Collections.Generic;

namespace nick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<State> states = CreateStates();
            StatesQuiz quiz = new AbbreviationQuiz(states);
            
            Console.WriteLine("Starting your quiz.");
            for (int i = 0; i < states.Count; i++)
            {
                quiz.AskQuestion();
            }
            quiz.PrintScore();
            Console.WriteLine("All Done!");
        }

        static StatesQuiz ChooseQuiz(List<State> states)
        {
            StatesQuiz quiz = null;

            Console.WriteLine("Choose a quiz by pressing the number below:\n" + 
                "\t1 - Abbreviations Quiz\n" +
                "\t2 - Capitals Quiz\n");

            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    quiz = new AbbreviationQuiz(states);
                    break;
                case ConsoleKey.D2:
                    quiz = new CapitalQuiz(states);
                    break;
                default:
                    quiz = ChooseQuiz(states); // recurse till correct.
                    break;
            }
            
            return quiz;
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
                Capital = "Frankfort"
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
                Abbreviation = "SC",
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
