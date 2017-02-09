using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace DependencyInjection
{
    /// <summary>
    /// A simple manager for managing the Unity IoC container.
    /// </summary>
    public sealed class UnityContainerManager : IDisposable
    {
        private IUnityContainer container;
        private bool disposed;

        /// <summary>
        /// Initializes static members of the <see cref="UnityContainerManager"/> class.
        /// </summary>
        static UnityContainerManager()
        {
            Current = new UnityContainerManager();
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="UnityContainerManager"/> class from being created.
        /// </summary>
        private UnityContainerManager()
        {
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="UnityContainerManager"/> class.
        /// </summary>
        ~UnityContainerManager()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets the current <see cref="UnityContainerManager"/> instance.
        /// </summary>
        public static UnityContainerManager Current { get; private set; }

        /// <summary>
        /// Gets the IoC container.
        /// </summary>
        /// <returns>A <see cref="IUnityContainer"/> object.</returns>
        public IUnityContainer GetContainer()
        {
            if (!this.disposed)
            {
                if (this.container == null)
                {
                    this.container = new UnityContainer();
                    this.container.LoadConfiguration();
                }

                return this.container;
            }
            else
                throw new ObjectDisposedException(this.GetType().Name, "The 'GetContainer' method cannot be called once the object has been disposed.");
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.container != null)
                        this.container.Dispose();
                }

                this.disposed = true;
            }
        }
    }
}