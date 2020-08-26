using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class PathTools
{
    static string rootPath = "tmp";
    static string foldName;
    static void CreateRootFolder()
    {
        if (!Directory.Exists(rootPath))
        {
           var d = Directory.CreateDirectory(rootPath);
            File.SetAttributes(rootPath, FileAttributes.Hidden);
        }
    }
    public static string RootPath;
    /// <summary>
    /// 以文件夹名字命名
    /// </summary>
    /// <param name="fileName"></param>
    public static string CreateFileRootPath(string fileName)
    {
        var p = Path.Combine(rootPath,fileName);
        foldName = fileName;
        if (!Directory.Exists(p))
        {
            var d = Directory.CreateDirectory(p);
        }
        RootPath = p;
        return p;
    }

    public static void DeleteTmpFile(string folder)
    {
        if (Directory.Exists(folder))
        {
            Directory.Delete(folder,true);
        }
    }

    public static void DeleteTmpFile()
    {
        if (Directory.Exists(rootPath))
        {
            var d = new DirectoryInfo(rootPath);
            foreach (var item in d.GetDirectories())
            {
                if (item.Name != foldName)
                {
                    Directory.Delete(item.FullName, true);
                }
            }
        }
    }
}

