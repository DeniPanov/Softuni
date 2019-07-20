using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.MilitaryElite
{
    public interface IRepairs
    {
        string PartName {get;}

        int HoursWorked { get; }
    }
}
