using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRTest.Data.Repository;

namespace SignalRTest.Data.UnitOfWork
{
    public class DevTestUnitOfWork : DbContext, IUnitOfWork
    {
        private readonly GenericRepository<DevTest> _devTestRepository;
        private readonly DevTestContext context = new DevTestContext();

        public DevTestUnitOfWork()
        {
            _devTestRepository = new GenericRepository<DevTest>(context);
        }

        public GenericRepository<DevTest> DevTestRepository
        {
            get
            {
                return _devTestRepository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
