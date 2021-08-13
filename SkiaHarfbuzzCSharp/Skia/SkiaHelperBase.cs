using SkiaSharp;
using System;

namespace SkiaHarfbuzzCSharp.Skia
{
    abstract class SkiaHelperBase : ISkiaHelper {
        protected SKFont skFont;
        protected SKTypeface skTypeface;
        protected string typefaceFilename;

        public virtual HelperType Type => HelperType.Skia;

        public virtual void Dispose() {
            if (skFont != null)
                skFont.Dispose();
            skFont = null;
            if (skTypeface != null)
                skTypeface.Dispose();
            skTypeface = null;
            if (surface != null)
                surface.Dispose();
            surface = null;
        }

        public virtual bool LoadTypeface(string fontFileName) {
            if(skTypeface == null || typefaceFilename != fontFileName) {
                Dispose();
                skTypeface = SKTypeface.FromFile(fontFileName);
                typefaceFilename = fontFileName;
            }
                
            if (skTypeface == null)
                new InvalidOperationException("Typeface not loaded");

            if (skFont == null)
                skFont = new SKFont(skTypeface, skTypeface.UnitsPerEm);
            skFont.Subpixel = true;

            return true;
        }

        public string GetFontName() {
            if(skTypeface == null)
                return "not loaded";
            return skTypeface.FamilyName;
        }

        public abstract byte[] RenderText(string text, OpenTypeFeatures otFeat, GraphicsSettings grSettings);

        internal abstract float[] GetAdvances(Span<ushort> glyphsSpan);

        SKPaint skPaint;
        SKImageInfo skImageInfo;
        SKSurface surface;
        static object surfaceLock = new object();

        protected byte[] RenderGlyphs(Span<ushort> glyphsSpan, bool rtl, float fontSize, 
            GraphicsSettings grSettings) {

            byte[] imageBytes = null;

            lock (surfaceLock)
            {
                try
                {
                    if (!grSettings.OK(skImageInfo))
                    {
                        skImageInfo = new SKImageInfo(grSettings.Width, grSettings.Height, SKColorType.Rgba8888, SKAlphaType.Opaque);
                        if (surface != null)
                            surface.Dispose();
                        surface = null;
                    }

                    if (surface == null)
                        surface = SKSurface.Create(skImageInfo);

                    surface.Canvas.Save();
                    surface.Canvas.Clear(new SKColor(255, 255, 255));
                    surface.Canvas.ResetMatrix();
                    if (skPaint == null)
                    {
                        skPaint = new SKPaint();
                        skPaint.Color = new SKColor(0, 0, 0);
                        skPaint.FilterQuality = SKFilterQuality.High;
                    }
                    skPaint.IsAntialias = grSettings.Antialiasing;

                    float[] glyphsAdvances = GetAdvances(glyphsSpan);
                    float scale = fontSize / skTypeface.UnitsPerEm;
                    surface.Canvas.Scale(scale);
                    int xStart = 30;
                    //if (rtl)
                    //    xStart = (int)(surfaceWidth * skTypeface.UnitsPerEm / fontSize - glyphsWidth[0]);
                    surface.Canvas.Translate(xStart, skTypeface.UnitsPerEm);
                    int glyphIndex = 0;

                    for (int i = 0; i < glyphsSpan.Length; i++)
                    {
                        ushort glyphId = glyphsSpan[i];
                        SKPath glyphPath = skFont.GetGlyphPath(glyphId);
                        //if (rtl && glyphIndex > 0) surface.Canvas.Translate(-glyphsWidth[glyphIndex], 0);
                        surface.Canvas.DrawPath(glyphPath, skPaint);
                        //if (!rtl) 
                        surface.Canvas.Translate(glyphsAdvances[glyphIndex], 0);
                        glyphIndex++;
                    }

                    surface.Canvas.Flush();

                    using (SKImage skImage = surface.Snapshot())
                    {
                        using (SKData data = skImage.Encode(SKEncodedImageFormat.Png, 100))
                        {
                            imageBytes = data.ToArray();
                        }
                    }
                    surface.Canvas.Restore();
                }
                catch
                {
                }
            }

            return imageBytes; 
        }
    }
}
