using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.MilitaryElite
{
    public interface ICommando : IServiceProvider
    {
        IReadOnlyCollection<IMissions> Missions { get; }

        void AddMissions(IMissions missions);
    }
}
