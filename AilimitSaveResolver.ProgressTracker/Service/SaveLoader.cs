using System.Diagnostics.CodeAnalysis;
using AilimitSaveResolver.Save.Generated;
using Microsoft.AspNetCore.Components.Forms;
using ProtoBuf;

namespace AilimitSaveResolver.ProgressTracker.Service;

public class SaveLoader
{
    private SaveData? currentData;
    public SaveData? CurrentData => currentData;
    
    public bool Loaded => currentData is not null;
    
    private event Action? DataChanged;

    private readonly struct Handler(SaveLoader loader, Action callback) : IDisposable
    {
        public void Dispose()
        {
            loader.DataChanged -= callback;
        }
    }
    
    public IDisposable Subscribe(Action handler)
    {
        DataChanged += handler;
        return new Handler(this, handler);
    }
    
    public async Task<bool> Load(IBrowserFile file)
    {
        await using var stream = file.OpenReadStream();
        using var ms = new MemoryStream();
        await stream.CopyToAsync(ms);
        try
        {
            ms.Seek(0, SeekOrigin.Begin);
            currentData = Serializer.Deserialize<SaveData>(ms);
            DataChanged?.Invoke();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            currentData = null;
            return false;
        }
    }
    
}