using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//подключаить библиотеку для работы с файловой системой
using System.IO;
using System.Drawing;
using System.Threading;
namespace Searcher
{
    static class Program
    {
        static Form1 Myform = new Form1();
        //       Application.EnableVisualStyles();
        //       Application.SetCompatibleTextRenderingDefault(false);
        //       Application.Run(new Form1());
        //класс чтения параметров для поиска данных 

        
        //обработка нажатия клавиш на иконке 
        private static void notifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            //завершаем программу пока что 
            Myform.FormShow = true;
        }

    

        static void startApp() 
        {

            //создаем класс иконки в окне уведомлений
            NotifyIcon MyIcon = new NotifyIcon();
            //загружаем файл с иконкой 
            MyIcon.Icon = new Icon("JSB.ico");
            //показываем иконку в панели
            MyIcon.Visible = true;
            //добавляем обработчик нажатия клавиши на иконке 
            MyIcon.Click += notifyIcon1_DoubleClick;
            
            
            //запускаем форму в полет 
            Application.Run(Myform);


        }
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            
            startApp();

        }

    
    }
}
