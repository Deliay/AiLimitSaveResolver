namespace AilimitSaveResolver.Save.Data;


public readonly record struct NucleusItem(
    string HexId,
    uint Id,
    string Name,
    string Memorize,
    string Description);

public class NucleusIds
    : Dictionary<uint, NucleusItem>, IDataFileHolder<NucleusIds>
{
    public static string DataFile => nameof(NucleusIds) + ".json";
    public static NucleusIds Read()
    {
        var items = Access.ReadJson<List<NucleusItem>>(DataFile) ?? [];
        return items.Aggregate(new NucleusIds(), (ids, i) =>
        {
            ids.Add(i.Id, i);
            return ids;
        });
    }
}
