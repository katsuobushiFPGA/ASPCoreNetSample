using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{
    public class JsonViewController : Controller
    {
        // JSONをパースするためのサンプルクラス
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
        }

        public IActionResult Index()
        {
            // サンプルJSON文字列
            string jsonString = "{\"Name\":\"山田太郎\",\"Age\":25,\"Email\":\"taro@example.com\"}";

            // JSONをC#オブジェクトにパース（デシリアライズ）
            Person person = JsonConvert.DeserializeObject<Person>(jsonString);
            ViewData["ParsedJson"] = $"名前: {person.Name}, 年齢: {person.Age}, メール: {person.Email}";

            // C#オブジェクトをJSON文字列に変換（シリアライズ）
            var newPerson = new Person { Name = "鈴木花子", Age = 28, Email = "hanako@example.com" };
            string serializedObject = JsonConvert.SerializeObject(newPerson, Formatting.Indented);
            ViewData["SerializedObject"] = serializedObject;

            return View();
        }
    }
}
