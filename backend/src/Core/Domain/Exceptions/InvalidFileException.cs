using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Exceptions;

public class InvalidFileException : Exception
{
    public InvalidFileException(string message) : base(message)
    {
        
    }
}
