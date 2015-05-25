using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace TravelCorp.domain
{
    public static class SerializationHelper
    {
     
        public static string DataContractSerialize<T>(Encoding encoding, T entity)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, entity);
                return encoding.GetString(ms.ToArray());
            }
        }
    
        public static string DataContractSerialize<T>(T entity)
        {
            return DataContractSerialize(Encoding.UTF8, entity);
        }
      
        public static T DataContractDeserialize<T>(Encoding encoding, string entity)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream(encoding.GetBytes(entity)))
            {
                return (T)serializer.ReadObject(ms);
            }
        }
      
        public static T DataContractDeserialize<T>(string entity)
        {
            return DataContractDeserialize<T>(Encoding.UTF8, entity);
        }


    }
}
