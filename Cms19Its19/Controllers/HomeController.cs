using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cms19Its19.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cms19Its19.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<ChatMessage> chatmessages = new List<ChatMessage>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Chat()
        {
            return View(new ChatMessageModel { List = chatmessages });
        }

        [HttpPost]
        public IActionResult Chat(ChatMessage message)
        {
            if(ModelState.IsValid)
            {
                chatmessages.Add(message);
            }
            return View(new ChatMessageModel { List = chatmessages, Title = message.Title, Text = message.Text, From = message.From });        }


        [Authorize]
        public IActionResult ListAccounts()
        {
            return View();
        }

        [Authorize]
        public IActionResult SeeTransactions(string id)
        {
            return View(model:id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
