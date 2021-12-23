using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTemplate.Logic.Controllers
{
    public class GenericController<E> : ControllerObject where E : Models.Entities.IdentityEntity, new()
    {
        public GenericController()
            : base(new DataContext.ProjectDbContext())
        {

        }
        public GenericController(ControllerObject other)
            : base(other)
        {

        }
    }
}
