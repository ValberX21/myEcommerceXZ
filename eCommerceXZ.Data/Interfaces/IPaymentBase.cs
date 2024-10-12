using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceXZ.Data.Interfaces
{
    public interface IPaymentBase
    {
        int PaymentId { get; }
        object Receiver { get; }
        object Payer { get; }
        decimal Total { get; }
        DateTime DtPayment { get; }

    }
}
