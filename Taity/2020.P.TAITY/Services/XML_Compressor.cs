using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace _2020.P.TAITY.Services
{
    class XML_Compressor
    {
        [Serializable]
        public class History
        {
            /// <summary>
            /// Сохранение неких параметров в формате XML
            /// </summary>
            /// <param name="list">Коллекция параметров</param>
            public void Save(List<History> list)
            {
                XmlSerializer xser = new XmlSerializer(typeof(List<History>));
                using (FileStream fs = new FileStream("Settings.xml", FileMode.Create))
                {
                    xser.Serialize(fs, list);
                }
            }

            /// <summary>
            /// Десериализация некой структуры XML формата в коллекцию
            /// </summary>
            /// <returns>Коллекция <T> List</returns>
            public List<History> Deserialize()
            {
                XmlSerializer xser = new XmlSerializer(typeof(List<History>));
                using (FileStream fs = new FileStream("Settings.xml", FileMode.OpenOrCreate))
                {
                    try
                    {
                        return (List<History>)xser.Deserialize(fs);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        return new List<History>();
                    }
                }
            }
        }
    }
}
