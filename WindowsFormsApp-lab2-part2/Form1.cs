using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp_lab2_part2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDownWidth.Minimum = 200;  // Минимальная ширина
            numericUpDownWidth.Maximum = 1920; // Максимальная ширина (для примера)
            numericUpDownHeight.Minimum = 200;  // Минимальная высота
            numericUpDownHeight.Maximum = 1080; // Максимальная высота


            // Инициализация радиокнопок для фона
            radioButton1.Text = "Фон 1";
            radioButton2.Text = "Фон 2";
            radioButton3.Text = "Фон 3";
            radioButton4.Text = "Фон 4";
            radioButton1.Click += radioButton1_CheckedChanged;
            radioButton2.Click += radioButton2_CheckedChanged;
            radioButton3.Click += radioButton3_CheckedChanged;
            radioButton4.Click += radioButton4_CheckedChanged;
            // Устанавливаем радиокнопки для фона по умолчанию
            radioButton1.Checked = true;
            this.BackgroundImage = Image.FromFile("C:\\Users\\user\\Downloads\\winter.jpg"); // Путь к изображению 1

            // Инициализация комбинированного списка для заголовка формы
            comboBoxFont.Items.AddRange(new string[] { "Заголовок 1", "Заголовок 2", "Заголовок 3", "Заголовок 4" });
            comboBoxFont.SelectedIndex = 0; // Устанавливаем по умолчанию заголовок 1
            this.Text = comboBoxFont.SelectedItem.ToString();

            // Настройка NumericUpDown для ширины и высоты формы
            numericUpDownWidth.Value = this.Width;
            numericUpDownHeight.Value = this.Height;

            // Подписка на события изменения размеров формы
            numericUpDownWidth.ValueChanged += (sender, e) => this.Width = (int)numericUpDownWidth.Value;
            numericUpDownHeight.ValueChanged += (sender, e) => this.Height = (int)numericUpDownHeight.Value;

            // Настройка ComboBox для выбора шрифта
            comboBoxFont.Items.AddRange(new string[] { "Arial", "Verdana", "Times New Roman", "Courier New" });
            comboBoxFont.SelectedIndex = 0; // Устанавливаем шрифт по умолчанию
            ApplyFontToControls(); // Применяем выбранный шрифт ко всем элементам

            // Подписка на изменение шрифта
            comboBoxFont.SelectedIndexChanged += (sender, e) => ApplyFontToControls();
        }

        // Метод для применения шрифта ко всем элементам управления
        private void ApplyFontToControls()
        {
            Font selectedFont = new Font(comboBoxFont.SelectedItem.ToString(), 10);
            foreach (Control control in this.Controls)
            {
                control.Font = selectedFont;
            }
        }

        // Обработчики для радиокнопок, изменяющих фон
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                this.BackgroundImage = Image.FromFile("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVWzsNE_GkGveNpr6vnUnsrjblx6lxNNR3TQ&s");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                this.BackgroundImage = Image.FromFile("https://www.christmascentral.com/product_images/uploaded_images/sunny-winter-scene-lars-eberhardt-bcg-yva8tha-unsplash-960x600.jpg");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                this.BackgroundImage = Image.FromFile("https://www.christmascentral.com/product_images/uploaded_images/sunny-winter-scene-lars-eberhardt-bcg-yva8tha-unsplash-960x600.jpg");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                this.BackgroundImage = Image.FromFile("https://www.christmascentral.com/product_images/uploaded_images/sunny-winter-scene-lars-eberhardt-bcg-yva8tha-unsplash-960x600.jpg");
        }

        // Обработчик для изменения заголовка формы из комбинированного списка
        private void comboBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = comboBoxFont.SelectedItem.ToString();
        }
    }
}
