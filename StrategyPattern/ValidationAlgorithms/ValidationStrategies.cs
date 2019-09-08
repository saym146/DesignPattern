using System;
using ModelContract;

namespace ValidationAlgorithms
{
    public class CustomerValidationAll : IValidation<ICustomer>
    {
        public bool Validate(ICustomer cust) //Design Pattern : Strategy Pattern
        {
            if (String.IsNullOrEmpty(cust.CustomerName))
            {
                throw new Exception("Customer Name is required");
            }
            else if (DateTime.Now.Year - Convert.ToDateTime(cust.Dob).Year <= 3)
            {
                throw new Exception("Please enter a valid Dob");
            }
            else if (cust.BillAmount <= 0)
            {
                throw new Exception("Bill Amount is required");
            }
            else if (String.IsNullOrEmpty(cust.Address))
            {
                throw new Exception("Customer Address is required");
            }
            else if (String.IsNullOrEmpty(cust.Contact))
            {
                throw new Exception("Customer Contact is required");
            }
            else
            {
                return true;
            }
        }
    }
    public class LeadValidation : IValidation<ICustomer>
    {
        public bool Validate(ICustomer cust)
        {
            if (String.IsNullOrEmpty(cust.CustomerName))
            {
                throw new Exception("Customer Name is required");
            }
            else if (String.IsNullOrEmpty(cust.Contact))
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
