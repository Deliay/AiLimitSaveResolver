namespace AilimitSaveResolver.Save.Data;


public readonly record struct SkillItem(
    string HexId,
    uint Id,
    string Name,
    string Memorize,
    string Description);

public class SkillIds
    : Dictionary<uint, SkillItem>, IDataFileHolder<SkillIds>
{
    public static string DataFile => nameof(SkillIds) + ".json";
    public static SkillIds Read()
    {
        var items = Access.ReadJson<List<SkillItem>>(DataFile) ?? [];
        return items.Aggregate(new SkillIds(), (ids, i) =>
        {
            ids.Add(i.Id, i);
            return ids;
        });
    }
}
