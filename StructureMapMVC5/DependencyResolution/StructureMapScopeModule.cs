namespace StructureMapMVC5.DependencyResolution {
    using System.Web;

    using StructureMapMVC5.App_Start;

    using StructureMap.Web.Pipeline;

    public class StructureMapScopeModule : IHttpModule, System.IDisposable
    {
        #region Public Methods and Operators

        #region "IDisposable Support"

        public bool IsDisposing
        {
            get { return m_Disposing; }
        }

        // To detect redundant calls
        private bool disposedValue;
        private bool m_Disposing = false;
        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            m_Disposing = true;
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                // TODO: set large fields to null.
            }
            this.disposedValue = true;
        }

        // TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        //Protected Overrides Sub Finalize()
        //    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        //    Dispose(False)
        //    MyBase.Finalize()
        //End Sub

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        #endregion

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