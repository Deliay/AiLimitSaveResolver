namespace AilimitSaveResolver.Save.Data;


public readonly record struct HeadwearItem(
    string HexId,
    uint Id,
    string Name,
    string Memorize,
    string Description);

public class HeadwearIds
    : Dictionary<uint, HeadwearItem>, IDataFileHolder<HeadwearIds>
{
    public static string DataFile => nameof(HeadwearIds) + ".json";
    public static HeadwearIds Read()
    {
        var items = Access.ReadJson<List<HeadwearItem>>(DataFile) ?? [];
        return items.Aggregate(new HeadwearIds(), (ids, i) =>
        {
            ids.Add(i.Id, i);
            return ids;
        });
    }
}