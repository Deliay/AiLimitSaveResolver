using System.Text.Json;

namespace AilimitSaveResolver.Save.Data;

public static class Access
{
    
    public static T? ReadJson<T>(string filePath)
    {
        var asm = typeof(Access).Assembly;

        using var stream = asm.GetManifestResourceStream(typeof(Access).Namespace + "." + filePath);
        return JsonSerializer.Deserialize<T>(stream!);
    }

    private static readonly Dictionary<Type, object> DataFileHolder = new();
    
    public static T Data<T>() where T : IDataFileHolder<T>
    {
        if (DataFileHolder.TryGetValue(typeof(T), out var holder)
            && holder is T result)
        {
            return result;
        }

        DataFileHolder.Add(typeof(T), result = T.Read() ?? throw new NullReferenceException());
        return result;
    }
}