using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVarianceConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var _FullPath = @"C:\Users\NasledNIK\Pictures";

            var fileInfo = new FileInfo(_FullPath);

            var _Name = fileInfo.Name;
            var _CreatedDate = fileInfo.CreationTime;
            var _LastChangedDate = fileInfo.LastWriteTime;
            //var _ByteSize = fileInfo.Length;
            var files = Directory.GetDirectories(_FullPath);

            Console.ReadKey();
        }
    }
}
