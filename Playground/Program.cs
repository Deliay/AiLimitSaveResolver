using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using AilimitSaveResolver.Save;
using AilimitSaveResolver.Save.Data;
using AilimitSaveResolver.Save.Generated;
using Lagrange.Proto.Serialization;
using ProtoBuf;
using ProtoBuf.Meta;

const string saveDirectory = @"/mnt/games/Steam/steamapps/compatdata/2407270/pfx/drive_c/users/steamuser/AppData/LocalLow/SenseGames/AILIMIT/Archive/";
const string saveFilePath = @"/mnt/games/Steam/steamapps/compatdata/2407270/pfx/drive_c/users/steamuser/AppData/LocalLow/SenseGames/AILIMIT/Archive/ai-limit_sav-data.sav";
const string secondSavePath = @"/mnt/games/Steam/steamapps/compatdata/2407270/pfx/drive_c/users/steamuser/AppData/LocalLow/SenseGames/AILIMIT/Archive_2周目结束/ai-limit_sav-data.sav";
if (args.Length > 0 && args[0] == "reset")
{
    await UpdateSave();
    Console.WriteLine("已修改存档");
    return;
}

var saveData = await ReadSave();
Console.WriteLine($"存档数量:{saveData.SaveSlots.Count}");
var save = saveData.SaveSlots.First();

Console.WriteLine($"碎晶数量: {save.FragmentBranchAmount}");

Console.WriteLine("\n---------------------");
Console.WriteLine($"普通物品列表：");
foreach (var invItem in save.Inventory.NormalItems)
{
    if (Access.Data<ItemIds>().TryGetValue(invItem.ItemId, out var item))
    {
        Console.Write($"{item.Name} *{invItem.Amount}, ");
    }
}

Console.WriteLine("\n---------------------");
Console.WriteLine($"已持有武器列表：");
foreach (var invItem in save.Inventory.Weapons)
{
    if (Access.Data<WeaponIds>().TryGetValue(invItem.WeaponId, out var item))
    {
        var level = item.Level is { Length: > 0 } ? $"({item.Level})" : "";
        Console.Write($"{item.Name} {level}, ");
    }
}

Console.WriteLine("\n---------------------");
Console.WriteLine($"已持有晶核：");
foreach (var invItem in save.Inventory.Nuclei)
{
    if (Access.Data<NucleusIds>().TryGetValue(invItem.NucleusId, out var item))
    {
        Console.Write($"{item.Name}, ");
    }
}

Console.WriteLine("\n---------------------");
Console.WriteLine($"已持有刻印：");
foreach (var invItem in save.Inventory.Seals)
{
    if (Access.Data<SealIds>().TryGetValue(invItem.SealId, out var item))
    {
        var level = item.Level is { Length: > 0 } ? $"({item.Level})" : "";
        level = level == item.Name ? "(常刻印)" : level;
        Console.Write($"{item.Name} {level}, ");
    }
}

Console.WriteLine("\n---------------------");
Console.WriteLine($"已持有法术：");
foreach (var invItem in save.Inventory.Spells)
{
    if (Access.Data<SpellIds>().TryGetValue(invItem.SpellId, out var item))
    {
        Console.Write($"{item.Name}, ");
    }
}

Console.WriteLine("\n---------------------");
Console.WriteLine($"已持有衣装：");
foreach (var invItem in save.Inventory.ClothesList)
{
    if (Access.Data<ClothesIds>().TryGetValue(invItem.ClothesId, out var item))
    {
        Console.Write($"{item.Name}, ");
    }
}

Console.WriteLine("\n---------------------");
Console.WriteLine($"已持有头饰：");
foreach (var invItem in save.Inventory.Headwears)
{
    if (Access.Data<HeadwearIds>().TryGetValue(invItem.HeadwearId, out var item))
    {
        Console.Write($"{item.Name}, ");
    }
}



Console.WriteLine();
Console.WriteLine("请输入输出名称:");
var readLine = Console.ReadLine();


const string path = "/home/ash/Projects/AiLimitResolver/DecodedSave-04";
var index = Directory.EnumerateFiles(path)
    .Select(Path.GetFileName)
    .Select(i => i![0..i.IndexOf('-')])
    .Select(i => int.TryParse(i, out var num) ? num + 1 : 0)
    .OrderDescending()
    .FirstOrDefault();
var filePath = Path.Combine(path, $"{index:0000}-{readLine}.json");

if (File.Exists(filePath)) File.Delete(filePath);
await using var jsonfile = File.OpenWrite(filePath);

JsonSerializer.Serialize(jsonfile, saveData, new JsonSerializerOptions()
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
});

return;

static async ValueTask<SaveData> ReadSave()
{
    // return ProtoSerializer.DeserializeProtoPackable<SaveData>((ReadOnlySpan<byte>)await File.ReadAllBytesAsync(saveFilePath));
    return Serializer.Deserialize<SaveData>((ReadOnlySpan<byte>)await File.ReadAllBytesAsync(saveFilePath));
}

static async ValueTask UpdateSave()
{
    var saveData = await ReadSave();
    var saveSlot = saveData.SaveSlots.First();

    var items = saveSlot.Inventory.NormalItems;

    DeleteIfExists(Path.Combine(saveDirectory, "ai-limit_sav-provisionalData.sav"));
    DeleteIfExists(Path.Combine(saveDirectory, "ai-limit_sav-backupData.sav"));
    DeleteDirectoryIfExists(Path.Combine(saveDirectory, "AiLimitDefenseArchive"));
    DeleteIfExists(saveFilePath);
    
    // var data = ProtoSerializer.SerializeProtoPackable(saveData);
    // await File.WriteAllBytesAsync(saveFilePath, data);
    //
    await using var fs = File.OpenWrite(saveFilePath); 
    Serializer.Serialize(fs, saveData);
}

static void EditNormalItemCount(List<Normalitems> items, uint item, uint amount)
{
    var itemObj = items.FirstOrDefault(i => i.ItemId == item);
    if (itemObj is not null)
    {
        itemObj.Amount = amount;
    }
    else
    {
        items.Add(new Normalitems { ItemId = item, Amount = amount, InventoryItemunknownfield03 = item });
    }
}

static void DeleteDirectoryIfExists(string path)
{
    if (Directory.Exists(path)) Directory.Delete(path, recursive: true);
}

static void DeleteIfExists(string path)
{
    if (File.Exists(path)) File.Delete(path);
}