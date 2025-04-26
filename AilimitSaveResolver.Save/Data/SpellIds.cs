namespace AilimitSaveResolver.Save.Data;


public readonly record struct SpellItem(
    string HexId,
    uint Id,
    string Name,
    string Memorize,
    string Description);

public class SpellIds
    : Dictionary<uint, SpellItem>, IDataFileHolder<SpellIds>
{
    public static string DataFile => nameof(SpellIds) + ".json";
    public static SpellIds Read()
    {
        var items = Access.ReadJson<List<SpellItem>>(DataFile) ?? [];
        return items.Aggregate(new SpellIds(), (ids, i) =>
        {
            ids.Add(i.Id, i);
            return ids;
        });
    }
}