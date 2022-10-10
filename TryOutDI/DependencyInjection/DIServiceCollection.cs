﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOutDI.DependencyInjection
{
    public class DIServiceCollection
    {
        private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();

        public void RegisterSingleton<TService>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton));
        }
        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));
        }
        public void RegisterSingleton<TService>(TService implementation)
        {
            _serviceDescriptors.Add(new ServiceDescriptor(implementation, ServiceLifetime.Singleton));
        }

        public void RegisterTransient<TService>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService //To make sure that theyll only accept the correct service
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));
        }

        public DIContainer GenerateContainer()
        {
            return new DIContainer(_serviceDescriptors);
        }
    }
}
