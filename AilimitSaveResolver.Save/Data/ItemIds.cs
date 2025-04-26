namespace AilimitSaveResolver.Save.Data;

public readonly record struct Item(
    string HexId,
    string Id,
    string Name,
    string Memorize,
    string Effect,
    string Description);

public class ItemIds
    : Dictionary<uint, Item>, IDataFileHolder<ItemIds>
{
    public static string DataFile => nameof(ItemIds) + ".json";
    public static ItemIds Read()
    {
        var items = Access.ReadJson<List<Item>>(DataFile) ?? [];
        return items.Aggregate(new ItemIds(), (ids, i) =>
            {
                ids.Add(uint.Parse(i.Id), i);
                return ids;
            });
    }
}