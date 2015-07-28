using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Searcher
{
    public class ConfigFilds
    {
        [XmlElement("REM_1")]
        public string REM_1 = "папки для поиска в профиле перечисляем через ; например Desktop;Мои документы; и так далее";
        [XmlElement("Patchs")]
        public string Patchs = "Desktop;Мои документы;";
        [XmlElement("REM_2")]
        public string REM_2 = "расширения файлов которые нужно убрать с рабочего стола перечисляем через запятую jpeg;png;avi";
        [XmlElement("Extension")]
        public string Extension = "png;jpeg;avi";
        [XmlElement("REM_3")]
        public string REM_3 = "Пауза между проверками в секундах";
        [XmlElement("Pausa")]
        public int Pausa = 10;

    }

    class Settings
    {
        public ConfigFilds Parametrs = new ConfigFilds();
        //создаем класс сохранения данных
        XmlSerializer s = new XmlSerializer(typeof(ConfigFilds));
        
        //фнкция чтения данных из параметров 
        string[] Parser(string Params) 
        {
            return Params.Split(';');
        }
        //список путей по которым нужно искать данные 
        public string[] Patchs { 
            get {
                //загружаем настроки
                LoadParam();
                //читаем данные 
                return Parser(Parametrs.Patchs);
            } 
        } 
        //список расширений файлы с которыми мы будем искать 
        //список путей по которым нужно искать данные 
        public string[] Extension
        {
            get
            {
                //загружаем настроки
                LoadParam();
                //читаем данные 
                return Parser(Parametrs.Extension);
            }
        }
        //поле для хранения времени задержки перед следующей проверкой
        public int sleep
        {
            get
            {
                //загружаем настроки
                LoadParam();
                //читаем данные 
                return Parametrs.Pausa*100;
            }
        } 
      
        //сохранение параметров 
        public void SaveParam()
        {

            //создаем поток записи в файл
            StringWriter stringWriter = new StringWriter();
            //записываем данные 
            s.Serialize(stringWriter, Parametrs);

            string xml = stringWriter.ToString();
            File.WriteAllText("config.xml", xml);

        }
        //загрузка параметров
        public void LoadParam()
        {
            //если файла настройки нет то создаем его заново
            if (!File.Exists("config.xml")) SaveParam();
            var stringReader = new StringReader(File.ReadAllText("config.xml"));
            Parametrs = s.Deserialize(stringReader) as ConfigFilds;
        }

    }
}
