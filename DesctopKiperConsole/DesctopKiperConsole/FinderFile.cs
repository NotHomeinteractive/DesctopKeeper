using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace DesctopKiperConsole
{
    class FinderFile
    {
        //папка где ищем данные 
        public string SorceFolderName;
        //название файлов или их расширение
        public string FilePatern;
        //папка куда будем сбрасывать файлы
        public string DestFolderName;

        //получим чистый адресс без имени файла
        string GetPatchDir(string P)
        {
            if (P != "")
            {
                string CurrentDir = Directory.GetParent(P).FullName;
                //возвращаем путь к папке а не к файлу
                return Directory.GetParent(CurrentDir).FullName;
            }
            else return null;
        }

        public void FindFile() 
        {
            //находим все файлы в казанной директории
            string[] SerchFile = Directory.GetFiles(SorceFolderName, FilePatern);

            foreach (string F in SerchFile) 
            {
                //найденный файл
                Console.WriteLine("найденный файл  " + F + GetPatchDir(F));
                //папка файла
            }
            
        }
    }
}
