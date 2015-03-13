using System.Security.AccessControl;
using System.Threading;

namespace MongoDbDatabase
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;

    public static class Json
    {
        public static string Stringify<T>(T obj)
        {
            string result;

            using (var stream = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(T));

                ser.WriteObject(stream, obj);
                stream.Position = 0;

                using (var sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }


            return result;
        }

        public static void SaveObjectToFile<T>(string pathFile, T obj)
        {
            var jsonString = Stringify(obj);
            using (var stream = new FileStream(pathFile, FileMode.Create))
            {
                stream.Position = 0;
                var streamWriter = new StreamWriter(stream);
                streamWriter.Write(jsonString);
                streamWriter.Close();
            }
        }
    }
}
