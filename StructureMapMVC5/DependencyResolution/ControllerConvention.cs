// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerConvention.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace StructureMapMVC5.DependencyResolution
{
    using System;
    using System.Web.Mvc;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using StructureMap.Graph.Scanning;
    using StructureMap.Pipeline;
    using StructureMap.TypeRules;
    using System.Collections.Generic;
    using System.Linq;
    public class ControllerConvention : IRegistrationConvention
    {
        #region Public Methods and Operators

        public void Process(Type type, Registry registry)
        {
            if (type.CanBeCastTo<Controller>() && !type.IsAbstract)
            {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }

        public void ScanTypes(TypeSet types, Registry registry)
        {
            //https://structuremap.github.io/registration/auto-registration-and-conventions/
            // Only work on concrete types
            foreach (Type type in types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed))
            {
                // Register against all the interfaces implemented
                // by this concrete class
                foreach (Type @interface in type.GetInterfaces())
                {
                    registry.For(@interface).Use(type);
                }
            }
        }

        #endregion
    }
}