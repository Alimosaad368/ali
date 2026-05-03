using System;

class Program
{
    static void Main()
    {
        int[] data = {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179,
            83, 21, 20, 21, 186, 177, 195, 193, 188, 199,
            62, 109, 105, 183, 110
        };

        int n = data.Length;

        // Sort
        Array.Sort(data);

        // Mean
        double sum = 0;
        for (int i = 0; i < n; i++)
            sum += data[i];

        double mean = sum / n;

        // Median
        double median;
        if (n % 2 == 0)
            median = (data[n / 2] + data[n / 2 - 1]) / 2.0;
        else
            median = data[n / 2];

        // Mode
        int mode = data[0];
        int maxCount = 1;

        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (data[i] == data[j])
                    count++;
            }

            if (count > maxCount)
            {
                maxCount = count;
                mode = data[i];
            }
        }

        // Variance
        double variance = 0;
        for (int i = 0; i < n; i++)
            variance += Math.Pow(data[i] - mean, 2);

        variance = variance / n;

        // Standard Deviation
        double stdDev = Math.Sqrt(variance);

        // Quartiles
        double q1 = data[n / 4];
        double q3 = data[(3 * n) / 4];

        // Range
        int range = data[n - 1] - data[0];

        // IQR
        double iqr = q3 - q1;

        // Outliers
        double lower = q1 - 1.5 * iqr;
        double upper = q3 + 1.5 * iqr;

        // Output
        Console.WriteLine("Mean = " + mean);
        Console.WriteLine("Median = " + median);
        Console.WriteLine("Mode = " + mode);
        Console.WriteLine("Variance = " + variance);
        Console.WriteLine("Standard Deviation = " + stdDev);
        Console.WriteLine("Q1 = " + q1);
        Console.WriteLine("Q2 = " + median);
        Console.WriteLine("Q3 = " + q3);
        Console.WriteLine("Range = " + range);
        Console.WriteLine("IQR = " + iqr);

        Console.WriteLine("Outliers:");
        for (int i = 0; i < n; i++)
        {
            if (data[i] < lower || data[i] > upper)
                Console.WriteLine(data[i]);
        }
    }
}
