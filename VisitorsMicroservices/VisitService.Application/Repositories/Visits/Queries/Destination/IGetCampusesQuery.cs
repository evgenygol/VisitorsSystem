﻿using VisitService.Domain.Destination;

namespace VisitService.Application.Repositories.Visits.Queries.Destination;

public interface IGetCampusesQuery
{
    Task<List<Campus>> GetCampusesAsync();

}
