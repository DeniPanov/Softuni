using System.Linq;
using System.Collections.Generic;
using MXGP.Repositories.Contracts;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository: IRepository<IRider>
    {
        private readonly List<IRider> riders;

        public RiderRepository()
        {
            riders = new List<IRider>();
        }
        public void Add(IRider model)
        {
            riders.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return riders.ToList().AsReadOnly();
        }

        public IRider GetByName(string name)
        {
            return this.riders.FirstOrDefault(r => r.Name == name);
        }

        public bool Remove(IRider model)
        {
            return this.riders.Remove(model);
        }
    }
}
