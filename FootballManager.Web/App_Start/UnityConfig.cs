using System;
using AutoMapper;
using FootballManager.Domain;
using FootballManager.Repository.Repositories;
using FootballManager.Repository.UnitOfWorks;
using FootballManager.Service;
using FootballManager.Web.Common;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace FootballManager.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType(typeof(IBaseService<>), typeof(BaseService<>));
            container.RegisterType(typeof (IBaseService<Player>), typeof(PlayerService));
            container.RegisterType(typeof(IBaseService<Nation>), typeof(NationService));
            container.RegisterType<ITeamService, TeamService>();
            container.RegisterType<ITournamentService, TournamentService>();


            container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>));
            container.RegisterType<ITeamRepository, TeamRepository>();

            //Config AutoMapper
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfile()); });
            var mapper = mapperConfiguration.CreateMapper();
            container.RegisterInstance<IMapper>(mapper, new ContainerControlledLifetimeManager());
        }
    }
}
