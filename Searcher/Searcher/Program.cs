using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//подключаить библиотеку для работы с файловой системой
using System.IO;
namespace Searcher
{
    static class Program
    {
        
        //       Application.EnableVisualStyles();
        //       Application.SetCompatibleTextRenderingDefault(false);
        //       Application.Run(new Form1());


        /*функция поиска файлов в директории передаваемой в параметр patch 
         по его имени или маске передаваемой в параметре pattern
        */
        static string[] SearchFile(string patch, string pattern)
        {
            /*флаг SearchOption.AllDirectories означает искать во всех вложенных папках*/
            string[] ReultSearch = Directory.GetFiles(patch, pattern, SearchOption.AllDirectories);
            //возвращаем список найденных файлов соответствующих условию поиска 
            return ReultSearch;
        }

        /*функция нахождения директорий в указанному пути*/
        static string[] SearchDirectory(string patch)
        {
            //находим все папки в по указанному пути
            string[] ReultSearch = Directory.GetDirectories(patch);
            //возвращаем список директорий
            return ReultSearch;
        }


        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //получаем текущее время
            DateTime Currenttime = DateTime.Now;
           
            //получаем переменную Windows с адресом текущего пользователя
            string PatchProfile = Environment.GetEnvironmentVariable("USERPROFILE");
            //PatchProfile = @"D:\";
            //ищем все вложенные папки 
            string[] S = SearchDirectory(PatchProfile);
            //создаем строку в которой соберем все пути
            string ListPatch="найденные файлы \n"; //заголовок для строк
            foreach (string folderPatch in S) 
            {
                //добавляем новую строку в список
               // ListPatch += folderPatch + "\n";
                try
                {
                    //пытаемся найти данные в папке 
                    string[] F = SearchFile(folderPatch, "*.png");
                    foreach (string FF in F) 
                    {
                        //добавляем файл в список 
                        ListPatch += FF + "\n";
                    }
                }
                catch 
                { 
                }
            }
            //получаем текущее время
            DateTime FinishTime = DateTime.Now;


            //выводим список на экран 
            MessageBox.Show("поиск занял " + (FinishTime - Currenttime).ToString() + " найдено " + ListPatch);
        }
    }
}
