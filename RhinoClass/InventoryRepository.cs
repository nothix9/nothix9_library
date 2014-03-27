using System.Linq;

namespace RhinoClass
{
    public class InventoryRepository : RepositoryBase<Inventory>
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DoSomething()
        {
            var x = _unitOfWork.GetTable<Inventory>();

            var y = x.Where(a => a.Quantity > 0).ToList();

        }
    }
}