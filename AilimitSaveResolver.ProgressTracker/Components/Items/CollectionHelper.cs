using Microsoft.Extensions.Localization;

namespace AilimitSaveResolver.ProgressTracker.Components.Items;

public static class CollectionHelper
{
    public static (
        List<(string Icon, LocalizedString Name, LocalizedString)> Left,
        List<(string Icon, LocalizedString Name, LocalizedString)> Right) Diff(
            IEnumerable<uint> total, List<uint> found, Func<uint, string> icon,
            Func<uint, LocalizedString> firstLineLocale,
            Func<uint, LocalizedString> secondLineLocale)
    {
        return (found.Select((id) => (icon(id), firstLineLocale(id), secondLineLocale(id))).ToList(),
            total.Except(found).Select((id) => (icon(id), firstLineLocale(id), secondLineLocale(id))).ToList());
    }
}