using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Book
{
    public class Convert
    {
        //Convert object to Json
        public static void Convert_to_json(CookBook cookBook)
        {
            var jsonFormattedContent = Newtonsoft.Json.JsonConvert.SerializeObject(cookBook);
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var filepath = Path.Combine(projectFolder, @"..\..\Data.json");

            if (File.Exists(filepath) == false)
            {
                File.WriteAllText(filepath, jsonFormattedContent);
            }
            else
            {
                File.Delete(filepath);
            }
        }

        //Convert Json to Object
        public static CookBook Convert_to_object()
        {
            CookBook c = new CookBook();
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var filepath = Path.Combine(projectFolder, @"..\..\Data.json");

            if (File.Exists(filepath))
            {
                string justText = File.ReadAllText(filepath);
                c = Newtonsoft.Json.JsonConvert.DeserializeObject<CookBook>(justText);

                return (c);
            }
            else
            {
                return null;
            }

        }
    }
}
