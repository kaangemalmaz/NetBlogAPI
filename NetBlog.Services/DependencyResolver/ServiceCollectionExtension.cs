using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using NetBlog.Business.Abstract;
using NetBlog.Business.Concrete;
using NetBlog.Business.Mappings.AutoMapper;
using NetBlog.Business.ValidationRules.FluentValidation.Category;
using NetBlog.Core.DataAccess.Abstract;
using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;
using NetBlog.DataAccess.Concrete.Repository.EntityFramework;

namespace NetBlog.Business.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services)
        {
            services.AddDbContext<NetBlogContext>();

            //services.AddScoped(typeof(IEntityRepositoryAsync<,>), typeof(EntityRepositoryAsync<,>));
            //services.AddScoped(typeof(IEntityService<>), typeof(EntityManager<>));

            //services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<ICategoryDal, CategoryDal>();

            //services.AddScoped<IPostService, PostManager>();
            //services.AddScoped<IPostDal, PostDal>();

            //services.AddScoped<ICommentService, CommentManager>();
            //services.AddScoped<ICommentDal, CommentDal>();

            //services.AddScoped<IContactService, ContactManager>();
            //services.AddScoped<IContactDal, ContactDal>();

            //services.AddScoped<IUserService, UserManager>();
            //services.AddScoped<IUserDal, UserDal>();

            //services.AddScoped<IOperationClaimService, OperationClaimManager>();
            //services.AddScoped<IOperationClaimDal, OperationClaimDal>();

            //services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
            //services.AddScoped<IUserOperationClaimDal, UserOperationClaimDal>();

            //services.AddScoped<IAuthService, AuthManager>();
            //services.AddScoped<IFileService, FileManager>();

            services.AddAutoMapper(typeof(MapProfile));
            //services.AddFluentValidation(opt =>
            //{
            //    opt.RegisterValidatorsFromAssemblyContaining<AddCategoryDtoValidator>();
            //    opt.ValidatorOptions.LanguageManager.Enabled = false;
            //});

            return services;
        }
    }
}
