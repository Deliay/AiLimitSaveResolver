namespace AilimitSaveResolver.Save.Data;

public readonly record struct WeaponClass(
    string Name, string Class, uint SkillId, uint WeaponId);

public class WeaponClasses
    : IDataFileHolder<WeaponClasses>
{
    public static string DataFile => nameof(WeaponClasses) + ".json";
    public static WeaponClasses Read()
    {
        var items = Access.ReadJson<List<WeaponClass>>(DataFile) ?? [];
        var instance = new WeaponClasses();
        
        foreach (var weaponClass in items)
        {
            instance.SkillIdToClass.Add(weaponClass.SkillId, weaponClass);
            instance.WeaponNameToClass.Add(weaponClass.Name, weaponClass);;
        }

        return instance;
    }

    private readonly Dictionary<string, WeaponClass> WeaponNameToClass = [];
    private readonly Dictionary<uint, WeaponClass> SkillIdToClass = [];
    
    public string GetWeaponClassBySkillId(uint skillId) => SkillIdToClass[skillId].Class;
    public string GetWeaponNameBySkillId(uint skillId) => SkillIdToClass[skillId].Name;
    public uint GetWeaponIdBySkillId(uint skillId) => SkillIdToClass[skillId].WeaponId;
    public string GetWeaponClassByWeaponName(string name) => WeaponNameToClass[name].Class;

    public string GetWeaponClassByWeaponId(uint weaponId) =>
        GetWeaponClassByWeaponName(Access.Data<WeaponIds>()[weaponId].Name);

}