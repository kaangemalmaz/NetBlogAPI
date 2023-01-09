using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;
using NetBlog.Business.Authentication;
using NetBlog.Business.Mappings.AutoMapper;
using NetBlog.Business.Repositories.CategoryRepository;
using NetBlog.Business.Repositories.CategoryRepository.Rules;
using NetBlog.Business.Repositories.CommentRepository;
using NetBlog.Business.Repositories.ContactRepository;
using NetBlog.Business.Repositories.EmailParameterRepository;
using NetBlog.Business.Repositories.OperationClaimRepository;
using NetBlog.Business.Repositories.PostRepository;
using NetBlog.Business.Repositories.UserOperationClaimRepository;
using NetBlog.Business.Repositories.UserRepository;
using NetBlog.Business.Utilities.File;
using NetBlog.Core.Utilities.Interceptors;
using NetBlog.Core.Utilities.Security.Jwt;
using NetBlog.DataAccess.Context.EntityFramework;
using NetBlog.DataAccess.Repositories.CategoryRepository;
using NetBlog.DataAccess.Repositories.CommentRepository;
using NetBlog.DataAccess.Repositories.ContactRepository;
using NetBlog.DataAccess.Repositories.EmailParameterRepository;
using NetBlog.DataAccess.Repositories.OperationClaimRepository;
using NetBlog.DataAccess.Repositories.PostRepository;
using NetBlog.DataAccess.Repositories.UserOperationClaimRepository;
using NetBlog.DataAccess.Repositories.UserRepository;
using System.Reflection;
using Module = Autofac.Module;

namespace NetBlog.Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>();
            builder.RegisterType<EfContactDal>().As<IContactDal>();
            builder.RegisterType<EfPostDal>().As<IPostDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            
            //builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<ContactManager>().As<IContactService>();
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();

            builder.RegisterType<EfEmailParameterDal>().As<IEmailParameterDal>();
            builder.RegisterType<EmailParameterManager>().As<IEmailParameterService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<FileManager>().As<IFileService>();
            builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            builder.RegisterType<NetBlogContext>()
            .InstancePerLifetimeScope();

            builder.RegisterAutoMapper(typeof(MapProfile).Assembly);

            //validation
            builder.RegisterType<CategoryBusinessRules>().InstancePerLifetimeScope();

            builder.RegisterMediatR(Assembly.GetExecutingAssembly());


            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); // çalışan assembly yi al.

            //buna bir bak sen yinede!
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
