using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace UnitTesting
{
    public class BaseTestClass
    {
        protected readonly IUnityContainer UnityContainer;
        public BaseTestClass()
        {
            UnityContainer = UnityConfig.GetConfiguredContainer();
        }

    }
}
