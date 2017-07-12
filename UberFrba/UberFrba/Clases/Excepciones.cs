using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    public class DNIDuplicadoException : Exception
    {
        public DNIDuplicadoException()
            : base() { }
    }

    public class TelefonoDuplicadoException : Exception
    {
        public TelefonoDuplicadoException()
            : base() { }
    }

    public class PatenteDuplicadoException : Exception
    {
        public PatenteDuplicadoException()
            : base() { }
    }
    public class RangoHorarioDuplicadoException : Exception
    {
        public RangoHorarioDuplicadoException()
            : base() { }
    }
}