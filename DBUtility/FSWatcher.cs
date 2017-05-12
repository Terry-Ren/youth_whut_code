using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace AUTO.Utility
{
    public class FSWatcher:BasePage
    {
        //static int count = 0;
        static FileSystemWatcher watcher = new FileSystemWatcher();
        static int eventCount = 0;
        string baseURL = HttpRuntime.AppDomainAppPath.ToString() + "js\\ckfinder\\userfiles\\images\\";
        static bool IsWaterMark = false; 

        //static List<string> files = new List<string>();

        public FSWatcher()
        {
            WatcherStrat(baseURL, "*.*", true, true);
        }


        /// <summary>
        /// 初始化监听
        /// </summary>
        /// <param name="StrWarcherPath">需要监听的目录</param>
        /// <param name="FilterType">需要监听的文件类型(筛选器字符串)</param>
        /// <param name="IsEnableRaising">是否启用监听</param>
        /// <param name="IsInclude">是否监听子目录</param>
        private static void WatcherStrat(string StrWarcherPath, string FilterType, bool IsEnableRaising, bool IsInclude)
        {
            //初始化监听
            watcher.BeginInit();
            //设置监听文件类型
            watcher.Filter = FilterType;
            //设置是否监听子目录
            watcher.IncludeSubdirectories = IsInclude;
            //设置是否启用监听?
            watcher.EnableRaisingEvents = IsEnableRaising;
            //设置需要监听的更改类型(如:文件或者文件夹的属性,文件或者文件夹的创建时间;NotifyFilters枚举的内容)
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            //设置监听的路径
            watcher.Path = StrWarcherPath;
            //注册创建文件或目录时的监听事件
            watcher.Created += new FileSystemEventHandler(watch_created);
            //注册当指定目录的文件或者目录发生改变的时候的监听事件
            //watcher.Changed += new FileSystemEventHandler(watch_changed);
            //注册当删除目录的文件或者目录的时候的监听事件
           // watcher.Deleted += new FileSystemEventHandler(watch_deleted);
            //当指定目录的文件或者目录发生重命名的时候的监听事件
            //watcher.Renamed += new RenamedEventHandler(watch_renamed);
            //结束初始化
            watcher.EndInit();
        }

        /// <summary>
        /// 创建文件或者目录时的监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private static void watch_created(object sender, FileSystemEventArgs e)
        {

            //事件内容
            waterMarker wM = new waterMarker();
              //if(!IsWaterMark)
              //{
                  IsWaterMark = true;
                  Thread.Sleep(800);
                  wM.waterMark(e.FullPath, "理工青年", e.FullPath, 50, 0.3f, 70);
             //}
             //else
             //{
             //    IsWaterMark=false;
             //}
            
        }

        /// <summary>
        /// 当指定目录的文件或者目录发生改变的时候的监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private static void watch_changed(object sender, FileSystemEventArgs e)
        //{
        //    //事件内容
        //    //事件内容
        //    output("change:" + e.FullPath);
        //}
        /// <summary>
        /// 当删除目录的文件或者目录的时候的监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private static void watch_deleted(object sender, FileSystemEventArgs e)
        //{
        //    //事件内容
        //    output("del:" + e.FullPath);
        //}
        /// <summary>
        /// 当指定目录的文件或者目录发生重命名的时候的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private static void watch_renamed(object sender, RenamedEventArgs e)
        //{
        //    //事件内容
        //    output("rename:" + e.FullPath);
        //}
        /// <summary>
        /// 启动或者停止监听
        /// </summary>
        /// <param name="IsEnableRaising">True:启用监听,False:关闭监听</param>
        //private void WatchStartOrSopt(bool IsEnableRaising)
        //{
        //    watcher.EnableRaisingEvents = IsEnableRaising;
        //}
        //private static void output(string text)
        //{
        //    //FileStream fs = new FileStream("D:\\listen.txt", FileMode.Append);
        //    //StreamWriter sw = new StreamWriter(fs, Encoding.Default);
        //    //sw.WriteLine(text);
        //    //sw.Close();
        //    //fs.Close();
        //    //files.Add(text);
        //    eventCount++;
        //}

    }
}
