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
            "clouds/201702.bin",
            "clouds/201703.bin",
            "clouds/201704.bin",
            "clouds/201705.bin",
            "clouds/201706.bin",
            "clouds/201707.bin",
            "clouds/201708.bin",
            "clouds/201709.bin",
            "clouds/201710.bin",
            "clouds/201711.bin",
            "clouds/201712.bin",
            "clouds/201801.bin",
            "clouds/201802.bin",
            "clouds/201803.bin",
            "clouds/201804.bin",
            "clouds/201805.bin",
            "clouds/201806.bin",
            "clouds/201807.bin",
            "clouds/201808.bin",
            "clouds/201809.bin",
            "clouds/201810.bin",
            "clouds/201811.bin",
            "clouds/201812.bin",
            "clouds/201901.bin",
            "clouds/201902.bin",
            "clouds/201903.bin",
            "clouds/201904.bin",
            "clouds/201905.bin",
            "clouds/201906.bin",
            "clouds/201907.bin",
            "clouds/201908.bin",
            "clouds/201909.bin",
            "clouds/201910.bin",
            "clouds/201911.bin",
            "clouds/201912.bin",
            "clouds/202001.bin",
            "clouds/202002.bin",
            "clouds/202003.bin",
            "clouds/202004.bin",
            "clouds/202005.bin",
            "clouds/202006.bin",
            "clouds/202007.bin",
            "clouds/202008.bin",
            "clouds/202009.bin",
            "clouds/202010.bin",
            "clouds/202011.bin",
            "clouds/202012.bin",
            "clouds/202101.bin",
            "clouds/202102.bin",
            "clouds/202103.bin",
            "clouds/202104.bin",
            "clouds/202105.bin",
            "clouds/202106.bin",
            "clouds/202107.bin",
            "clouds/202108.bin",
            "clouds/202109.bin",
            "clouds/202110.bin",
            "clouds/202111.bin",
            "clouds/202112.bin",
            "clouds/202201.bin",
            "clouds/202202.bin",
            "clouds/202203.bin",
            "clouds/202204.bin",
            "clouds/202205.bin",
            "clouds/202206.bin",
            "clouds/202207.bin",
            "clouds/202208.bin",
            "clouds/202209.bin",
            "clouds/202210.bin",
            "clouds/202211.bin",
            "clouds/202212.bin",
            "clouds/202301.bin",
            "clouds/202302.bin",
            "clouds/202303.bin",
            "clouds/202304.bin",
            "clouds/202305.bin",
            "clouds/202306.bin"
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
