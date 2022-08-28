﻿using Dayana.Shared.Basic.ConfigAndConstants.Constants;
using Dayana.Shared.Basic.MethodsAndObjects.Models;
using Dayana.Shared.Infrastructure.Errors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using FluentValidation;
using MediatR;

namespace Dayana.Shared.Persistence.Models.Identity.Commands.Roles;

public class CreateRoleCommand : IRequestInfo, IRequest<OperationResult>
{
    public CreateRoleCommand(RequestInfo requestInfo)
    {
        RequestInfo = requestInfo;
    }

    public string Title { get; set; }
    public IList<int> PermissionIds { get; set; }

    public RequestInfo RequestInfo { get; private set; }
}


public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.PermissionIds)
            .NotEmpty()
            .WithState(_ => PermissionErrors.InvalidPermissionIdValidationError);

        RuleFor(x => x.Title)
            .MaximumLength(Defaults.NameLength)
            .WithState(_ => CommonErrors.InvalidTitleValidationError);

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithState(_ => CommonErrors.InvalidTitleValidationError);
    }
}