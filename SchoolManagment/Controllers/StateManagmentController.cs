using Microsoft.AspNetCore.Mvc;

namespace SchoolManagment.Controllers
{
    public class StateManagmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region TempData
        /*
         • Derived from TempDataDictionary class
         • Used to pass data from the current request to the next request
         • TempData dictionary is used to share data between controller actions.
         • It helps to maintain the data when we move from one controller to another controller or from one action to another action
         • The value of TempData persists until it is read or until the current user’s session times out.
         • By default, the TempData saves its content to the session state.
         • It requires typecasting for complex data type and checks for null values to avoid error. 
         • Generally, it is used to store only one time messages like the error messages and validation messages
         • Always do null check and do necessary action if TempData is null
        */
        public IActionResult setTempData()
        {
            string Name = "ahmed";
            TempData["Key01"] = Name;
            return Content("TempData saved");
        }
        //tempData first request
        public IActionResult GetTempData()
        {
            string Name = "empty";
            if (TempData.ContainsKey("Key01"))
            {
                Name = TempData["Key01"].ToString();
                //TempData.Keep(); //to Keep the data for second Request
                TempData.Peek("Key01"); // returns an obj without marking the Key for deletetion
                return Content(Name);
            }

            return Content(Name);
        }
        //tempData second request
        public IActionResult GetT01empData()
        {
            string Name = "ahmed";
            TempData["Key01"] = Name;
            return Content("TempData saved");
        }
        #endregion
     
        #region Session
        /*

         • a mechanism that enables you to store and retrieve user specific values temporarily. 
         • The default time is 20 minutes (but can be configured if necessary).
         • This information is Store in a global storage that is accessible from all pages in the Web application per User.


        */
        //set session Value
        public IActionResult SetSession()
        {
            string str = "ContentToSaveInSession";
            HttpContext.Session.SetString("Key01", str);
            return Content("Session Saved");
        }

        public IActionResult getSession()
        {
            string str = "empty";
            str = HttpContext.Session.GetString("Key01");
            return Content($"Session get {str} ");
        }



        #endregion

        #region Cookies
        //Set Cookie
        public IActionResult SetCookie()
        {
            Response.Cookies.Append("Key", "SomeThingFromInput");
            return Content("save Cookie");
        }

        //Get cookie
        public IActionResult getCookie()
        {
            var result = Request.Cookies["Key"];
            return Content($"Cookie {result}");
        } 
        #endregion
    }

}
