using Dayana.Server.Application.Behaviors.Blog;
using Dayana.Server.Application.Behaviors.Identity;
using Dayana.Shared.Infrastructure.Operations;
using Dayana.Shared.Persistence.Models.Blog.Commands;
using MediatR;

namespace Dayana.Server.Api.Extensions.DependencyInjection;

public static class MediatRInjection
{
    public static IServiceCollection AddConfiguredMediatR(this IServiceCollection services)
    {
        // Generic behaviors
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommitBehavior<,>));

        #region blog

        #region weblog post

        services.AddTransient(typeof(IPipelineBehavior<CreatePostCommand, OperationResult>),
            typeof(CreatePostValidationBehavior<CreatePostCommand, OperationResult>));
        //services.AddTransient(typeof(IPipelineBehavior<UpdateWeblogPostCommand, OperationResult>),
        //    typeof(UpdateWeblogPostValidationBehavior<UpdateWeblogPostCommand, OperationResult>));
        //services.AddTransient(typeof(IPipelineBehavior<DeleteWeblogPostCommand, OperationResult>),
        //    typeof(DeleteWeblogPostValidationBehavior<DeleteWeblogPostCommand, OperationResult>));

        #endregion

        //#region weblog post category

        //services.AddTransient(typeof(IPipelineBehavior<CreateWeblogPostCategoryCommand, OperationResult>),
        //    typeof(CreateWeblogPostCategoryValidationBehavior<CreateWeblogPostCategoryCommand, OperationResult>));
        //services.AddTransient(typeof(IPipelineBehavior<UpdateWeblogPostCategoryCommand, OperationResult>),
        //    typeof(UpdateWeblogPostCategoryValidationBehavior<UpdateWeblogPostCategoryCommand, OperationResult>));
        //services.AddTransient(typeof(IPipelineBehavior<DeleteWeblogPostCategoryCommand, OperationResult>),
        //    typeof(DeleteWeblogPostCategoryValidationBehavior<DeleteWeblogPostCategoryCommand, OperationResult>));

        //#endregion

        #endregion

        return services;
    }
}