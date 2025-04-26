using System.Text.Json;

namespace AilimitSaveResolver.Save.Data;

public interface IDataFileHolder<out T> where T : IDataFileHolder<T>
{
    public static abstract string DataFile { get; }
    
    public static abstract T Read();
}