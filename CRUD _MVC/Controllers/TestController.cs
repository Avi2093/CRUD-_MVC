using CRUD__MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CRUD__MVC.Controllers
{
    public class TestController : Controller
    {
        AdventureWorksLTDataContext db = new AdventureWorksLTDataContext();
//-----------------------------------------------------------------------------------------------------------------
        //public ActionResult AllCustomers()
        //{
        //     return View(GetCustomers()); // Returning the function or method GetCustomers
        //}

        //IEnumerable<Customer>GetCustomers()   //   Created a function to return the entire list of Customers
        //{
        //    using (AdventureWorksLTDataContext db = new AdventureWorksLTDataContext())
        //    {
        //        return db.Customers.ToList();
        //    }

        //}
        //--------------------------------------------------------------------------------------------------------
        //References
        //How to return anonymous type result  --  https://stackoverflow.com/questions/534690/return-anonymous-type-results
        // My Question -- https://stackoverflow.com/questions/70785870/how-can-we-get-list-of-two-column-say-firstname-and-lastname-from-customer-table/70787827?noredirect=1#comment125142554_70787827

        public ActionResult FirstLastName()// Returning FirstName & LastName by creating a model class name CustViewModel
        {
            var Namelist = (IEnumerable<CustViewModel>)db.Customers.
                           Select(c => new CustViewModel { FirstName = c.FirstName, LastName = c.LastName });
            
            return View(Namelist);

            //return (IEnumerable<Customer>)db.Customers.Select(c => new Customer { FirstName = c.FirstName, LastName = c.LastName })
        }


        //public ActionResult FirstLastName1()
        //{
        //    var Name = (IEnumerable<Customer>)db.Customers.Select(c => new Customer { FirstName = c.FirstName, LastName = c.LastName });

        //    return View(Name);
        //}

        public ActionResult FirstLastName1()// Returning FirstName & LastName by creating a model class name CustomerView in AdventureWorksLT.designer.cs class(Linq-SQL procedure)
        {
            return View(GetData());
        }

        private IEnumerable<CustomerView> GetData()
        {
            using (AdventureWorksLTDataContext db = new AdventureWorksLTDataContext())
            {
                List<CustomerView> query = db.Customers.Select(c => new CustomerView { FirstName = c.FirstName, LastName = c.LastName }).ToList();
                //It will Cast it back to Customer
                return query;
            }
        }


















        //IEnumerable<Customer> GL()   
        //{
        //    using (AdventureWorksLTDataContext db = new AdventureWorksLTDataContext()) //Now we cannot use "using" , when we did got datacontext object using Linq to sql.
        //                                                                               //It will throw an error on View at foreach section 
        //                                                                               //ERROR =  "Cannot access a disposed object.  Object name: 'DataContext accessed after Dispose."
        //                                                                               // Therefore we use DeferredLoadingEnabled property on false when using the DataContext

        //    {
        //        db.DeferredLoadingEnabled = false;        //DeferredLoadingEnabled property used because we are creating using to create an object of AdventureWorksLTDataContext class achieved by Linq to Sql
        //        return (IEnumerable<Customer>)db.Customers.Select(c => new Customer { FirstName = c.FirstName, LastName = c.LastName });
        //    }

        //}















        //public ActionResult Testing()
        //{
        //    var list = db.Customers.ToList();
        //    var any = list.Select(c => new Customer { FirstName = c.FirstName, LastName = c.LastName });
        //    //ViewBag.Data = any;
        //    ViewBag.Data = any;

        //    //return View(db.Customers.ToList());
        //    return View(any);
        //}































































        //private AdventureWorksLTDataContext db = new AdventureWorksLTDataContext();
        // AdventureWorksLTDataContext db = new AdventureWorksLTDataContext();     -- Or write this for public 
        // GET: Test
        //public ActionResult index1()
        //{

        //    //Query Syntax
        //    List<Customer> list = db.Customers.Select(x => x).ToList();
        //     return View(list);









        //--------------Fetching FirstName and LastName from Customer Table using different syntax using CustViewModel class
        /*dynamic list = (from c in db.Customers
                        select new CustViewModel
                        {
                            FirstName = c.FirstName,
                            LastName = c.LastName
                        }).ToList();
        ViewData["lst"] = list;
        return View(ViewData["lst"]);*/


        //------------Write this in view----------------
        /*@foreach(var emp in (IEnumerable<CustViewModel>)ViewData["lst"])
           {
               < tr >
                   < td >
                       @emp.FirstName
                   </ td >
                   < td >
                       @emp.LastName
                   </ td >

               </ tr > */



        //}
    }
}








//Loading Customers only
//var cstList = db.Customers.ToList();
//return View(cstList);