Ai limlit Save Resolver
----
A library and tool that parses the game AlLimit's saves to find items not found in the saves.

## Install
```bash
dotnet add package AilimitSaveResolver.Save
```
## Usage
```csharp
var saveFilePath = ...;
ReadOnlySpan<byte> bytes = await File.ReadAllBytesAsync(saveFilePath);

var save = Serializer.Deserialize<SaveData>(bytes);
```
