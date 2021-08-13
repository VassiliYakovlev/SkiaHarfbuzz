using System;
using SkiaSharp;

namespace SkiaHarfbuzzCSharp.Skia {
    class SkiaHelper : SkiaHelperBase {
        public override byte[] RenderText(string text, OpenTypeFeatures otFeat, GraphicsSettings grSettings) {
            if (skFont == null)
                return null;

            Span<ushort> glyphsSpan = CreateGlyphsSpan(text);

            return RenderGlyphs(glyphsSpan, otFeat.RightToLeft, otFeat.FontSize, grSettings); 
        }

        Span<ushort> CreateGlyphsSpan(string text) {
            int glyphCount = skFont.CountGlyphs(text);
            Span<ushort> glyphsSpan = new Span<ushort>(new ushort[glyphCount]);
            skFont.GetGlyphs(text, glyphsSpan);
            return glyphsSpan;
        }

        internal override float[] GetAdvances(Span<ushort> glyphsSpan) {
            float[] widths = new float[glyphsSpan.Length];
            Span<float> glyphsWidth = new Span<float>(widths);
            Span<SKRect> glyphsBounds = new Span<SKRect>(new SKRect[glyphsSpan.Length]);
            skFont.GetGlyphWidths(glyphsSpan, glyphsWidth, glyphsBounds);
            return widths;
        }
    }
}
