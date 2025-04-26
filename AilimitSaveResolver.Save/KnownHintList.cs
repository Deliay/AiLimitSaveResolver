namespace AilimitSaveResolver.Save;

public readonly record struct Hint(string Type, string Target);

public static class KnownHintList
{
    private static Dictionary<uint, Hint> items = new()
    {
        { 10601, new Hint("提示", "冲刺按键") },
        { 10603, new Hint("提示","使用术士框架") },
        { 10611, new Hint("提示", "锁定按键") },
        { 10606, new Hint("提示", "翻滚按键") },
        { 10607, new Hint("提示", "武器技能按键") },
        
        { 15000, new Hint("收集", "锈蚀铁剑") },
        { 15001, new Hint("收集", "原浆球x3") },
        { 15002, new Hint("收集", "结晶残骸x1") },
        { 15003, new Hint("收集", "原浆球x2") },
        { 15007, new Hint("收集", "爆炸球x2") },
        { 15037, new Hint("收集", "能量水晶x3") },
        { 10108, new Hint("收集", "结晶残骸x1") },
        { 10110, new Hint("收集", "石头x5") },
        
        { 15042, new Hint("收集", "旧记事本") },
        
        { 10201, new Hint("开门", "出生点-下水道清理者BOSS") },
        { 10212, new Hint("开门", "维修通道-左侧捷径") },
        { 300006, new Hint("NPC对话", "打完清理者出门NPC") },
        { 200002, new Hint("NPC剧情", "初见阿斯特瑞亚, 状态:0-4,2是选武器") },
        { 330000, new Hint("DLC", "收集DLC物品") },
        
        { 200033, new Hint("机兵回忆", "弹反") },
        { 399979, new Hint("机兵归叶", "弹反") },
        { 200010, new Hint("机兵回忆", "击败-迷失的枪兵-罗尔-阿斯特瑞亚(亚稳态)")},
        
        { 300010, new Hint("支线", "德尔塔-收集土壤第一次对话") },
        { 200001, new Hint("支线", "雪莉-在营地第一次对话(0/1/3)") },
    };
    
    public static bool Has(uint id) => items.ContainsKey(id);
    
    public static Hint Get(uint id)
        => items.TryGetValue(id, out var item) ? item : new Hint("未知", $"{id}");
}