﻿using VisitService.Application.Model;
using VisitService.Domain.DTO;

namespace VisitService.Application.Repositories.Visits.Commands.Visit;

public interface IUpdateVisitDeleteStatusCommand
{
    Task<DataResultModel<VisitGeneralInfoDTO>> UpdateVisitDeleteStatusByIdAsync(int visitId);

}
