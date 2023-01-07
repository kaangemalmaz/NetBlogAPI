using Autofac;
using Autofac.Extras.DynamicProxy;
using NetBlog.Business.Abstract;
using NetBlog.Business.Concrete;
using NetBlog.Core.Utilities.Interceptors;
using NetBlog.Core.Utilities.Security.Jwt;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Repository.EntityFramework;

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

            
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
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


            
            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); // çalışan assembly yi al.

            //buna bir bak sen yinede!
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

            //builder.RegisterInstance(new MapProfile()).As<IMapper>();

            //var profiles =
            //    from t in typeof(MapProfile).Assembly.GetTypes()
            //    where typeof(Profile).IsAssignableFrom(t)
            //    select (Profile)Activator.CreateInstance(t);

            //builder.Register(ctx => new MapperConfiguration(cfg =>
            //{
            //    foreach (var profile in profiles)
            //    {
            //        cfg.AddProfile(profile);
            //    }
            //}));

            //builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
        }
    }
}
