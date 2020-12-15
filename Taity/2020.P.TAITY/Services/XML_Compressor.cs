using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using _2020.P.TAITY.Model;

namespace _2020.P.TAITY.Services
{
    class XML_Compressor
    {
        [Serializable]
        public class XSpace
        {
            /// <summary>
            /// Сериализация коллкций в XML формат
            /// </summary>
            /// <param name="collection">Коллекция</param>
            public void Serializ(FileOfProgram fileOf, List<XSpace> collection)
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<XSpace>));
                using (FileStream fs = new FileStream($"{fileOf}.xml", FileMode.Create))
                {
                    xs.Serialize(fs, collection);
                }
            }

            /// <summary>
            /// Сериализация объектов в XML формат
            /// </summary>
            /// <param name="line">Строковый параметр</param>
            public void Serializ(FileOfProgram fileOf, String line)
            {
                XmlSerializer xs = new XmlSerializer(typeof(String));
                using (FileStream fs = new FileStream($"{fileOf}.xml", FileMode.Create))
                {
                    xs.Serialize(fs, line);
                }
            }

            /// <summary>
            /// Десериализация структуры из XML формата
            /// </summary>
            /// <param name="fileOf">Перечесление типов хранимых файлов</param>
            /// <returns>Коллекция <T> List</returns>
            public List<XSpace> Deserialize(FileOfProgram fileOf)
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<XSpace>));
                using (FileStream fs = new FileStream($"{fileOf}.xml", FileMode.OpenOrCreate))
                {
                    try
                    {
                        return (List<XSpace>)xs.Deserialize(fs);
                    }
                    catch
                    {
                        return new List<XSpace>();
                    }
                }
            }

            /// <summary>
            /// Десериализация структуры из XML формата
            /// </summary>
            /// <param name="fileOf">Перечесление типов хранимых файлов</param>
            /// <returns>Строковое значение</returns>
            public String Deserialize_line(FileOfProgram fileOf)
            {
                XmlSerializer xs = new XmlSerializer(typeof(String));
                using (FileStream fs = new FileStream($"{fileOf}.xml", FileMode.OpenOrCreate))
                {
                    try
                    {
                        return (String)xs.Deserialize(fs);
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
    }
}
