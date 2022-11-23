using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitService.Domain.Common
{
    public class BaseNamedEntity: BaseEntity <int>
    {
        public string NAME { get; set; } = string.Empty;
        public int ORDER_ID { get; set; }
    }
}
