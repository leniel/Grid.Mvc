using System.Web.Script.Serialization;

namespace GridMvc.Utility
{
    internal static class JsonHelper
    {
        /// <summary>
        ///     JSON Serialization
        /// </summary>
        public static string JsonSerializer<T>(T t)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(t);
        }

        /// <summary>
        ///     JSON Deserialization
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(jsonString);
        }
    }
}