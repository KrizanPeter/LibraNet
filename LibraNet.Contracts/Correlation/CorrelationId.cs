using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraNet.Contracts.Correlation
{
    public class CorrelationId
    {
        public Guid Id { get; set; }
        public CorrelationId() {
            Id = Guid.NewGuid();
        }
    }
}
