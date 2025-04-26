namespace AilimitSaveResolver.Save.Data;

public readonly record struct WeaponItem(
    string HexId,
    uint Id,
    string Name,
    string Level,
    string Memorize,
    string Description);

public class WeaponIds
    : Dictionary<uint, WeaponItem>, IDataFileHolder<WeaponIds>
{
    public static string DataFile => nameof(WeaponIds) + ".json";
    public static WeaponIds Read()
    {
        var items = Access.ReadJson<List<WeaponItem>>(DataFile) ?? [];
        return items.Aggregate(new WeaponIds(), (ids, i) =>
        {
            ids.Add(i.Id, i);
            return ids;
        });
    }
}