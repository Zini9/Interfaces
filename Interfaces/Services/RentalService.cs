using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    internal class RentalService
    {

        public double PricePerHour { get; private set; } // (private) Proteger para que valores não sejam alterados
        public double PricePerDay { get; private set; }

    }
}
