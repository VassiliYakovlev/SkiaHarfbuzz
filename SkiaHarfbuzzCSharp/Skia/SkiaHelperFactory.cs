
namespace SkiaHarfbuzzCSharp.Skia {
    enum HelperType {
        Skia,
        Harfbuzz
    }

    enum HarfbuzzLanguage {
        Default,
        Arabic,
        ChineseHan,
        JapanHiragana,
        JapanKatakana,
        KoreanHangul
    }

    static class SkiaHelperFactory {
        public static ISkiaHelper Create(HelperType type) {
            if (type == HelperType.Harfbuzz)
                return new HarfbuzzHelper();
            return new SkiaHelper();
        }
    }
}
