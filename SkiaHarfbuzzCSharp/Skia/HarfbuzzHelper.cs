using System;
using System.Collections.Generic;
using HarfBuzzSharp;
using SkiaSharp;

namespace SkiaHarfbuzzCSharp.Skia
{
    
    class HarfbuzzHelper : SkiaHelperBase {
        Font hbFont;
        Face hbFace;
        string faceFontFileName;

        public override HelperType Type => HelperType.Harfbuzz;

        public override bool LoadTypeface(string fontFileName) {
            if (!base.LoadTypeface(fontFileName))
                return false;

            if(hbFace == null || faceFontFileName != fontFileName) {
                DisposeMe();
                hbFace = new Face(Blob.FromFile(fontFileName), 0);
                faceFontFileName = fontFileName;
            }

            if (hbFace == null)
                throw new InvalidOperationException("Typeface not loaded");
            if (hbFont == null)
                hbFont = new Font(hbFace);

            return true;
        }

        void DisposeMe() {
            if (hbFont != null)
                hbFont.Dispose();
            hbFont = null;
            if (hbFace != null)
                hbFace.Dispose();
            hbFace = null;
        }

        public override void Dispose() {
            DisposeMe();
            base.Dispose();
        }

        HarfBuzzSharp.Buffer textBuffer; 

        public override byte[] RenderText(string text, OpenTypeFeatures otFeat, GraphicsSettings grSettings) {
            if (hbFont == null || skFont ==null)
                return null;

            PrepareTextBuffer(otFeat, text);
            
            hbFont.Shape(textBuffer, PopulateFeatures(otFeat));
            
            return RenderGlyphs(CreateGlyphsSpan(textBuffer), otFeat.RightToLeft, otFeat.FontSize, grSettings);
        }

        internal override float[] GetAdvances(Span<ushort> glyphsSpan) {
            float[] advances = new float[textBuffer.GlyphPositions.Length];
            for(int i = 0; i < advances.Length; i++) {
                advances[i] = textBuffer.GlyphPositions[i].XAdvance + textBuffer.GlyphPositions[i].XOffset;
            }
            return advances;
        }

        Span<ushort> CreateGlyphsSpan(HarfBuzzSharp.Buffer textBuffer) {
            ushort[] glyphsTmp = new ushort[textBuffer.GlyphInfos.Length];
            for (int i = 0; i < glyphsTmp.Length; i++) {
                glyphsTmp[i] = (ushort)textBuffer.GlyphInfos[i].Codepoint;
            }
            return new Span<ushort>(glyphsTmp);
        }

        void PrepareTextBuffer(OpenTypeFeatures otFeat, string text) {
            if (textBuffer == null)
                textBuffer = new HarfBuzzSharp.Buffer();
            else
                textBuffer.ClearContents();
            textBuffer.ContentType = ContentType.Unicode;
            textBuffer.Direction = (otFeat.RightToLeft) ? Direction.RightToLeft : Direction.LeftToRight;
            SetLanguage(otFeat.Language, textBuffer);
            textBuffer.AddUtf8(text);
        }

        void SetLanguage(HarfbuzzLanguage lang, HarfBuzzSharp.Buffer buffer) {
            switch (lang) {
                case HarfbuzzLanguage.Arabic:
                    buffer.Language = new Language(new System.Globalization.CultureInfo("ar"));
                    buffer.Script = Script.Arabic;
                    break;
                case HarfbuzzLanguage.ChineseHan:
                    buffer.Language = new Language(new System.Globalization.CultureInfo("zh"));
                    buffer.Script = Script.Han;
                    break;
                case HarfbuzzLanguage.JapanHiragana:
                    buffer.Language = new Language(new System.Globalization.CultureInfo("ja"));
                    buffer.Script = Script.Hiragana;
                    break;
                case HarfbuzzLanguage.JapanKatakana:
                    buffer.Language = new Language(new System.Globalization.CultureInfo("ja"));
                    buffer.Script = Script.Katakana;
                    break;
                case HarfbuzzLanguage.KoreanHangul:
                    buffer.Language = new Language(new System.Globalization.CultureInfo("ko"));
                    buffer.Script = Script.Hangul;
                    break;
                default:
                    buffer.Language = new Language(new System.Globalization.CultureInfo("en"));
                    buffer.Script = Script.Latin;
                    break;
            }
        }

        Feature[] PopulateFeatures(OpenTypeFeatures otFeat) {
            List<Feature> features = new List<Feature>();
            features.Add(CreateFeature("kern", otFeat.Kerning));
            features.Add(CreateFeature("liga", otFeat.Ligatures));
            features.Add(CreateFeature("rlig", otFeat.Ligatures));
            features.Add(CreateFeature("cpsp", otFeat.CapitalSpacing));
            return features.ToArray();
        }

        Feature CreateFeature(string tag, bool switchOn) {
            return new Feature(CreateTag(tag), (uint)((switchOn) ? 1 : 0), 0, Int32.MaxValue);
        }

        Tag CreateTag(string tagName) {
            char[] t = tagName.ToCharArray();
            return new Tag(t[0], t[1], t[2], t[3]);
        }
    }
}
