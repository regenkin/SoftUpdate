using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SoftUpdate
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 定义窗口
            UpdateForm from = new UpdateForm();

            // 判断参数
            if (args.Length == 1)
            {
                from.DownZipUrl = args[0];
                from.DownFile();
                Application.Run(from);
            }
            else
            {
                MessageBox.Show("获取更新文件失败，请重试！");
                Application.Exit();
            }
        }
    }
}
