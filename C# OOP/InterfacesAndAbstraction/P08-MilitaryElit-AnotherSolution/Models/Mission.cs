namespace P08_MilitaryElite.Models
{
    using System;
    using P08_MilitaryElite.Contracts;
    using P08_MilitaryElite.Exceptions;

    public class Mission : IMission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public string CodeName { get; private set; }

        public string State
        {
            get => this.state;

            private set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException(ExceptionMessages.InvalidMissionStateException);
                }

                this.state = value;
            }
        }

        public void CompleteMission()
        {
            if (this.State == "Finished")
            {
                throw new ArgumentException(ExceptionMessages.MissionIsAlreadyFinishedException);
            }

            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
