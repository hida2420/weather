using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private float select(ComboBox cb)
        { 
            return 0F + (cb.SelectedIndex - 1F) * 25F;
        }

        private float select_snow(ComboBox cb)
        {
            return 0F + (cb.SelectedIndex - 1F) * (30F / 4F);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WeatherPredict wp = new WeatherPredict();

            //comboBox1天気昼
            //comBoBox2降雪量
            //bomboBox3日照時間
            //comboBox4風向
            //comboBox5降水量
            //comboBox6天気夜
            //textBox1湿度
            //textBox3最高気温
            //textBox4最低気温
            //textBox6速度
            wp.weatherPredict(comboBox1.SelectedIndex, //天気昼
                comboBox6.SelectedIndex, //天気夜
                Single.Parse(textBox1.Text), //湿度
                Single.Parse(comboBox3.SelectedText), //日照時間
                select(comboBox5), //降水量
                Single.Parse(textBox3.Text), //最高気温
                Single.Parse(textBox4.Text), //最低気温
                select_snow(comboBox2), //降雪量
                Single.Parse(textBox6.Text), //速度
                comboBox4.SelectedIndex);//風向
        }
    }
}
