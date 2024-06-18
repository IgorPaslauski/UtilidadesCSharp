using Enums;
using Exceptions;
using FileNotFoundException = Exceptions.FileNotFoundException;


namespace FileUtils;

public static class FileUtils
{
    public static string DefaultPath { get; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    
    public static void WriteToFile(string path, string content)
    {
        ThrowIfNotExistFile(path);

        File.WriteAllText(path, content);
    }
    
    public static void AppendToFile(string path, string content)
    {
        ThrowIfNotExistFile(path);

        File.AppendAllText(path, content);
    }

    public static void CreateFile(string path, string fileName, FileTypeEnum fileType, bool removeIfExsits = false)
    {
        ThrowIfNotExistDirectory(path);
        var extionFile = ReturnExtionFile(fileType);
        var pathComplete = Path.Combine(path, fileName + extionFile);
        
        if (removeIfExsits && File.Exists(pathComplete))
        {
            File.Delete(pathComplete);
        }
        
        if (File.Exists(pathComplete))
        {
            throw new FileAlreadyExistsException();
        }

        File.Create(pathComplete).Close();
    }

    public static string ReturnExtionFile(FileTypeEnum fileType)
    {
        return fileType switch
        {
            FileTypeEnum.Txt => ".txt",
            FileTypeEnum.Csv => ".csv",
            FileTypeEnum.Json => ".json",
            FileTypeEnum.Xml => ".xml",
            FileTypeEnum.Yaml => ".yaml",
            FileTypeEnum.Binary => ".bin",
            FileTypeEnum.Excel => ".xlsx",
            FileTypeEnum.Word => ".docx",
            FileTypeEnum.PowerPoint => ".pptx",
            FileTypeEnum.Pdf => ".pdf",
            FileTypeEnum.Image => ".png",
            FileTypeEnum.Video => ".mp4",
            FileTypeEnum.Audio => ".mp3",
            FileTypeEnum.Zip => ".zip",
            FileTypeEnum.Rar => ".rar",
            _ => throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null)
        };
    }
    
    public static string ReadFromFile(string path)
    {
        if (!ExistFile(path))
        {
            throw new FileNotFoundException();
        }
        
        return File.ReadAllText(path);
    }

    public static void CopyFile(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public static void MoveFile(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public static void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public static void CreateDirectory(string path)
    {
        Directory.CreateDirectory(path);
    }

    public static void DeleteDirectory(string path)
    {
        Directory.Delete(path, true);
    }

    public static bool ExistDirectory(string path)
    {
        return Directory.Exists(path);
    }

    public static bool ExistFile(string path)
    {
        return File.Exists(path);
    }
    
    public static void ThrowIfNotExistFile(string path)
    {
        if (!ExistFile(path))
        {
            throw new FileNotFoundException();
        }
    }
    
    public static void ThrowIfNotExistDirectory(string path)
    {
        if (!ExistDirectory(path))
        {
            throw new DirectoryNotFoundException();
        }
    }

    public static void GetFiles(string path)
    {
        Directory.GetFiles(path);
    }
}