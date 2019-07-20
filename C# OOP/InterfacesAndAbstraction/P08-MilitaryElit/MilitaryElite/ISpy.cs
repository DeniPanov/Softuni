using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.MilitaryElite
{
    public interface ISpy:ISoldier
    {
        int CodeNumber { get; }
    }
}
