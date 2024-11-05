using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace winforms_lab2
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private int timeRemaining;
        private int timeRemainingTotal; // Для отслеживания исходного значения времени
        private bool isTimerRunning = false;

        public Form1()
        {
            InitializeComponent(); // Должен быть вызван только один раз

            // Инициализация элементов
            timer = new Timer();
            timer.Interval = 1000; // 1 секунда
            timer.Tick += Timer_Tick;
            label1.Text = "Осталось 0";
            // Настройка NumericUpDown
            numericUpDown1.Minimum = 1;
            numericUpDown1.Value = 10; // Значение по умолчанию (10)

            // Настройка ComboBox
            comboBox1.Items.AddRange(new string[] { "Секунды", "Минуты", "Часы" });
            comboBox1.SelectedIndex = 0; // По умолчанию выбираем "Секунды"
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Уменьшаем время
            timeRemaining--;

            // Обновляем прогресс
            int progress = (int)((double)(timeRemaining) / timeRemainingTotal * 100); // Перерасчёт прогресса
            progressBar1.Value = progress;

            // Обновляем отображение оставшегося времени
            label1.Text = $"Осталось времени: {timeRemaining}";

            if (timeRemaining <= 0)
            {
                // Останавливаем таймер и закрываем форму
                timer.Stop();
                MessageBox.Show("Время вышло!");
                this.Close(); // Закрытие формы
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isTimerRunning)
                return;

            // Определяем количество секунд, в зависимости от выбранной единицы
            int timeValue = (int)numericUpDown1.Value;
            string selectedUnit = comboBox1.SelectedItem.ToString();

            if (selectedUnit == "Минуты")
            {
                timeValue *= 60; // Перевод в секунды
            }
            else if (selectedUnit == "Часы")
            {
                timeValue *= 3600; // Перевод в секунды
            }

            // Устанавливаем оставшееся время и общее время
            timeRemaining = timeValue;
            timeRemainingTotal = timeValue;  // Сохраняем исходное значение для расчёта прогресса
            progressBar1.Maximum = 100;  // Устанавливаем максимальное значение для прогресса
            progressBar1.Value = 0;      // Начинаем с нуля
            label1.Text = $"Осталось времени: {timeRemaining}";

            // Запускаем таймер
            timer.Start();
            isTimerRunning = true;

            // Отключаем кнопку "Старт" и включаем "Стоп"
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isTimerRunning)
            {
                // Останавливаем таймер
                timer.Stop();
                isTimerRunning = false;

                // Включаем кнопку "Старт" и отключаем "Стоп"
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
