using AilimitSaveResolver.Save.Generated;

namespace AilimitSaveResolver.ProgressTracker.Provider;

public sealed class SelectedSlot(SaveSlot? slot)
{
    public SaveSlot? Slot => slot;
    public bool Selected => Slot != null;
}
