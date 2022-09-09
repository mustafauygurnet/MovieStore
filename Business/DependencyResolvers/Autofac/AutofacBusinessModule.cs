using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<EfActorDal>().As<IActorDal>().SingleInstance();
        builder.RegisterType<ActorManager>().As<IActorService>().SingleInstance();

        builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
        builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();

        builder.RegisterType<EfDirectorDal>().As<IDirectorDal>().SingleInstance();
        builder.RegisterType<DirectorManager>().As<IDirectorService>().SingleInstance();

        builder.RegisterType<EfGenreDal>().As<IGenreDal>().SingleInstance();
        builder.RegisterType<GenreManager>().As<IGenreService>().SingleInstance();

        builder.RegisterType<EfMovieDal>().As<IMovieDal>().SingleInstance();
        builder.RegisterType<MovieManager>().As<IMovieService>().SingleInstance();

        builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();
        builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
        
        builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
        builder.RegisterType<IToken>().As<JwtHelper>().SingleInstance();

        var assembly = Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(
                new ProxyGenerationOptions
                {
                    Selector = new MethodInterceptorAspectSelector()
                }).SingleInstance();
    }
}