using JAZ.Models;
using JAZ.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace JAZ.Controllers
{
    public class AccountsController : Controller
    {
        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {


            JazModel dc = new JazModel();
            ViewBag.DropDownList = new SelectList(new List<SelectListItem>{
        new SelectListItem { Text = "US", Value = "US"},
        new SelectListItem { Text = "CANADA", Value = "CANADA"}, }, "Text", "Value");
            return View(new User());
        }
        //Registration POST action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] User user)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {

                #region //Email is already Exist 
                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code 
                //user.ActivationCode = Guid.NewGuid();
                #endregion

                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);

                #endregion
                // user.IsEmailVerified = false;

                #region Save to Database
                using (JazModel jaz = new JazModel())
                {
                    jaz.Users.Add(user);
                    jaz.SaveChanges();

                    //Send Email to User
                    //SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
                    message = "Registration successfully done." + user.Email;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.DropDownList = new SelectList(new List<SelectListItem> { new SelectListItem { Text = "US", Value = "US" }, new SelectListItem { Text = "CANADA", Value = "CANADA" }, }, "Text", "Value");

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }
        //Verify Account  




        //Login 
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string ReturnUrl = "")
        {
            string message = "";
            using (JazModel jaz = new JazModel())
            {
                var v = jaz.Users.Where(a => a.Email == login.Email).FirstOrDefault();
                if (v != null)
                {


                    if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.Email, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Accounts");
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (JazModel jaz = new JazModel())
            {
                var v = jaz.Users.Where(a => a.Email == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }






    }
}
    
