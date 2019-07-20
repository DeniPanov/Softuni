using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.MilitaryElite
{
    public interface IMissions
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
