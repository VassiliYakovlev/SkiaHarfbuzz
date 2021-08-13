using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkiaHarfbuzzCSharp
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            PopulateLanguageItems();
        }

        Skia.ISkiaHelper skiaHelper;
        Skia.OpenTypeFeatures otFeat;
        Skia.GraphicsSettings grSettings;

        Image RenderText(string text) {
            if (skiaHelper == null || 
                (cbHarfbuzz.Checked && skiaHelper.Type != Skia.HelperType.Harfbuzz) ||
                (!cbHarfbuzz.Checked && skiaHelper.Type != Skia.HelperType.Skia))
                skiaHelper = Skia.SkiaHelperFactory.Create((cbHarfbuzz.Checked) ? Skia.HelperType.Harfbuzz : Skia.HelperType.Skia);

            if (skiaHelper.LoadTypeface(openFontFileDialog.FileName)) {
                byte[] imageBytes = skiaHelper.RenderText(text, otFeat, grSettings);

                return Image.FromStream(new MemoryStream(imageBytes));
            }

            return null;
        }

        void InitOpenTypeFeatures() {
            if (otFeat == null)
                otFeat = new Skia.OpenTypeFeatures();
            otFeat.FontSize = tbFontSize.Value;
            otFeat.Language = (Skia.HarfbuzzLanguage)comboBoxLanguage.SelectedItem;
            otFeat.RightToLeft = cbRTL.Checked;
            otFeat.Kerning = cbKerning.Checked;
            otFeat.Ligatures = cbLigatures.Checked;
            otFeat.CapitalSpacing = cbCapSpacing.Checked;
        }

        void InitGraphicsSettings() {
            if (grSettings == null)
                grSettings = new Skia.GraphicsSettings();
            grSettings.Width = pictureBox1.Width;
            grSettings.Height = pictureBox1.Height;
            grSettings.Antialiasing = cbAntiAliasing.Checked;
        }

        async Task RenderTextAsync() {
            if (_rendering)
                return;
            if (string.IsNullOrEmpty(openFontFileDialog.FileName))
                return;
            if (comboBoxLanguage.SelectedItem == null)
                return;

            _rendering = true;

            InitOpenTypeFeatures();
            InitGraphicsSettings();

            string text = tbText.Text;

            Image img = await Task.Run(() => {
                return RenderText(text);
            });

            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            pictureBox1.Image = img;

            if (skiaHelper != null)
                lblFontName.Text = skiaHelper.GetFontName();

            _rendering = false;
        }

        void PopulateLanguageItems() {
            comboBoxLanguage.Items.Add(Skia.HarfbuzzLanguage.Default);
            comboBoxLanguage.Items.Add(Skia.HarfbuzzLanguage.Arabic);
            comboBoxLanguage.Items.Add(Skia.HarfbuzzLanguage.ChineseHan);
            comboBoxLanguage.Items.Add(Skia.HarfbuzzLanguage.JapanHiragana);
            comboBoxLanguage.Items.Add(Skia.HarfbuzzLanguage.JapanKatakana);
            comboBoxLanguage.Items.Add(Skia.HarfbuzzLanguage.KoreanHangul);
            comboBoxLanguage.SelectedItem = Skia.HarfbuzzLanguage.Default;
        }
        private void bOpenFontFile_Click(object sender, EventArgs e) {
            if (openFontFileDialog.ShowDialog() == DialogResult.OK) {
                _ = RenderTextAsync();
            }
        }

        static bool _rendering = false;
        private void onControlChanged(object sender, EventArgs e) {
            _ = RenderTextAsync();
        }
    }
}
