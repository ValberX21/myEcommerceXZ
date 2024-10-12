using Azure;
using eCommerceXZ.Data.Interfaces;
using eCommerceXZ.Models.Models;

namespace eCommerceXZ.Payment
{
    public class MainPayment
    { 
        public void MainPaymentMethod(Customer customer, Order order)
        {

            object reciver = new
            {
                ReceiverId = "eCommerceXZ",
                Code = "19FJ4NSI8CS34"             
            };

            if (order.PaymentMethod == "Credit")
            {
                Credit creditPayment = new Credit()
                {
                    Receiver = reciver,
                    Payer = customer
                };

                creditPayment.ProcessCredtPayment();
            }

        }       
    }
}
