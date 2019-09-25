using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SoftUpdate
{
    public partial class UpdateForm : Form
    {
        /// <summary>
        /// 启动命令 
        /// 里面包含了下载文件地址
        /// </summary>
        public string DownZipUrl { get; set; }

        /// <summary>
        /// 本地Zip路径
        /// </summary>
        public string LocalZipPath
        {
            get { return Directory.GetCurrentDirectory() + "/" + Path.GetFileName(DownZipUrl); }
        }

        /// <summary>
        /// 启动App目录
        /// </summary>
        public string StartAppName
        {
            get
            {
                return Directory.GetCurrentDirectory() + "/" + AppName + ".exe";
            }
        }

        /// <summary>
        /// 主进程名称
        /// </summary>
        public string AppName = "Main";

        /// <summary>
        /// 构造方法
        /// </summary>
        public UpdateForm()
        {
            InitializeComponent();

            // 最大化最小化隐藏
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }


        #region 更新方法

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <returns></returns>
        public bool DownFile()
        {
            TxtMsg.Text = "开始下载更新文件";

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.DownloadFileCompleted += client_DownloadFileCompleted;
                    webClient.DownloadProgressChanged += client_DownloadProgressChanged;
                    webClient.DownloadFileAsync(new Uri(DownZipUrl), Path.GetFileName(DownZipUrl));
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 下载进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.ProgressBarUpdate.Minimum = 0;
            this.ProgressBarUpdate.Maximum = (int)e.TotalBytesToReceive;
            this.ProgressBarUpdate.Value = (int)e.BytesReceived;
            this.TxtMsg.Text = e.ProgressPercentage + "%";
        }

        /// <summary>
        /// 下载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.TxtMsg.Text = "开始解压";

                // 杀掉使用进程
                KillProcess(AppName);

                // 延时
                TimerHelper.Delay(3);

                // 解压缩
                ZipHelper.UnZip(LocalZipPath, Directory.GetCurrentDirectory());

                // 移除压缩包
                File.Delete(LocalZipPath);

                // 启动软件
                StartApp();
            }
        }


        /// <summary>
        /// 启动更新后进程
        /// </summary>
        public void StartApp()
        {
            Process.Start(StartAppName);
            Application.Exit();
        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="processName">进程名</param>
        private void KillProcess(string processName)
        {
            Process[] myproc = Process.GetProcesses();
            foreach (Process item in myproc)
            {
                
                if (item.ProcessName == processName)
                {
                    item.Kill();
                }
            }
        }
        #endregion
    }
}
