# RawCraft

RawCraft is a 3rd party Minecraft client written in C# with XNA.

## Building from Source

You must first install [Microsoft.NET 4.0](http://www.microsoft.com/en-us/download/details.aspx?id=17851) and
[XNA 4.0](http://www.microsoft.com/en-us/download/details.aspx?id=23714). Then, add
"C:\Windows\Microsoft.NET\Framework\v4.0.30319" to your PATH.

Extract terrain.png from Minecraft or a texture pack and copy it to RawCraft/RawCraftContent/terrain.png.

For the best possible experience, you may also wish to install [this font](). If you do not wish to, edit
the <FontName> xml tag in RawCraft/RawCraftContent/*.spritefont.

Finally, run "msbuild.exe" from the root of the repository to build RawCraft.

## Licensing

RawCraft uses the permissive [BSD license](https://github.com/Valdiralita/RawCraft/blob/master/LICENSE).

RawCraft is not affiliated with [Minecraft](http://minecraft.net).