using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Translator
{
    public partial class Form1 : Form
    {
        YandexTranslator yt;
        YandexDictionary dt;

        public Form1()
        {
            InitializeComponent();

            yt = new YandexTranslator();
            dt = new YandexDictionary();
            if (!comboBox1.Items.Contains("Выберите язык"))
            {
                comboBox1.Items.Add("Выберите язык");
            }
            comboBox1.Text = "Выберите язык";
            comboBox1.DropDown += comboBox1_DropDown;

            if (!comboBox2.Items.Contains("Выберите язык"))
            {
                comboBox2.Items.Add("Выберите язык");
            }
            comboBox2.Text = "Выберите язык";
            comboBox2.DropDown += comboBox2_DropDown;

        }


        private void translateButton_Click(object sender, EventArgs e)
        {
            string lang;
            string defis = "-";
            //string comboText = comboBox1.Text;
            int indexLang1 = comboBox1.SelectedIndex;
            int indexLang2 = comboBox2.SelectedIndex;
            string [] array = File.ReadAllText("1.txt", Encoding.Default).Split(' ');
            if (indexLang1 != 0)
            {
                lang = array[indexLang1] + defis + array[indexLang2 + 1];
            }
            else lang = array[indexLang2 + 1];

          outputTextBox.Text = yt.Translate(inputTextBox.Text, lang);
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (comboBox1.Items.Contains("Выберите язык"))
                comboBox1.Items.Remove("Выберите язык");
        }
        void comboBox2_DropDown(object sender, EventArgs e)
        {
            if (comboBox2.Items.Contains("Выберите язык"))
                comboBox2.Items.Remove("Выберите язык");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void outputTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DictionaryButton_Click_1(object sender, EventArgs e)
        {
            string lang = "";
            string defis = "-";
            int indexLang1 = comboBox4.SelectedIndex;
            int indexLang2 = comboBox3.SelectedIndex;
            string[] array = {"en", "fr", "de", "es", "it", "pt", "ru"};
            if ((indexLang1 != -1) & (indexLang2 != -1))
            lang = array[indexLang1] + defis + array[indexLang2];
            var part = checkBox1.Checked;
            var tr = checkBox2.Checked;
            var ex = checkBox3.Checked;
            var extext = checkBox4.Checked;
            outputDictTextBox.Text = dt.Finder(textBox1.Text, lang, tr, part, ex, extext);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void блаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            var a = tab123.SelectedIndex;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                if(a == 0) streamWriter.WriteLine(outputDictTextBox.Text);
                streamWriter.WriteLine(inputTextBox.Text);
                streamWriter.WriteLine(outputTextBox.Text); 
                streamWriter.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}