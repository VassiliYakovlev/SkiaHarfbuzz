# SkiaHarfbuzz
Using of Skia (SkiaSharp) and Harfbuzz for text shaping and rendering with keeping low level control

There is not much documentation on the Microsoft site which could be very helpful for every developer who will use SkiaSharp and SkiaSharp.Harfbuzz. So, because of that, the work on this project is mainly based on try and error, guessing and experimenting. Still there is a lot of classes, properties which are not clear for me and how to use it properly.
https://docs.microsoft.com/en-us/dotnet/api/skiasharp?view=skiasharp-2.80.2
https://docs.microsoft.com/en-us/dotnet/api/skiasharp.harfbuzz?view=skiasharp-harfbuzz-2.80.2

`SKTypeface` (and `SKFont`) does not have interface to manipulate OpenType features. But there is possibility to obtain the list of available table tags (using `SKTypeface.GetTableTags()` ) and retrieve the table's data ( `SKTypeface.GetTableData()` ) which can be parsed by custom code. Therefore you need to implement the functionality based on OpenType specifications. But going this way you have to do low level input data analysis using Unicode standard and morph it using feature tables. We will not go this way though. 

In order to use all available OpenType features and Unicode information for text layout (shaping) we need to use Harfbuzz together with Skia. Skia let us render text and has no logic to do script and language dependent ordering, substitutions, and OpenType features. At the same time we have ability to control the OpenType features and impacting the shaping result.
