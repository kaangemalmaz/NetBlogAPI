﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using NetBlog.Business.Abstract;
using NetBlog.Business.Concrete;
using NetBlog.Business.Mappings.AutoMapper;
using NetBlog.Core.Entities.Concrete;
using NetBlog.Core.Utilities.Interceptors;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Repository.EntityFramework;

namespace NetBlog.Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CategoryDal>().As<ICategoryDal>();
            builder.RegisterType<CommentDal>().As<ICommentDal>();
            builder.RegisterType<ContactDal>().As<IContactDal>();
            builder.RegisterType<PostDal>().As<IPostDal>();
            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<OperationClaimDal>().As<IOperationClaimDal>();
            builder.RegisterType<UserOperationClaimDal>().As<IUserOperationClaimDal>();

            
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<ContactManager>().As<IContactService>();
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<FileManager>().As<IFileService>();


            
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