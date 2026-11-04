using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public interface PersonInterface
    {
        string Name { get; }
        string Surname { get; }
        int Age { get; }
        char Gender { get; }
    }
}
