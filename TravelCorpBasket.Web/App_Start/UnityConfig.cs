using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

using TravelCorp.domain;

namespace TravelCorpBasket.Web.App_Start
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

     
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            

            container.RegisterTypes(
                                    AllClasses.FromLoadedAssemblies(),
                                    WithMappings.FromMatchingInterface,
                                    WithName.Default
                                    );
          
        }
    }
}
