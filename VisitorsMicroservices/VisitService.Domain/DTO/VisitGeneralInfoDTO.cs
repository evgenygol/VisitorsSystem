using VisitService.Domain.Common;
using VisitService.Domain.Entity.Destination;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Domain.DTO
{
    public class VisitGeneralInfoDTO
    {
        public VisitGeneralInfo VisitGeneralInfo { get; set; }
        public List<VisitDestinationInfo> VisitDestinationInfo { get; set; }
    }
}
