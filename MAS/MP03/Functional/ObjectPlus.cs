using MP02.Functional;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MP02
{

    public class ObjectPlus
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };
        private static Dictionary<Type, List<ObjectPlus>> AllExtents { get; set; } = new Dictionary<Type, List<ObjectPlus>>();

        public ObjectPlus()
        {
            List<ObjectPlus> extent = null;
            Type theClass = this.GetType();

            if (AllExtents.ContainsKey(theClass))
            {
                extent = AllExtents[theClass];
            }
            else
            {
                extent = new List<ObjectPlus>();
                AllExtents.Add(theClass, extent);
            }
            extent.Add(this);
        }
        public static void WriteExtents(StreamWriter stream)
        {
            string output = JsonConvert.SerializeObject(AllExtents, Formatting.Indented, settings);
            stream.Write(output);

            Console.WriteLine("Serialization completed.");
        }
        public static void ReadExtents(StreamReader stream)
        {
            string input = stream.ReadToEnd();
            AllExtents = JsonConvert.DeserializeObject<Dictionary<Type, List<ObjectPlus>>>(input, settings);

            Console.WriteLine("Deserialization completed.");
        }
        public static IEnumerable<T> GetExtent<T>() where T : ObjectPlus
        {
            if (AllExtents.ContainsKey(typeof(T)))
            {
                var extents = AllExtents[typeof(T)].AsEnumerable();
                var result = new List<T>();
                foreach (var ex in extents)
                {
                    result.Add((T)ex);
                }
                return result;
            }
            throw new ClassNotFoundException($"Extent not found for type: {typeof(T).ToString()}");
        }
        public static void ShowExtent<T>(bool json = false) where T : ObjectPlus
        {
            List<ObjectPlus> extent = null;
            if (AllExtents.ContainsKey(typeof(T)))
            {
                extent = AllExtents[typeof(T)];
            }
            else
            {
                throw new Exception("Unknown class " + typeof(T));
            }
            Console.WriteLine("Extent of the class: " + typeof(T).Name);
            foreach (ObjectPlus obj in extent)
            {
                Console.WriteLine(json == true ? obj.ToStringJSON() : obj.ToString());
            }
        }

        public override string ToString()                                               // Przesłonięcie metody
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append(": ");

            var properties = this.GetType().GetProperties();
            foreach (var prop in properties)
            {
                sb.Append($"\r\n\t{prop.Name}: {prop.GetValue(this, null)}");
            }
            sb.Append($"\r\n");

            return sb.ToString();
        }
        public string ToStringJSON()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{{");

            var properties = this.GetType().GetProperties();
            foreach (var prop in properties)
            {
                sb.Append($"\r\n\t\"{prop.Name}\": \"{prop.GetValue(this, null)}\"");
            }
            sb.Append($"\r\n}}");

            return sb.ToString();
        }
    }
}
