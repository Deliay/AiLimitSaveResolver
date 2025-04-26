/**
 * @param dropZone {HTMLElement}
 * @param inputElement {HTMLInputElement}
 */
export function initializeDropZone(dropZone, inputElement) {
    /**
     * @this {Window}
     * @param e {DragEvent}
     */
    function onDrop(e) { 
        e.preventDefault();
        inputElement.files = e.dataTransfer.files;
        inputElement.dispatchEvent(new Event('change', { bubbles: true }));
    }

    /**
     * @this {Window}
     * @param e {ClipboardEvent}
     */
    function onPaste(e) {
        e.preventDefault();
        inputElement.files = e.clipboardData.files;
        inputElement.dispatchEvent(new Event('change', { bubbles: true }));
    }

    /**
     * @this {Window}
     * @param e {Event}
     */
    function onDrag(e) {
        e.preventDefault();
    }

    /**
     * @this {Window}
     * @param e {MouseEvent}
     */
    function onClick(e) {
        e.preventDefault();
    }

    dropZone.addEventListener('dragenter', onDrag);
    dropZone.addEventListener('dragover', onDrag);
    dropZone.addEventListener('dragleave', onDrag);
    dropZone.addEventListener('drop', onDrop);
    document.addEventListener('paste', onPaste);
    
    return {
        dispose: () => {
            dropZone.removeEventListener('dragenter', onDrag);
            dropZone.removeEventListener('dragover', onDrag);
            dropZone.removeEventListener('dragleave', onDrag);
            dropZone.removeEventListener('drop', onDrop);
            document.removeEventListener('paste', onPaste);
        } 
    };
}
