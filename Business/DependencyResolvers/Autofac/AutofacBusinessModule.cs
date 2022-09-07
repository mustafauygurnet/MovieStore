using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

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

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(
                new ProxyGenerationOptions
                {
                    Selector = new MethodInterceptorAspectSelector()
                }).SingleInstance();
    }
}