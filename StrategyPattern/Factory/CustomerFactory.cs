using System.Collections.Generic;
using Model;
using ModelContract;
using ValidationAlgorithms;

namespace Factory
{
    public class CustomerFactory //Design Pattern : Simple Factory
    {
        private static Dictionary<string, ICustomer> _CustomerTypes = null; // Design Pattern : RIP principle
        public static ICustomer GetInstance(string type)
        {
            if (_CustomerTypes == null)
            {
                _CustomerTypes = new Dictionary<string, ICustomer>();
                _CustomerTypes.Add(key: "C", value: new Customer(new CustomerValidationAll()));
                _CustomerTypes.Add(key: "L", value: new Lead(new LeadValidation()));
            }
            return _CustomerTypes[type];
        }
    }
}
