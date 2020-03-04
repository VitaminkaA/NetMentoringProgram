using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection.Container.Services
{
    public interface ICreator
    {
        object CreateInstance(Type type);
    }
}
