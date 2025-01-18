using System.IO;
using System.Xml.Serialization;

namespace List3
{
    public class Serialization
    {
        public static T DeserializeToObject<T>(string filePath) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StreamReader sr = new StreamReader(filePath))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public static void SerializeToXml<T>(T anyObject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyObject.GetType());

            using (StreamWriter writer = File.CreateText(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyObject);
            }
        }
    }
}
