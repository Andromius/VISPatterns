using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public abstract class DomainObject
    {
        public int? Id { get; set; }
        public DomainObject(int id) { Id = id; }
        public DomainObject() { }
    }
}
