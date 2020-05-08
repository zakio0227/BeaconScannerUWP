using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;




namespace BeaconScannerUWP.UWP
{
    class ConnectWebAPI
    {
        private string baseUrl = "http://192.168.2.10:7777/api/";
        string responseString;

        public async Task<HttpResponseMessage> CallWebApi(string url, Dictionary<string, string> dictionary)
        {
            //WebAPIを呼び出す
            HttpResponseMessage response;
            try
            {
                var httpClient = new HttpClient();

                var json = JsonConvert.SerializeObject(dictionary);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                response = await httpClient.PostAsync(url, content);
            }
            catch (Exception ex) //WebAPI呼び出しに失敗した場合
            {
                response = null;
            }

            return response;

        }

        /// <summary>
        /// json文字列をオブジェクトにデシリアライズする
        /// </summary>
        public static T JsonToObject<T>(string jsonString)
        {
            var _responseContentObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
            return _responseContentObject;
        }

        public async Task<DataTable> callDatabase(string sqlString)
        {

            //URLを指定する
            var url = baseUrl + "SelectSql";

            //入力データ
            var inputDictionary = new Dictionary<string, string>
                    {
                        { "sql", $"{sqlString}" },
                    };

            HttpResponseMessage httpResponseMessage = await CallWebApi(url, inputDictionary);

            if (httpResponseMessage == null)
            {
                return null;
            }

            //文字列に直す データが入っている物体、デシリアライズ前
            responseString = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonToObject<DataTable>(responseString);

        }


    }
}
