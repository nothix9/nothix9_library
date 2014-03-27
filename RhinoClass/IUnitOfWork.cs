using System.Linq;

namespace RhinoClass
{
    public interface IUnitOfWork
    {
        IQueryable<Inventory> GetTable<Inventory>();
    }
}