using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOutDI.DependencyInjection
{
    public class DIContainer
    {
        private List<ServiceDescriptor> _serviceDescriptors;
        public DIContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }

        public object GetService(Type serviceType)
        {

            var descriptor = _serviceDescriptors
                .SingleOrDefault(x => x.ServiceType == serviceType);

            if (descriptor == null)
            {
                throw new NotImplementedException($"Service of type {serviceType.Name} is not registered.");
            }

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation; //hard cast to T type //The second time its called, itll return the same service
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface) //cannot be instantiated
            {
                throw new Exception("Cannot instantiate abstract classes/ interfaces");
            }

            var constructorInfo = actualType.GetConstructors().First();
            var parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();


            var implementation = Activator.CreateInstance(actualType, parameters);
            //create a class by using just a type
            //Try to create Instance from descriptor.ImplementationType if it exist, if not instantiate from servicetype

            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                //This is singleton implementation
                descriptor.Implementation = implementation;
                return implementation; //This is the first time

            }
            return implementation; //This is the first time


        }
        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}
