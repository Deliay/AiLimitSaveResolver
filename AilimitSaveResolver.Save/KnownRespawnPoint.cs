namespace AilimitSaveResolver.Save;

public readonly record struct RespawnBranch(uint Index, string Region, string Area, string Branch, bool IsTeleport = false);

public static class KnownRespawnPoint
{
    private static readonly Dictionary<uint, RespawnBranch> TeleportBranches = new()
    {
        { 1501, new RespawnBranch(1501u, "地城水道", "西南段", "新存档出生点", true) },
        { 1506, new RespawnBranch(1506u, "地城水道", "西南段", "BOSS:清扫者门口", true) },
        { 3501, new RespawnBranch(3501u,"沉默之都-上层", "楼顶街", "入城传送阵", true) },
    };
    
    private static readonly Dictionary<uint, RespawnBranch> Items = new()
    {
        
        { 1503, new RespawnBranch(1503u,"地城水道", "西南段", "集水区") },
        { 1504, new RespawnBranch(1504u,"地城水道", "西南段", "维修通道") },
        { 1508, new RespawnBranch(1508u,"地城水道", "西南段", "大蓄水池") },
        { 1507, new RespawnBranch(1507u,"地城水道", "西南段", "上行电梯前") },
        
        { 6502, new RespawnBranch(6502u,"地城水道", "北段", "水道路旁") },
        { 6503, new RespawnBranch(6503u,"地城水道", "北段", "沉淀池") },
        { 6509, new RespawnBranch(6509u,"地城水道", "北段", "狩猎场") },
        { 6504, new RespawnBranch(6504u,"地城水道", "北段", "地层裂隙") },
        
        { 8502, new RespawnBranch(8502u,"地城水道", "中段", "中央车站") },
        { 8509, new RespawnBranch(8509u,"地城水道", "中段", "隐秘站台") },
        { 8503, new RespawnBranch(8503u,"地城水道", "中段", "地下深井") },
        { 8504, new RespawnBranch(8504u,"地城水道", "中段", "圣树之门") },
        
        { 8505, new RespawnBranch(8505u,"地城水道", "圣树庭院", "中央花园") },

        { 2502, new RespawnBranch(2502u,"壁外废墟", "贫民窟", "朝圣小径") },
        { 2503, new RespawnBranch(2503u,"壁外废墟", "贫民窟", "临时营地") },
        { 2505, new RespawnBranch(2505u,"壁外废墟", "贫民窟", "废屋群" ) },
        { 2506, new RespawnBranch(2506u,"壁外废墟", "贫民窟", "墓园" ) },
        { 2508, new RespawnBranch(2508u,"壁外废墟", "贫民窟", "入城通道" ) },
        
        { 2513, new RespawnBranch(2513u,"壁外废墟", "古代机械工厂", "工厂旁路" ) },
        { 2514, new RespawnBranch(2514u,"壁外废墟", "古代机械工厂", "装配车间" ) },
        { 2516, new RespawnBranch(2516u,"壁外废墟", "古代机械工厂", "雪莉的房间" ) },
        { 2517, new RespawnBranch(2517u,"壁外废墟", "古代机械工厂", "研究所" ) },
        { 2518, new RespawnBranch(2518u,"壁外废墟", "古代机械工厂", "地下试验场" ) },
        
        { 3502, new RespawnBranch(3502u,"沉默之都-上层", "楼顶街", "停机坪") },
        { 3503, new RespawnBranch(3503u,"沉默之都-上层", "楼顶街", "渔夫营地") },
        { 3504, new RespawnBranch(3504u,"沉默之都-上层", "楼顶街", "休息室") },
        { 3505, new RespawnBranch(3505u,"沉默之都-上层", "楼顶街", "交界桥") },
        { 3506, new RespawnBranch(3506u,"沉默之都-上层", "楼顶街", "旅店走廊") },
        { 3507, new RespawnBranch(3507u,"沉默之都-上层", "楼顶街", "观景阳台") },
        
        { 3512, new RespawnBranch(3512u,"沉默之都-上层", "覆水街道", "幸存者据点") },
        { 3513, new RespawnBranch(3513u,"沉默之都-上层", "覆水街道", "商业街") },
        { 3514, new RespawnBranch(3514u,"沉默之都-上层", "覆水街道", "东侧广场") },
        { 3515, new RespawnBranch(3515u,"沉默之都-上层", "覆水街道", "以金广场") },
        { 3516, new RespawnBranch(3516u,"沉默之都-上层", "覆水街道", "下行电梯") },
        
        { 4502, new RespawnBranch(4502u,"沉默之都-下层", "地下教区", "大厦底层") },
        { 4503, new RespawnBranch(4503u,"沉默之都-下层", "地下教区", "教区大道") },
        { 4504, new RespawnBranch(4504u,"沉默之都-下层", "地下教区", "壁画前") },
        { 4512, new RespawnBranch(4512u,"沉默之都-下层", "地下教区", "教区车站") },
        { 4513, new RespawnBranch(4513u,"沉默之都-下层", "地下教区", "活物池塘") },
        { 4514, new RespawnBranch(4514u,"沉默之都-下层", "地下教区", "审判厅") },
        { 4517, new RespawnBranch(4517u,"沉默之都-下层", "地下教区", "主教通道") },
        
        
        { 5502, new RespawnBranch(5502u,"圣父大教堂", "下层", "净灵阶梯") },
        
        { 5504, new RespawnBranch(5504u,"圣父大教堂", "上层", "断层回廊") },
        { 5506, new RespawnBranch(5506u,"圣父大教堂", "上层", "献晶所") },
        { 5512, new RespawnBranch(5512u,"圣父大教堂", "上层", "自塑殿堂") },
        { 5513, new RespawnBranch(5513u,"圣父大教堂", "上层", "未然领域") },
        { 5514, new RespawnBranch(5514u,"圣父大教堂", "上层", "终礼步道") },
        { 5521, new RespawnBranch(5521u,"圣父大教堂", "上层", "至上天顶") },
        { 5522, new RespawnBranch(5522u,"圣父大教堂", "上层", "圣坛") },
        
        { 7503, new RespawnBranch(7503u,"薄暮山", "深渊灵龛", "沉眠阵列") },
        { 7505, new RespawnBranch(7505u,"薄暮山", "深渊灵龛", "监视塔") },
        { 7506, new RespawnBranch(7506u,"薄暮山", "深渊灵龛", "底层灵龛") },
        { 7508, new RespawnBranch(7508u,"薄暮山", "深渊灵龛", "坍塌巨洞") },
        
        
        { 9022, new RespawnBranch(9022u,"薄暮山", "枯萎林区", "林区入口") },
        { 9023, new RespawnBranch(9023u,"薄暮山", "枯萎林区", "死树林") },
        { 9024, new RespawnBranch(9024u,"薄暮山", "枯萎林区", "薄暮山脚") },
        { 9025, new RespawnBranch(9025u,"薄暮山", "枯萎林区", "猎人栈道") },
        { 9026, new RespawnBranch(9026u,"薄暮山", "枯萎林区", "植物园") },
        
        { 9502, new RespawnBranch(9502u,"环界", "净地", "天树花园") },
        { 9602, new RespawnBranch(9602u,"环界", "净地", "环界之门") },
    };
    
    public static bool Has(uint id) => Items.ContainsKey(id);
    
    public static RespawnBranch Get(uint id)
        => Items.TryGetValue(id, out var item) ? item : new RespawnBranch(0, "未知", "未知", "未知");

    public static RespawnBranch GetNearest(uint id)
        => Items.TryGetValue(id, out var item)
            ? item
            : Items.OrderBy(i => i.Key - id).First().Value;
    
    public static IReadOnlyDictionary<uint, RespawnBranch> All => Items;
}
