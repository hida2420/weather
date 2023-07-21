using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            string[] fileNames = new string[]
            {
            "clouds/201701.bin",
            "201702.bin",
            "201703.bin",
            "201704.bin",
            "201705.bin",
            "201706.bin",
            "201707.bin",
            "201708.bin",
            "201709.bin",
            "201710.bin",
            "201711.bin",
            "201712.bin",
            "201801.bin",
            "201802.bin",
            "201803.bin",
            "201804.bin",
            "201805.bin",
            "201806.bin",
            "201807.bin",
            "201808.bin",
            "201809.bin",
            "201810.bin",
            "201811.bin",
            "201812.bin",
            "201901.bin",
            "201902.bin",
            "201903.bin",
            "201904.bin",
            "201905.bin",
            "201906.bin",
            "201907.bin",
            "201908.bin",
            "201909.bin",
            "201910.bin",
            "201911.bin",
            "201912.bin",
            "202001.bin",
            "202002.bin",
            "202003.bin",
            "202004.bin",
            "202005.bin",
            "202006.bin",
            "202007.bin",
            "202008.bin",
            "202009.bin",
            "202010.bin",
            "202011.bin",
            "202012.bin",
            "202101.bin",
            "202102.bin",
            "202103.bin",
            "202104.bin",
            "202105.bin",
            "202106.bin",
            "202107.bin",
            "202108.bin",
            "202109.bin",
            "202110.bin",
            "202111.bin",
            "202112.bin",
            "202201.bin",
            "202202.bin",
            "202203.bin",
            "202204.bin",
            "202205.bin",
            "202206.bin",
            "202207.bin",
            "202208.bin",
            "202209.bin",
            "202210.bin",
            "202211.bin",
            "202212.bin",
            "202301.bin",
            "202302.bin",
            "202303.bin",
            "202304.bin",
            "202305.bin",
            "202306.bin"
            };

            List<System.Single> percentages = ListConversion.LoadListFromSingleFile(fileNames[metroComboBox1.SelectedIndex]);
            Double[] pred = new Double[percentages.Count];
            Double[] date = new Double[percentages.Count];
            for (int i = 1; i <= percentages.Count; i++)
                date[i - 1] = i;
            Debug.WriteLine("test");
            pred = LSTM.RunPredict(percentages, percentages.Count);

            Debug.WriteLine("x:" + pred.Length + ", " + date.Length);
            formsPlot1.plt.Clear();
            formsPlot1.Plot.AddScatter(date, pred);
            formsPlot1.plt.XLabel("日付");
            formsPlot1.plt.YLabel("雲量の割合(%)");
            formsPlot1.plt.Legend();
            formsPlot1.Render();
            label1.Text = "予測がおわったよ♪";
        }
    }
}
