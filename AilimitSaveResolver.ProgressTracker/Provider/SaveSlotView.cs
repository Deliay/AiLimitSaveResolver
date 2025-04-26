using AilimitSaveResolver.Save.Generated;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace AilimitSaveResolver.ProgressTracker.Provider;

public class SaveSlotView : ComponentBase
{
    [Parameter] public RenderFragment<SelectedSlot> SelectedSlot { get; set; }
    [Parameter] public RenderFragment NotSelectedSlot { get; set; }
    [CascadingParameter] public required SelectedSlot CurrentSaveSlot { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.AddContent(0, CurrentSaveSlot.Selected ? SelectedSlot?.Invoke(CurrentSaveSlot) : NotSelectedSlot);
    }
}
