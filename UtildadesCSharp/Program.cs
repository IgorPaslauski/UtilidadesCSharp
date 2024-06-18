using Enums;
using Exceptions;

namespace UtildadesCSharp;

public static class Program
{
    public static void Main()
    {
        try
        {
            var defaultPath = FileUtils.FileUtils.DefaultPath;
            
            FileUtils.FileUtils.CreateFile(defaultPath, "file1" , FileTypeEnum.Txt, true);
            
            var path = Path.Combine(defaultPath, "file.txt");
            
            FileUtils.FileUtils.WriteToFile(path, "A simple text ");
            FileUtils.FileUtils.AppendToFile(path, "A simple text1 ");
            FileUtils.FileUtils.AppendToFile(path, "A simple text2");
            
            var content = FileUtils.FileUtils.ReadFromFile(path);
            
            Console.WriteLine(content);
        }
        catch (FileAlreadyExistsException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}