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
            var ser = new DataContractJsonSerializer(typeof(T));
            var stream = new MemoryStream();

            ser.WriteObject(stream, obj);
            stream.Position = 0;

            var sr = new StreamReader(stream);
            var result = sr.ReadToEnd();

            stream.Dispose();
            sr.Dispose();

            return result;
        }

        public static void SaveObjectToFile<T>(string pathFile, T obj)
        {
            var jsonString = Stringify<T>(obj);
            var stream = new FileStream(pathFile, FileMode.Create);

            stream.Position = 0;
            var streamWriter = new StreamWriter(stream);
            streamWriter.Write(jsonString);
            streamWriter.Close();
            stream.Dispose();
        }
    }
}
