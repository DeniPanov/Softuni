using System.Collections.Generic;

namespace P08_MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
       IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier soldier);
    }
}
