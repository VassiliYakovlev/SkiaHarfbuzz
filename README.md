# SkiaHarfbuzz
Using of Skia (SkiaSharp) and Harfbuzz for text shaping and rendering with keeping low level control

`SKTypeface` (and `SKFont`) does not have interface to manipulate OpenType features. But there is possibility to obtain the list of available table tags (using `SKTypeface.GetTableTags()` ) and retrieve the table's data ( `SKTypeface.GetTableData()` ) which can be parsed by custom code. Therefore you need to implement the functionality based on OpenType specifications. But going this way you have to do low level input data analysis using Unicode standard and morph it using feature tables.

In order to use all available OpenType features and Unicode information for text layout (shaping) we need to use Harfbuzz together with Skia. Skia let us render text and has no logic to do script and language dependent ordering, substitutions, and OpenType features. At the same time we have ability to control the OpenType features and impacting the shaping result.
