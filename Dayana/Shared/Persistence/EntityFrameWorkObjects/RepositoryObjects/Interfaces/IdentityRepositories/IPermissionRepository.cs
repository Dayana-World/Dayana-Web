﻿using Dayana.Shared.Domains.Identity.Permissions;
using Dayana.Shared.Infrastructure.Pagination;
using Dayana.Shared.Persistence.Models.Identity.Base;

namespace Dayana.Shared.Persistence.EntityFrameWorkObjects.RepositoryObjects.Interfaces.IdentityRepositories;

public interface IPermissionRepository : IRepository<Permission,PermissionModel>
{
    Task<Permission> GetPermissionByIdAsync(int id);
    Task<List<Permission>> GetPermissionsByIdsAsync(IEnumerable<int> ids);
    Task<List<Permission>> GetPermissionsByFilterAsync(DefaultPaginationFilter filter);
    Task<int> CountPermissionsByFilterAsync(DefaultPaginationFilter filter);
}