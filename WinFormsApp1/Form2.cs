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

        private float select_snow(ComboBox cb)
        {
            return 0F + (cb.SelectedIndex - 1F) * (30F / 4F);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = "予測中...";
            string[] weatherArray = new string[]
            {
            "晴れ",
            "曇り",
            "雨",
            "雪",
            "みぞれ",
            "晴れのち曇り",
            "晴れのち雨",
            "晴れのち雪",
            "曇りのち晴れ",
            "曇りのち雨",
            "曇りのち雪",
            "曇りのみぞれ",
            "雨のち曇り",
            "雨のちみぞれ",
            "雪のち曇り",
            "雪のちみぞれ",
            "雨のち晴れ",
            "雪のち晴れ"
            };

            WeatherPredict wp = new WeatherPredict();
            int result_idx = 0;

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
            result_idx = wp.weatherPredict(comboBox1.SelectedIndex, //天気昼
                comboBox6.SelectedIndex, //天気夜
                Single.Parse(textBox1.Text), //湿度
                Single.Parse(textBox2.Text), //日照時間
                Single.Parse(textBox5.Text), //降水量
                Single.Parse(textBox3.Text), //最高気温
                Single.Parse(textBox4.Text), //最低気温
                select_snow(comboBox2), //降雪量
                Single.Parse(textBox6.Text), //速度
                comboBox4.SelectedIndex);//風向

            string selectedWeather = weatherArray[result_idx];

            //選択された天気に応じた文章を出力
            switch (selectedWeather)
            {
                case "晴れ":
                    label1.Text = ("次の日の天気は晴れでしょう\n楽しい一日を過ごしてくださいね！");
                    break;
                case "曇り":
                    label1.Text = ("次の日の天気は曇りかもしれません\n傘を持って出かけると安心ヨシ♪");
                    break;
                case "雨":
                    label1.Text = ("次の日の天気は雨でしょう\n傘を忘れずにね～");
                    break;
                case "雪":
                    label1.Text = ("次の日の天気は雪が降るかもしれません\n温かくして外出しましょ～");
                    break;
                case "みぞれ":
                    label1.Text = ("次の日の天気はみぞれの可能性もあります\n気をつけて過ごしてください♪");
                    break;
                case "晴れのち曇り":
                    label1.Text = ("次の日の天気は晴れのち曇りかもしれません\n気温の変化にご注意ヨシ");
                    break;
                case "晴れのち雨":
                    label1.Text = ("次の日の天気は晴れのち雨になるかもしれません\n傘を持っていくと良いでしょ～");
                    break;
                case "晴れのち雪":
                    label1.Text = ("次の日の天気は晴れのち雪の可能性もあります\n防寒対策を万全にしてほしいヨシ");
                    break;
                case "曇りのち晴れ":
                    label1.Text = ("次の日の天気は曇りのち晴れかもしれません\n服装にお気をつけヨシ");
                    break;
                case "曇りのち雨":
                    label1.Text = ("次の日の天気は曇りのち雨になるかもしれません\n傘が必要かもしれませんね～");
                    break;
                case "曇りのち雪":
                    label1.Text = ("次の日の天気は曇りのち雪の可能性もあります\n外出の際は十分ご注意ヨシ");
                    break;
                case "曇りのみぞれ":
                    label1.Text = ("次の日の天気は曇りのみぞれの可能性もあります\n寒さ対策をお忘れなく♪");
                    break;
                case "雨のち曇り":
                    label1.Text = ("次の日の天気は雨のち曇りかもしれません\n天気の変化にご注意ヨシ");
                    break;
                case "雨のちみぞれ":
                    label1.Text = ("次の日の天気は雨のちみぞれになるかもしれません\n慎重に行動しましょ～");
                    break;
                case "雪のち曇り":
                    label1.Text = ("次の日の天気は雪のち曇りの可能性もあります\n外出の際は足元にご注意ヨシ");
                    break;
                case "雪のちみぞれ":
                    label1.Text = ("次の日の天気は雪のちみぞれかもしれません\n防寒対策をしてお過ごしヨシ");
                    break;
                case "雨のち晴れ":
                    label1.Text = ("次の日の天気は雨のち晴れになるかもしれません\n天気が良くなったら楽しんでヨシ♪");
                    break;
                case "雪のち晴れ":
                    label1.Text = ("次の日の天気は雪のち晴れになるかもしれません\n雪が止んだら景色が美しいヨシよ♪");
                    break;
                default:
                    label1.Text = ("天気情報が不明です\n天気予報を確認してほしいヨシ");
                    break;
            }
        }
    }
}
