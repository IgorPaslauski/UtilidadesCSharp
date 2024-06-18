namespace Exceptions;

public class FileNotFoundException(string message = "Arquivo não encontrado no caminho") : Exception(message);