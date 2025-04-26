using AilimitSaveResolver.Save.Generated;

namespace AilimitSaveResolver.ProgressTracker.Provider;

public class CascadingSaveSlotProvider
{
    public event SaveSlotChangedHandler? SaveSlotChanged;

    public void NotifySaveSlotChanged(SelectedSlot saveSlot)
    {
        SaveSlotChanged?.Invoke(saveSlot);
    }
}

public delegate void SaveSlotChangedHandler(SelectedSlot slot);