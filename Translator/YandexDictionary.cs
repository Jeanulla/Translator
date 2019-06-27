using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Translator
{
    class YandexDictionary
    {
        public string Finder(string s, string lang, bool part, bool tr, bool ex, bool extext)
        {
            string result = "";
            if (s.Length > 0)
            {
                
                WebRequest request = WebRequest.Create("https://dictionary.yandex.net/api/v1/dicservice.json/lookup?"
                    + "key=YOUR KEY"
                    + "&lang=" + lang
                    + "&text=" + s);

                WebResponse response = request.GetResponse();

                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    string line;
                    if ((line = stream.ReadLine()) != null)
                    {
                        
                        dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(line);
                        for (var i=0; i<json.def.Count; i++)
                        {
                            result += json.def[i].text + "\r\n";
                            if( part == true)
                                result += json.def[i].pos + "\r\n";
                            if (tr == true)
                                result +=  json.def[i].ts + "\r\n";
                            for (var j = 0; j < json.def[i].tr.Count; j++)
                            {
                                result += json.def[i].tr[j].text + "\r\n";
                                if (json.def[i].tr[j].ex != null)
                                    for (var k = 0; k < json.def[i].tr[j].ex.Count; k++)
                                    {
                                        if (ex == true)
                                            result += json.def[i].tr[j].ex[k].text + "\r\n";
                                        if (extext == true)
                                            result += json.def[i].tr[j].ex[k].tr[0].text + "\r\n";
                                    }
                                    result += "\r\n";
                            }
                            result += "\r\n";

                        }
                        result += "\r\n";
                        return result;
                    }
                }
            }
            return "Выберете язык и введите валидный запрос!";
        }
    }

        class Find
        {
            public Def[] def { get; set; }
        }
        // public string text { get; set; }
        //public string head { get; set; }
        public class Def
        {
            public string text { get; set; }
            public string pos { get; set; }
            public string ts { get; set; }
            public Tr[] tr { get; set; }
        }
        public class Tr
        {
            public string text { get; set; }
            public string pos { get; set; }
            public Ex[] ex { get; set; }

      }
        public class Ex
    {
        public string text { get; set; }
        public Tr[] tr { get; set; }
    }
}
