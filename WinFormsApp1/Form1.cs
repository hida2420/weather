using Microsoft.ML;
using Microsoft.ML.Data;
using KelpNet.CL;
using System.Diagnostics;
using KelpNet.Tools;
using KelpNet.CL.Common;



namespace WinFormsApp1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        //画像処理
        private void button4_Click_1(object sender, EventArgs e)
        {
            int x = 800;    // 左上隅のx座標
            int y = 300;    // 左上隅のy座標
            int width = 1085 - 800;    // 切り取る領域の幅
            int height = 527 - 300;   // 切り取る領域の高さ

            List<double> cloudPercentages = new List<double>();
            List<Bitmap> images = new List<Bitmap>();

            Thread thread = new Thread(new ThreadStart(() =>
            {
                string baseDirectory = "VIS01";
                string format = "yyyyMM";

                DateTime startDate = new DateTime(2023, 1, 1);
                DateTime endDate = new DateTime(2023, 6, 1);

                DateTime currentDate = startDate;

                while (currentDate <= endDate)
                {
                    string folderName = currentDate.ToString(format) + "\\";
                    string folderPath = Path.Combine(baseDirectory, folderName);
                    

                    Debug.WriteLine(folderPath);

                    if (Directory.Exists(folderPath))
                    {
                        //一か月分の画像を読み込み
                        List<Bitmap> images = ImageProcessing.LoadImagesFromDirectory(folderPath);

                        Debug.WriteLine($"読み込まれた画像の数 ({folderName}): {images.Count}");

                        //雲の割合を算出し、binファイルに保存する
                        List<double> cloudPerMonth = new List<double>();
                        foreach (Bitmap img in images)
                        {
                            double cloudPercentage = ImageProcessing.CalculateCloudPercentage(img, x, y, width, height);
                            cloudPercentages.Add(cloudPercentage);
                            cloudPerMonth.Add(cloudPercentage);
                            string filePath = "list_data.bin";
                            ListConversion.SaveDoubleListAsSingleFile(cloudPercentages, filePath);

                        }
                        ListConversion.SaveDoubleListAsSingleFile(cloudPerMonth, currentDate.ToString(format)+".bin");

                        //次の月に進む
                        currentDate = currentDate.AddMonths(1);
                    }
                    else
                    {
                        //フォルダが存在しない場合はスキップして次の月に進む
                        currentDate = currentDate.AddMonths(1);
                        continue;
                    }
                }

                //最終的な保存
                string filePath2 = "list_data.bin";
                ListConversion.SaveDoubleListAsSingleFile(cloudPercentages, filePath2);
                List<System.Single> percentages2 = ListConversion.LoadListFromSingleFile(filePath2);

                Debug.WriteLine("解析が終わりました。");

            }));
            thread.Start();
            label1.Text = "";
            label1.Text += "雲の割合算出中...\n";
            thread.Join();
            label1.Text = "終了\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}