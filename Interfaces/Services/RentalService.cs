using Interfaces.Entities;
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

        private BrazilTaxService _brazilTaxService = new BrazilTaxService(); //Dependência - BrazilTaxService

        public RentalService(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start); //Duração da locação
            double basicPayment = 0.0;
            if (duration.TotalHours <= 12)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours); //(Math.Ceiling) Arredonda pra cima
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _brazilTaxService.Tax(basicPayment); // Calcular valor imposto

            carRental.Invoice = new Invoice(basicPayment, tax); //Instanciado o invoince e associado com carRental
        }

    }
}
