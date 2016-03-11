using System;
using FootballManager.Data;
using FootballManager.Data.Repository;
using FootballManager.Data.UnitOfWorks;
using FootballManager.Domain;
using FootballManager.Service;
using Microsoft.Practices.Unity;

namespace UnitTesting
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
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            container.RegisterType(typeof(IFootballContext), typeof(FakeFootballContext));
            container.RegisterType(typeof(IRepository<>), typeof(GenericRepository<>));
            container.RegisterType(typeof(IBaseService<>), typeof(BaseService<>));
            container.RegisterType(typeof(IUnitOfWork), typeof(UnitOfWork));
            container.RegisterType(typeof(IBaseService<Team>), typeof(TeamService));
            container.RegisterType(typeof(IBaseService<Player>), typeof(PlayerService));

            //container.RegisterInstance()
        }
    }
}
