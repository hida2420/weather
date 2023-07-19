﻿
// This file was auto-generated by ML.NET Model Builder. 

using System;

namespace WinFormsApp1
{
    class WeatherPredict
    {
        public void weatherPredict(float col0, float col1, float col2, float col3, float col4, float col5, float col6, float col7, float col8, float col9)
        {
            // Create single instance of sample data from first line of dataset for model input
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                Col0 = col0,
                Col1 = col1,
                Col2 = col2,
                Col3 = col3,
                Col4 = col4,
                Col5 = col5,
                Col6 = col6,
                Col7 = col7,
                Col8 = col8,
                Col9 = col9,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = MLModel1.Predict(sampleData);

            Console.WriteLine($"\n\nPredicted Col1: {predictionResult.Prediction}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
