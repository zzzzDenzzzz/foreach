using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        char[] chars = "foreach (PictureBox pictureBox in groupBox1.Controls.OfType<PictureBox>())".ToUpper().ToCharArray();

        public Form1()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            PictureBoxColor();
        }

        async void PrintTextLabel()
        {
            foreach (char ch in chars)
            {
                label1.Text += ch;
                await Task.Delay(50);
            }
        }

        async void PictureBoxColor()
        {
            foreach (PictureBox pictureBox in groupBox1.Controls.OfType<PictureBox>())
            {
                pictureBox.BackColor = Color.FromArgb(150, 135, 140);
                await Task.Delay(200);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintTextLabel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorLabel();
            foreach (PictureBox pictureBox in groupBox1.Controls.OfType<PictureBox>())
            {
                ColorPictureBox(pictureBox);
            }
        }

        async void ColorLabel()
        {
            label1.Text = string.Join("",chars);

            for (byte r = 130, g = 70, b = 180; r >= 25 & g >= 50 & b >= 20; r -= 5, g--, b -= 8, await Task.Delay(50))
            {
                label1.ForeColor = Color.FromArgb(r, g, b);
            }

            for (byte r = 25, g = 50, b = 20; r <= 130 & g <= 70 & b <= 180; r += 5, g++, b += 8, await Task.Delay(50))
            {
                label1.ForeColor = Color.FromArgb(r, g, b);
            }

            label1.ForeColor = Color.FromArgb(130, 70, 180);
        }

        async void ColorPictureBox(PictureBox pictureBox)
        {
            for (byte r = 150, g = 135, b = 140; r >= 130 & g >= 70 & b <= 180; r--, g -= 3, b += 2, await Task.Delay(50))
            {
                pictureBox.BackColor = Color.FromArgb(r, g, b);
            }

            pictureBox.BackColor = Color.FromArgb(130, 70, 180);
        }
    }
}
