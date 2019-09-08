using System;
using ModelContract;

namespace Model
{
    public class CustomerBase : ICustomer
    {
        private IValidation<ICustomer> _Validation;
        public string CustomerType { get; set; }
        public string CustomerName { get; set; }
        public double BillAmount { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public CustomerBase()
        {
            CustomerType = "";
            CustomerName = "";
            BillAmount = 0;
            Dob = "";
            Address = "";
            Contact = "";
        }
        public CustomerBase(IValidation<ICustomer> validation)
        {
            _Validation = validation;
        }


        public virtual bool Validate()
        {
            return _Validation.Validate(this);
        }
    }
    public class Customer : CustomerBase
    {
        public Customer(IValidation<ICustomer> obj) : base(obj)
        {

        }
    }
    public class Lead : CustomerBase
    {
        public Lead(IValidation<ICustomer> obj) : base(obj)
        {

        }
    }
}
