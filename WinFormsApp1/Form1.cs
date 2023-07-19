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

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //textBox1.Text = openFileDialog1.FileName;
                }
            }
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MLModel1.ModelOutput result = new MLModel1.ModelOutput();

            Thread thread = new Thread(new ThreadStart(() =>
            {
                result = this.check();
            }));
            thread.Start();
            label1.Text = "";

            label1.Text += "��͒��Ȃ�\n";
            thread.Join();



            label1.Text = "";
            label1.Text += "���̉摜�́B�B�B\n";

            DataViewSchema.Column? col = MLModel1.PredictEngine.Value.OutputSchema.GetColumnOrNull("Score");
            VBuffer<ReadOnlyMemory<char>> value = default;
            col.Value.Annotations.GetValue("TrainingLabelValues", ref value);

            label1.Text += (result.Score[0] * 100) + "��\n�̊m���ł����Ă��\n";

            if (result.Score[0] >= 0.5)
            {
                label1.Text += "���������Ă��B";
            }
            else
            {
                label1.Text += "���������ĂȂ�";
            }

            //Load sample data
            /*MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                ImageSource = textBox1.Text,
            };

            //Load model and predict output
            var result = MLModel1.Predict(sampleData);

            //label1.Text += String.Format("���̉摜�� : {0} / �X�R�A: {1:f} \r\n", result.PredictedLabel, result.Score.Max());

            DataViewSchema.Column? col = MLModel1.PredictEngine.Value.OutputSchema.GetColumnOrNull("Score");
            VBuffer<ReadOnlyMemory<char>> value = default;
            col.Value.Annotations.GetValue("TrainingLabelValues", ref value);


            label1.Text += "�X�R�A\r\n";
            for (int i = 0; i < result.Score.Length; i++)
            {
                label1.Text += String.Format("Label : {0}  Score : {1:f}\r\n", value.GetItemOrDefault(i).ToString(), result.Score[i]);
            }*/

        }

        private MLModel1.ModelOutput check()
        {
            //Load sample data
            var sampleData = new MLModel1.ModelInput()
            {
                //ImageSource = textBox1.Text,
            };
            //Load model and predict output
            return MLModel1.Predict(sampleData);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //Bitmap image = new Bitmap("201902020000.vis.01.fld.geoss.png");
            int x = 800;    // �������x���W
            int y = 300;    // �������y���W
            int width = 1085 - 800;    // �؂���̈�̕�
            int height = 527 - 300;   // �؂���̈�̍���

            List<double> cloudPercentages = new List<double>();
            List<Bitmap> images = new List<Bitmap>();

            Thread thread = new Thread(new ThreadStart(() =>
            {
                string baseDirectory = "VIS01";
                string format = "yyyyMM";

                DateTime startDate = new DateTime(2019, 9, 1);
                DateTime endDate = new DateTime(2023, 3, 1);

                DateTime currentDate = startDate;

                while (currentDate <= endDate)
                {
                    string folderName = currentDate.ToString(format) + "\\";
                    string folderPath = Path.Combine(baseDirectory, folderName);
                    

                    Debug.WriteLine(folderPath);

                    if (Directory.Exists(folderPath))
                    {
                        List<Bitmap> images = ImageProcessing.LoadImagesFromDirectory(folderPath);

                        //�ǂݍ��܂ꂽ�摜�̐���\��
                        Debug.WriteLine($"�ǂݍ��܂ꂽ�摜�̐� ({folderName}): {images.Count}");

                        List<double> cloudPerMonth = new List<double>();
                        foreach (Bitmap img in images)
                        {
                            double cloudPercentage = ImageProcessing.CalculateCloudPercentage(img, x, y, width, height);
                            cloudPercentages.Add(cloudPercentage);
                            cloudPerMonth.Add(cloudPercentage);
                            string filePath = "list_data.bin";
                            ListConversion.SaveDoubleListAsSingleFile(cloudPercentages, filePath);
                            //List<System.Single> percentages = ListConversion.LoadListFromSingleFile(filePath);
                            //Debug.WriteLine("----------------------");
                            //foreach (System.Single p in percentages)
                            //    Debug.WriteLine(p);
                            //Debug.WriteLine("----------------------");
                        }
                        ListConversion.SaveDoubleListAsSingleFile(cloudPerMonth, currentDate.ToString(format)+".bin");

                        //���̌��ɐi��
                        currentDate = currentDate.AddMonths(1);
                    }
                    else
                    {
                        //�t�H���_�����݂��Ȃ��ꍇ�̓X�L�b�v���Ď��̌��ɐi��
                        currentDate = currentDate.AddMonths(1);
                        continue;
                    }
                }

                string filePath2 = "list_data.bin";

                //VIS01\201802\�܂ŕۑ�����
                ListConversion.SaveDoubleListAsSingleFile(cloudPercentages, filePath2);
                List<System.Single> percentages2 = ListConversion.LoadListFromSingleFile(filePath2);

                Debug.WriteLine("��͂��I���܂����B");
                foreach (System.Single cp in percentages2)
                    Debug.WriteLine(cp);


            }));
            thread.Start();
            label1.Text = "";
            label1.Text += "��͒��Ȃ�\n";
            thread.Join();
            label1.Text = "��͏I��\n";
            //label1.Text += "�_�̊�����\n" + zeroPercentage + "%\n��������";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /*string filePath = "list_data.bin";
            List<System.Single> percentages = ListConversion.LoadListFromSingleFile(filePath);

            Thread thread = new Thread(new ThreadStart(() =>
            {
                Sample08.RunPredict(percentages);
                //Sample08.RunPredict(percentages, percentages[0], percentages[1], percentages[2]);
            }));
            thread.Start();
            label1.Text = "";
            label1.Text += "��͒��Ȃ�\n";
            thread.Join();
            label1.Text = "";
            label1.Text += "��͏I��";
            */

            Form5 f5 = new Form5();
            f5.Show();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}