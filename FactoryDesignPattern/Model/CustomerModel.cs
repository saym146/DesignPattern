using System;
using ModelContract;

namespace Model
{
    public abstract class CustomerBase : ICustomer
    {
        public string CustomerType { get; set; }
        public string CustomerName { get; set; }
        public double BillAmount { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        public virtual bool Validate()
        {
            throw new Exception("Method not available");
        }
    }
    public class Customer : CustomerBase
    {
        public override bool Validate()
        {
            if (String.IsNullOrEmpty(this.CustomerName))
            {
                throw new Exception("Customer Name is required");
            }
            else if (DateTime.Now.Year - Convert.ToDateTime(this.Dob).Year <= 3)
            {
                throw new Exception("Please enter a valid Dob");
            }
            else if (this.BillAmount <=0)
            {
                throw new Exception("Bill Amount is required");
            }
            else if (String.IsNullOrEmpty(this.Address))
            {
                throw new Exception("Customer Address is required");
            }
            else if (String.IsNullOrEmpty(this.Contact))
            {
                throw new Exception("Customer Contact is required");
            }
            else
            {
                return true;
            }
        }
    }
    public class Lead : CustomerBase
    {
        public override bool Validate()
        {
            if (String.IsNullOrEmpty(this.CustomerName))
            {
                throw new Exception("Customer Name is required");
            }
            else if (String.IsNullOrEmpty(this.Contact))
            {
                throw new Exception("Customer Contact is required");
            }
            else
            {
                return true;
            }
        }
    }
}
