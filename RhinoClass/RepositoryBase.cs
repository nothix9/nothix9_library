using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoClass
{
    public class RepositoryBase<T> where T : DataObject
    {
        public RepositoryBase(IUnitOfWork unitOfWork)
        {

        }
    }
}
