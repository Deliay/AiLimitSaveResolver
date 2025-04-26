namespace AilimitSaveResolver.Save;

public readonly record struct Boss(uint MapId, uint BossId);

public class KnownBossList
{
    
    private static readonly Dictionary<Boss, string> Items = new()
    {
        { new Boss(10101, 1), "迷失的枪兵-罗尔(开场)" },
        { new Boss(10101, 173), "迷失的枪兵-罗尔(本体)" },
        { new Boss(10201, 1), "贫民窟族长" },
    };
    
    public static bool Has(Boss id) => Items.ContainsKey(id);
    
    public static string Get(Boss id)
        => Items.GetValueOrDefault(id, "(未知)");
}