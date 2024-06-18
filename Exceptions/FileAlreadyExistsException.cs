namespace Exceptions;

public class FileAlreadyExistsException(string message = "Arquivo já existe no caminho") : Exception(message);