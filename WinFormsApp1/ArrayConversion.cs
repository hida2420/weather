using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp1
{
    public class ListConversion
    {
        public static void SaveDoubleListAsSingleFile(List<double> list, string filePath)
        {
            // Single �^�̃��X�g���쐬���A�v�f��ϊ����Ċi�[
            List<float> singleList = new List<float>();
            foreach (double value in list)
            {
                singleList.Add((float)value);
            }

            // �o�C�i���t�@�C���ɕۑ�
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(singleList.Count);  // ���X�g�̗v�f������������
                foreach (float value in singleList)
                {
                    writer.Write(value);  // �e�v�f����������
                }
            }

            Console.WriteLine("Double list saved as single file.");
        }

        public static List<System.Single> LoadListFromSingleFile(string filePath)
        {
            // �o�C�i���t�@�C������ǂݍ���
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                int count = reader.ReadInt32();  // ���X�g�̗v�f����ǂݍ���
                List<System.Single> singleList = new List<System.Single>();
                for (int i = 0; i < count; i++)
                {
                    singleList.Add(reader.ReadSingle());  // �e�v�f��ǂݍ���
                }


                Console.WriteLine("Double list loaded from single file.");
                return singleList;
            }
        }
    }
}
