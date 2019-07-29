using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ormawa.Controllers
{
    public class AbstractBaseController : Controller
    {
        public const int NotifStatusError = 0;
        public const int NotifStatusSuccess = 1;

        public void SetErrorNotification(string message)
        {
            TempData["status"] = NotifStatusError;
            TempData["message"] = message;
        }

        public void SetSuccessNotification(string message)
        {
            TempData["status"] = NotifStatusSuccess;
            TempData["message"] = message;
        }

        public IActionResult RedirectBack()
        {
            var referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
        }

        /// <summary>  
        /// Get the cookie  
        /// </summary>  
        /// <param name="key">Key </param>  
        /// <returns>string value</returns>  
        public string Get(string key)
        {
            return Request.Cookies[key];
        }
        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, value, option);
        }
        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}
