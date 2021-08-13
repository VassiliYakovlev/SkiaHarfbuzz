using SkiaSharp;
using System;
using System.Threading.Tasks;

namespace SkiaHarfbuzzCSharp.Skia {
    interface ISkiaHelper : IDisposable {
        HelperType Type { get; }
        bool LoadTypeface(string fontFileName);
        string GetFontName();
        byte[] RenderText(string text, OpenTypeFeatures otFeat, GraphicsSettings grSettings);
    }

    class OpenTypeFeatures {
        public float FontSize { get; set; }
        public bool RightToLeft { get; set; }
        public HarfbuzzLanguage Language { get; set; }
        public bool Kerning { get; set; }
        public bool Ligatures { get; set; }
        public bool CapitalSpacing { get; set; }
    }

    class GraphicsSettings {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Antialiasing { get; set; }
        public bool OK(SKImageInfo skImgInfo) {
            if (skImgInfo == null)
                return false;
            if (skImgInfo.Width != Width)
                return false;
            if (skImgInfo.Height != Height)
                return false;
            return true;
        }
    }
}
