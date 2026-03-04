using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppCore.Models;

namespace AppCore.Interfaces;

public interface IPersonRepository : IGenericRepositoryAsync<Person>
{
    Task<IEnumerable<Person>> GetByCompanyAsync(Guid companyId);
    Task<IEnumerable<Person>> GetByOrganizationAsync(Guid organizationId);
}
