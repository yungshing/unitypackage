using System;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;

using SevenZip;

using tar_cs;

class UnityTools
{
    string FileName;
    string FilePath;
    public void UnPackage(string filePath, string fileName, Action<string> action = null)
    {
        FileName = fileName;
        FilePath = filePath;
        var p = PathTools.CreateFileRootPath(fileName);
        //using (var stream = File.OpenRead(filePath))
        //{
        //    using (var gs = new GZipInputStream(stream))
        //    {

        //        using (var tar = TarArchive.CreateInputTarArchive(gs))
        //        {
        //            //tar.ExtractContents(p);
        //        }
        //    }
        //}
        using (SevenZipExtractor sevenZipExtractor = new SevenZipExtractor(filePath))
        {
            //sevenZipExtractor.ExtractFiles(p, new int[]
            //{
            //    sevenZipExtractor.ArchiveFileData[0].Index
            //});
            sevenZipExtractor.FileExtractionStarted += (s,e)=>
            {
                action?.Invoke("解压："+e.FileInfo.FileName);
            };
            sevenZipExtractor.ExtractArchive(p);
        }
        string text2 = Directory.GetFiles(p)[0];
        using (SevenZipExtractor sevenZipExtractor2 = new SevenZipExtractor(text2))
        {
            //for (int i = 0; i < sevenZipExtractor2.ArchiveFileData.Count; i++)
            //{
            //    sevenZipExtractor2.ExtractFiles(p, new int[]
            //    {
            //        sevenZipExtractor2.ArchiveFileData[i].Index
            //    });
            //}
            sevenZipExtractor2.FileExtractionStarted += (s, e) =>
            {
                action?.Invoke("解压：" + e.FileInfo.FileName);
            };
            sevenZipExtractor2.ExtractArchive(p);
        }
        File.Delete(text2);
        //using (var stream = File.OpenRead(filePath))
        //{
        //    Directory.CreateDirectory(p);
        //    Directory.SetCurrentDirectory(p);
        //    TarReader tarReader = new TarReader(stream);
        //    tarReader.ReadToEnd(".");
        //}
    }

    private void SevenZipExtractor_FileExtractionStarted(object sender, FileInfoEventArgs e)
    {
        throw new NotImplementedException();
    }

    public DirectoryInfo[] GetDirectorys()
    {
        var d = new DirectoryInfo(PathTools.CreateFileRootPath(FileName));
        return d.GetDirectories();
    }
    public FileInfo[] GetFiles()
    {
        var d = new DirectoryInfo(PathTools.CreateFileRootPath(FileName));
        return d.GetFiles();
    }

    public Dictionary<int, UnityPackageInfo> GetMuneList(DirectoryInfo[] di,Action<string> action = null)
    {
        var d = new Dictionary<int, UnityPackageInfo>();
        for (int i = 0; i < di.Length; i++)
        {
            var line = File.ReadAllLines(di[i].FullName + "/pathname")[0];
            var u = new UnityPackageInfo
            {
                filePathSplit = line.Split('/'),
                index = i,
            };
            if (!d.ContainsKey(i))
            {
                if (line.Contains("."))
                {
                    u.isFolder = false;
                }
                var files = di[i].GetFiles();
                foreach (var item1 in files)
                {
                    action?.Invoke("加载："+item1.Name);
                    if (item1.Name.Contains("preview"))
                    {
                        u.previewPath = item1.FullName;
                    }
                    else if (item1.Name == "asset")
                    {
                        u.assetPath = item1.FullName;
                    }
                    else if (item1.Name == "asset.meta")
                    {
                        u.assetmatePath = item1.FullName;
                    }
                }
                d.Add(i, u);
            }
        }
        return d;
    }

    public UnityFileType GetUnityFileType(string filename)
    {
        if (!filename.Contains("."))
        {
            return UnityFileType.Null;
        }
        if (filename.EndsWith(".cs"))
        {
            return UnityFileType.CS;
        }
        else if (filename.EndsWith(".txt") || filename.EndsWith(".xmal") || filename.EndsWith(".xml") || filename.EndsWith(".json") || filename.EndsWith(".shader"))
        {
            return UnityFileType.Text;
        }
        else if (filename.EndsWith(".png") || filename.EndsWith(".jpeg") || filename.EndsWith(".jpg") || filename.EndsWith(".bmp"))
        {
            return UnityFileType.Image;
        }
        else if (filename.EndsWith(".mp3") || filename.EndsWith(".midi") || filename.EndsWith(".wav"))
        {
            return UnityFileType.Music;
        }
        else if (filename.EndsWith(".mp4") || filename.EndsWith(".3gp"))
        {
            return UnityFileType.Video;
        }
        else if (filename.EndsWith(".dll"))
        {
            return UnityFileType.DLL;
        }
        else if (filename.EndsWith(".js"))
        {
            return UnityFileType.JS;
        }
        else if (filename.EndsWith(".unity"))
        {
            return UnityFileType.Unity;
        }
        else if (filename.EndsWith(".fbx"))
        {
            return UnityFileType.FBX;
        }
        return UnityFileType.Other;
    }
    /// <summary>
    /// 
    /// </summary>
    public enum UnityFileType
    {
        Null = 0,
        CS,
        JS,
        Image,
        Text,
        Music,
        Video,
        DLL,
        Unity,
        FBX,
        Other
    }
}

class UnityPackageInfo
{
    public int index = 0;
    public bool isFolder = true;
    public string assetPath = "";
    public string assetmatePath = "";
    public string pathnamePath = "";
    public string previewPath = "";
    public string[] filePathSplit;
}