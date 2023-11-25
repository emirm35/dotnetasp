using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages

{
    public class DemoModel : PageModel
    {

        public String? FullName => HttpContext?.Session?.GetString("name") ?? "NoName";






        public void OnGet()
        {

        }
        //* parametrede model binding yapılcak
        public void OnPost([FromForm] string name)
        {
            //* name değerini class üzerinde değil session üzerinde tutucağız
            //  FullName = name;


            //* parametreden gelen değeri sesionda sakla
            HttpContext.Session.SetString("name", name);




        }

    }
}