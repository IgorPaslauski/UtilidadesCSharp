namespace FileUtils;

public static class FileUtils
{
    public static void WriteToFile(string path, string content)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }

        File.WriteAllText(path, content);
    }

    public static void CreateFile(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
    }

    public static string ReadFromFile(string path)
    {
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

    public static void GetFiles(string path)
    {
        Directory.GetFiles(path);
    }
}