using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Searcher
{
    public partial class Form1 : Form
    {

       public  bool FormShow = false;

        #region функции поиска файлов
        static Settings ParamForSearch = new Settings();

        /*функция поиска файлов в директории передаваемой в параметр patch 
         по его имени или маске передаваемой в параметре pattern
        */
         string[] SearchFile(string patch, string pattern)
        {
            /*флаг SearchOption.AllDirectories означает искать во всех вложенных папках*/
            string[] ReultSearch = Directory.GetFiles(patch, pattern, SearchOption.AllDirectories);
            //возвращаем список найденных файлов соответствующих условию поиска 
            return ReultSearch;
        }

        /*функция нахождения директорий в указанному пути*/
         string[] SearchDirectory(string patch)
        {
            //находим все папки в по указанному пути
            string[] ReultSearch = Directory.GetDirectories(patch);
            //возвращаем список директорий
            return ReultSearch;
        }
         void search()
        {
             //если файлы показаны на экране то искать не нужно 
            if (!FormShow)
            {
                //будем выводить в виде html содержимого пока что так 
                listBox1.Items.Clear();
                //маска для поиска файла 
                string createPatern = "*.";


                //получаем переменную Windows с адресом текущего пользователя
                string PatchProfile = Environment.GetEnvironmentVariable("USERPROFILE");
                //ищем все вложенные папки 
                string[] S = SearchDirectory(PatchProfile);
                //перебираем папки в директории пользователя
                foreach (string folderPatch in S)
                {
                    //получаем чистое имя папки 
                    DirectoryInfo dir = new DirectoryInfo(folderPatch);
                    //сравниваем с тем что указано в файле конфигурации
                    foreach (string DirName in ParamForSearch.Patchs)
                    {
                        //если названия совпали пробуем найти файлы с указанными расширениями 
                        if (dir.Name == DirName)
                        {
                            foreach (string Ext in ParamForSearch.Extension)
                            {
                                if (Ext != "")
                                {
                                    try
                                    {
                                        //ищем файлы 
                                        string[] ResultSearch = SearchFile(folderPatch, createPatern + Ext);
                                        //если есть полходящие добавляем их в список найденных файлов 
                                        foreach (string FF in ResultSearch)
                                        {
                                            listBox1.Items.Add(FF);
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }

                        }
                    }

                }
                if (listBox1.Items.Count > 0) FormShow = true;
            }
  

        }
        

        #endregion 


        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormShow = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //хадаем время следующего поиска файлов 
            timer1.Interval = ParamForSearch.sleep;
             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Visible = FormShow;

            search();
        }
        //получим чистый адресс без имени файла
        string GetPatchDir(string P)
        {
            if (P != "")
            {
                //возвращаем путь к папке а не к файлу
                return Directory.GetParent(P).FullName;
            }
            else return null;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //получаем пут к файлу 
            string Patch = GetPatchDir(listBox1.SelectedItem.ToString());
            //открываем папку с файлом 
            Process.Start("explorer.exe", Patch);
        }
    }
}
