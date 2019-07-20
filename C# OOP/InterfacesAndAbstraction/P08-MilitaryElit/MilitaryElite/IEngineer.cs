using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.MilitaryElite
{
    public interface IEngineer:IServiceProvider
    {
        IReadOnlyCollection<IRepairs> Repairs { get; }

        void AddRepairs(IRepairs repairs);
    }
}

