using System.Collections.Generic;
using Zenject;

namespace Services
{
    public class InjectService
    {
        public DiContainer container { get; private set; } = new DiContainer();

        private List<DiContainer> _containers = new();

        public void AddContainer(DiContainer newContainer)
        {
            if (_containers.Contains(newContainer)) { return; }

            _containers.Add(newContainer);
            container = new DiContainer(_containers);
        }

        public void RemoveContainer(DiContainer newContainer)
        {
            if (_containers.Contains(newContainer) == false) { return; }

            _containers.Remove(newContainer);
            container = new DiContainer(_containers);
        }

        public void Inject(object obj)
        {
            container.Inject(obj);
        }

        public T Resolve<T>(object id = null) where T : class
        {
            if (id != null) { return container.TryResolveId<T>(id); }
            else { return container.TryResolve<T>(); }
        }
    }
}