﻿using Dayana.Shared.Basic.ConfigAndConstants.Constants;

namespace Dayana.Shared.Infrastructure.Errors;
public static class GenericErrors<T>
{
    public static ErrorModel InvalidVariableError(string variableName) => new ErrorModel(
      code: 666,
      title: $"{nameof(T)} Error",
         (
        Language: Language.English,
        Message: $"Invalid property : '{variableName.ToLower()}' in -> object: '{nameof(T)}' error"
      ));

    public static ErrorModel NotFoundError(string variableName) => new ErrorModel(
     code: 69,
     title: $"{nameof(T)} Error",
        (
       Language: Language.English,
       Message: $"object: '{nameof(T)}' -> with this '{variableName.ToLower()}' -> not found"
     ));

    public static ErrorModel CustomError(string causeOfError, string? variableName = "unknown") => new ErrorModel(
    code: 85,
    title: $"{nameof(T)} Error",
       (
      Language: Language.English,
      Message: $"object: '{nameof(T)}' | '{variableName.ToLower()}' property error | \n {causeOfError.ToLower()}"
    ));

    public static ErrorModel IntervalError(int min, int max, string variableName) => new ErrorModel(
   code: 13,
   title: $"{nameof(T)} Error",
      (
     Language: Language.English,
     Message: $"object: '{nameof(T)}' | '{variableName.ToLower()}' property error | \n the '{variableName}' length is between Min: {min} | Max: {max}"
   ));

    public static ErrorModel DuplicateError(string variableName) => new ErrorModel(
 code: 2022,
 title: $"{nameof(T)} Error",
    (
   Language: Language.English,
   Message: $"object: '{nameof(T)}' | with this '{variableName.ToLower()}' already exists | \n "
 ));
}
