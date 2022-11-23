using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitService.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        public virtual T ID { get; set; }
    }
}
