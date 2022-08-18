﻿using Dayana.Shared.Domains.Identity.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dayana.Shared.Persistence.Seeding.Seeds;

public static class RoleSeed
{
    public static List<Role> All => new List<Role>
    {
        new Role()
        {
            Id = 1,
            Title = "Owner",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        }
    };

    public static void Run(IServiceScope scope)
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var roleSeeds = All;
        var roleSeedNames = roleSeeds.ConvertAll(x => x.Title.ToLower());

        var toBeUpdatedRoles = context.Roles
            .Include(x => x.RolePermission)
            .Where(x => roleSeedNames.Contains(x.Title.ToLower()))
            .ToList();

        var toBeAddedRoles = roleSeeds
            .Where(x => !toBeUpdatedRoles.ConvertAll(y => y.Title.ToLower()).Contains(x.Title));

        foreach (var item in toBeUpdatedRoles)
        {
            var seed = roleSeeds.Single(x => x.Title.ToLower() == item.Title.ToLower());
            item.RolePermission = seed.RolePermission;
            item.UpdatedAt = DateTime.UtcNow;
        }

        foreach (var item in toBeAddedRoles)
        {
            context.Roles.Add(item);
        }
    }
}