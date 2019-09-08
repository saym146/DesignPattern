using System;

namespace ModelContract
{
    public interface ICustomer
    {
        string CustomerType { get; set; }
        string CustomerName { get; set; }
        double BillAmount { get; set; }
        string Dob { get; set; }
        string Address { get; set; }
        string Contact { get; set; }
        bool Validate();
    }
}
