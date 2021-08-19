using PixlparkApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace PixlparkApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ConnectToPixlpark connection = new ConnectToPixlpark();
            //Получить request token
            string requestToken = connection.GetRequestToken();
            //Получить токен доступа
            string accessToken = connection.GetAccessToken(requestToken);
            //Получить список заказов
            List<Order> orders = connection.GetOrderList(accessToken);
            return View(orders);

        }
    }
}