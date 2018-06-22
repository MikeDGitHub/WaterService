using System;
using System.IO;
using System.Text;

namespace YuanXin.Framework
{
    public static class FileHelper
    {
        public static string ReadFile(string fileName)
        {
            var html = new StringBuilder();
            var encode = Encoding.UTF8;
            try
            {
                //读取模版
                html.Append(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, fileName), encode));
            }
            catch (FileNotFoundException ex)
            {
                throw;
            }
            return html.ToString();
        }
    }
}