namespace P08_MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepairs> Repairs { get; }

        void AddRepair(IRepairs repairs);
    }
}
