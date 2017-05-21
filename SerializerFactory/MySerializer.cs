using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace SerializerFactory {

    public static class MySerializer {

        //  Method Serialize Object T To XML
        public static string SerializeObjectToXml<T>(this T toSerialize) {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
            using (StringWriter xml = new StringWriter()) {
                xmlSerializer.Serialize(xml, toSerialize);
                xml.Close();
                return xml.ToString();
            }
        }

        //  Method Serialize Object T To JSON
        public static string SerializeObjectToJson<T>(this T toSerialize) {
            var json = JsonConvert.SerializeObject(toSerialize);
            return json.ToString();
        }

        //  Method Deserialize XML To Object T
        public static T DeserializeXmlToObject<T>(string xml) {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml)) {
                T mObject = (T) xmlSerializer.Deserialize(reader);
                reader.Close();
                return mObject;
            }
        }

        //  Method Deserialize JSON To Object T
        public static T DeserializeJsonToObject<T>(string json) {
            T mObject = JsonConvert.DeserializeObject<T>(json);
            return mObject;
        }

        //  Method Serialize List<Object> T To XML
        //  Method Serialize List<Object> T To JSON
        //  Method Deserialize XML To List<Object> T
        //  Method Deserialize JSON To List<Object> T
    }
}
