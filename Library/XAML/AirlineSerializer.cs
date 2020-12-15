using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Library.JSON
{
    public class AirlineSerializer
    {
        DataContractSerializer serializer;
        public AirlineSerializer()
        {
            
            serializer = new DataContractSerializer(typeof(Airline));
        }

        public void SaveData(string filename, Airline obj)
        {
            FileStream writer = new FileStream(filename, FileMode.Create);
            serializer.WriteObject(writer, obj);
            writer.Close();

        }

        public Airline LoadData(string filename)
        {
            if (!File.Exists(filename)) throw new ArgumentException("File must exists");
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

                // Deserialize the data and read it from the instance.
                Airline deserializedAirline = (Airline)serializer.ReadObject(reader, true);
                reader.Close();
                fs.Close();
                return deserializedAirline;
            }
            catch (Exception e)
            {
                throw new Exception("File has incorrect format", e);
            }
        }
    }
}
