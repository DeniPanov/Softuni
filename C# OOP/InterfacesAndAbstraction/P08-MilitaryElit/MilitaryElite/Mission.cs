using System;


namespace PersonInfo.MilitaryElite
{
    public class Mission : IMissions
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;

            ParseState(state);
        }


        public string CodeName
        { get; private set; }

        public State State
        { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new ArgumentException("You cannot finish already completed mission!");
            }
            this.State = State.Finished;
        }
        private void ParseState(string stateStr)
        {
            State state;

            bool parse = Enum.TryParse<State>(stateStr,
                out state);

       if (!parse)
       {
           throw new ArgumentException("Invalid mission state!");
       }

            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
