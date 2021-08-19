using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace PixlparkApp.Models
{
    public class ConnectToPixlpark
    {
        //Получение токена запроса
        public string GetRequestToken()
        {
            string response = GetRequest("http://api.pixlpark.com/oauth/requesttoken");
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            return values["RequestToken"];
        }
        //Получение токена доступа по полученному токену и реквизитам для входа
        public string GetAccessToken(string requestToken, 
            string publicKey = "38cd79b5f2b2486d86f562e3c43034f8", 
            string privateKey = "8e49ff607b1f46e1a5e8f6ad5d312a80")
        {
            //Получить хэш для конткатенации токена запроса и приватоного ключа
            string password = GetSha1String(requestToken + privateKey);
            string response = GetRequest(string.Format("http://api.pixlpark.com/oauth/accesstoken?oauth_token={0}&grant_type=api&username={1}&password={2}",
                requestToken, publicKey, password));
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            return values["AccessToken"];
        }
        //Получить список заказов
        public List<Order> GetOrderList(string accessToken)
        {
            string ordersJSON = GetRequest(string.Format("http://api.pixlpark.com/orders?oauth_token={0}", accessToken));
            Response response = JsonConvert.DeserializeObject<Response>(ordersJSON);
            return response.Orders;
        }
        //get - запрос по указанному адресу
        //Возвращает даннные
        private string GetRequest(string Url)
        {
            WebRequest req = WebRequest.Create(Url);
            using (WebResponse resp = req.GetResponse())
            {
                using (Stream stream = resp.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
        //Вычисление хэша для указанной строки
        public string GetSha1String(string source)
        {
            using (SHA1 sha1Hash = SHA1.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }
    }
}