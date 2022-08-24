﻿using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors.Identity;

public static class PermissionErrors
{
    public static ErrorModel InvalidPermissionIdValidationError = new ErrorModel(
        code: 14001,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid permission id"
        ));

    public static ErrorModel InvalidClaimIdValidationError = new ErrorModel(
        code: 14001,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Invalid permission id"
        ));

    public static ErrorModel DuplicateClaimError = new ErrorModel(
        code: 14002,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Claim is registered before"
        ));

    public static ErrorModel ClaimNotFoundError = new ErrorModel(
        code: 14003,
        title: "Identity Error",
        (
            Language: Language.English,
            Message: "Claim not found"
        ));


}