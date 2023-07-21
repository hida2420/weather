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

        //�摜����
        private void button4_Click_1(object sender, EventArgs e)
        {
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
                        //�ꂩ�����̉摜��ǂݍ���
                        List<Bitmap> images = ImageProcessing.LoadImagesFromDirectory(folderPath);

                        Debug.WriteLine($"�ǂݍ��܂ꂽ�摜�̐� ({folderName}): {images.Count}");

                        //�_�̊������Z�o���Abin�t�@�C���ɕۑ�����
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

                //�ŏI�I�ȕۑ�
                string filePath2 = "list_data.bin";
                ListConversion.SaveDoubleListAsSingleFile(cloudPercentages, filePath2);
                List<System.Single> percentages2 = ListConversion.LoadListFromSingleFile(filePath2);

                Debug.WriteLine("��͂��I���܂����B");

            }));
            thread.Start();
            label1.Text = "";
            label1.Text += "�_�̊����Z�o��...\n";
            thread.Join();
            label1.Text = "�I��\n";
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