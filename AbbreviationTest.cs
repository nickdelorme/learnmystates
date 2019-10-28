using System;
using System.Collections.Generic;

namespace nick
{
    public class AbbreviationTest
    {
        private List<State> _states;
        private int _questionIndex;

        public AbbreviationTest(List<State> states)
        {
            this._states = states;
            this._questionIndex = 0;
        }

        public string GetQuestion()
        {
            Random r = new Random();
            r.Next()
        }

    }
}