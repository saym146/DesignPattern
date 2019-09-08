using Factory;
using ModelContract;
using System;
using System.Web.Mvc;

namespace Web.CustomerClient.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomer _Customer = null;
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndexPost()
        {
            try
            {
                _Customer = CustomerFactory.GetInstance(Request.Form["CustomerType"]);
                if(_Customer!=null)
                {
                    double billAmt = 0;
                    _Customer.CustomerType = Request.Form["CustomerType"];
                    _Customer.CustomerName = Request.Form["CustomerName"];
                    _Customer.Dob = Request.Form["Dob"];
                    _Customer.Contact = Request.Form["Contact"];
                    Double.TryParse(Request.Form["BillAmount"], out billAmt);
                    _Customer.BillAmount =billAmt;
                    _Customer.Address = Request.Form["Address"];
                    if (_Customer.Validate())
                    {
                        ShowMsg("Success");
                        return View("Index",_Customer);
                    }
                    else
                    {
                        ShowMsg("Error : Validation Failed...");
                        return View("Index",_Customer);
                    }
                }
                else
                {
                    ShowMsg("Error : No Data Found!!!");
                    return View("Index", _Customer);
                }
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
                return View("Index", _Customer);
            }
        }

        private void ShowMsg(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");
        }
    }
}