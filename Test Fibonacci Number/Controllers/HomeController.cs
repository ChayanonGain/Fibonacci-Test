using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test_Fibonacci_Number.Models;

namespace Test_Fibonacci_Number.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult FibonacciNumber(int numPost, int plusnumber, int minusNember)
        {
             ViewData["CurrentFilter"] = numPost;
            if (numPost == 0 && plusnumber == 0 && minusNember == 0)
            {
                int FiNumber = FindFibonacci(numPost);
                ViewData["FibonacciNumber"] = FiNumber;               
            }
            else if(numPost > 0 && plusnumber == 0 && minusNember == 0)
            {
                int FiNumber1 = FindFibonacci(numPost);
                ViewData["FibonacciNumber"] = FiNumber1;
            }
            else if (numPost >= 0 && plusnumber > 0 && minusNember == 0)
            {
                int result = numPost + plusnumber;
                int FiNumber2 = FindFibonacci(result);
                ViewData["FibonacciNumber"] = FiNumber2;
                ViewData["CurrentFilter"] = result;
            }
            else if (numPost == 0 && plusnumber == 0 && minusNember <= 0)
            {
                TempData["ErrorMassage"] = "ไม่มีค่าต่ำกว่า 0";
            }
            else if (numPost > 0 && plusnumber == 0 && minusNember <= 0)
            {
                int result = numPost + minusNember;
                int FiNumber1 = FindFibonacci(result);
                ViewData["FibonacciNumber"] = FiNumber1;
                ViewData["CurrentFilter"] = result;
            }

            return View();
        }

        public static int FindFibonacci(int n)
        {
            int p = 0;
            int q = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = p;
                p = q;
                q = temp + q;
            }
            return p;
        }
    }
}
