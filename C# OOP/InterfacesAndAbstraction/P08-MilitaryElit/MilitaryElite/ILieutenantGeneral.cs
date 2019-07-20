using System.Collections.Generic;

namespace PersonInfo.MilitaryElite
{
    public interface ILieutenantGeneral :IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier @private);
    }
}
