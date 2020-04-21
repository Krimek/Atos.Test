using System;
using System.Collections.Generic;
using System.Text;

namespace Atos.Test.Application.Infrastructure
{
    public interface ICommandHandler <in T>
    {
        void Handle(T command);
    }
}
