using eCommerceXZ.Data.Interfaces;

namespace eCommerceXZ.Payment
{
    public class Credit : IPaymentBase
    {
        public int PaymentId { get;  set; }
        public object Receiver { get;  set; }
        public object Payer { get;  set; }
        public decimal Total { get;  set; }
        public DateTime DtPayment { get;  set; }

        //Specific
        public string CardNumber { get;  set; }
        public DateTime ExpirationDate { get;  set; } = DateTime.Now;   

        public void ProcessCredtPayment()
        {
            Total += (Total * 1.10m);

            if (ExpirationDate < DateTime.Now)
            {
                throw new InvalidOperationException("The credit card has expired.");
            }

            // Payment processing logic here (e.g., calling a payment gateway)
        }
    }

}
