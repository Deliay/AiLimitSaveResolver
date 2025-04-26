namespace AilimitSaveResolver.Save.Data;


public readonly record struct SealItem(
    string HexId,
    uint Id,
    string Name,
    string Level,
    string Memorize,
    string Description);

public class SealIds
    : Dictionary<uint, SealItem>, IDataFileHolder<SealIds>
{
    public static string DataFile => nameof(SealIds) + ".json";
    public static SealIds Read()
    {
        var items = Access.ReadJson<List<SealItem>>(DataFile) ?? [];
        return items.Aggregate(new SealIds(), (ids, i) =>
        {
            ids.Add(i.Id, i);
            return ids;
        });
    }
}
