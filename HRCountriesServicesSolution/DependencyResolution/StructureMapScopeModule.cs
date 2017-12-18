namespace HRCountriesServicesSolution.DependencyResolution {
    using System.Web;

    using HRCountriesServicesSolution.App_Start;

    using StructureMap.Web.Pipeline;
    /// <summary>
    /// 
    /// </summary>
    public class StructureMapScopeModule : IHttpModule {
        #region Public Methods and Operators
        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context) {
            context.BeginRequest += (sender, e) => StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
            context.EndRequest += (sender, e) => {
                HttpContextLifecycle.DisposeAndClearAll();
                StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
            };
        }

        #endregion
    }
}