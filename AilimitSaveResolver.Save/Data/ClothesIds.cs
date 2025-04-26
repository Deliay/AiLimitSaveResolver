namespace AilimitSaveResolver.Save.Data;


public readonly record struct ClothesItem(
    string HexId,
    uint Id,
    string Name,
    string Memorize,
    string Description);

public class ClothesIds
    : Dictionary<uint, ClothesItem>, IDataFileHolder<ClothesIds>
{
    public static string DataFile => nameof(ClothesIds) + ".json";
    public static ClothesIds Read()
    {
        var items = Access.ReadJson<List<ClothesItem>>(DataFile) ?? [];
        return items.Aggregate(new ClothesIds(), (ids, i) =>
        {
            ids.Add(i.Id, i);
            return ids;
        });
    }
}