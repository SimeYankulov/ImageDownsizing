using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

/*
    ALL THE TESTS ARE DONE USING THE AG1121.JPG FILE PROVIDED 
    THE MESUREMENTS ARE IN SECONDS
    25%
     CONSEQUENTIAL   21.22 , 21.94 , 21.59
     PARALLEL        14.91 , 14.10 , 14.15

    50%
    CONSEQUENTIAL 73.64 , 78.82 , 76.53 
    PARALLEL      50.02 , 48.44 , 48.31

    75% 
     C  165.47  
     P  107.02

 */

namespace ImageDownsizing
{
    public partial class Form1 : Form
    {
        string selectedFilePath;
        string outputImagePath= "C:\\Users\\janku\\Desktop\\output.jpg";
        
        Bitmap inputImage;
        Bitmap outputImage;

        int downsizeFactor , newWidth, newHeight , bytesPerPixel;

        Rectangle rect;

        BitmapData inputData;

        BitmapData outputData;

        public unsafe byte* inputPtr;
        public unsafe byte* outputPtr;

        List<Thread> threads = new List<Thread>(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialogBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Open File";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;"; 
            openFileDialog.Multiselect = false; 

            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                selectedFilePath = openFileDialog.FileName;

                selectedFilePathL.Text = Path.GetFileName(selectedFilePath);

                finishedL.Text = "";
                timeElapsedL.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void downsizeBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if(int.TryParse(downsizingTF.Text,out downsizeFactor)) {
                if (consequentialRB.Checked) {
                    
                    consequentialDownsizing();
                }
                else if(parallelRB.Checked)
                {
                    parallelDownsizing();
                }
            }
            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            timeElapsedL.Text = elapsed.TotalSeconds.ToString("F2");
            finishedL.Text = "Finished";


        }

        private void parallelDownsizing()
        {
            setParams();

            const int batchSize = 100; // Number of rows to process in each batch
            List<Thread> threads = new List<Thread>();

            for (int startRow = 0; startRow < newHeight; startRow += batchSize)
            {
                int endRow = Math.Min(startRow + batchSize, newHeight);
                Thread t = new Thread(() => Worker(startRow, endRow));
                t.Start();
                t.Join();
                threads.Add(t);
            }

            SaveImage();

        }

        private void Worker(int startRow, int endRow)
        {
            unsafe
            {
                byte* inputPtr = (byte*)inputData.Scan0;
                byte* outputPtr = (byte*)outputData.Scan0;
                int inputStride = inputData.Stride;
                int outputStride = outputData.Stride;

                for (int y = startRow; y < endRow; y++)
                {
                    int originalY = (int)Math.Round(y * (double)inputImage.Height / newHeight);
                    int inputOffset = originalY * inputStride;
                    int outputOffset = y * outputStride;

                    for (int x = 0; x < newWidth; x++)
                    {
                        int originalX = (int)Math.Round(x * (double)inputImage.Width / newWidth);
                        int inputPixelOffset = inputOffset + originalX * bytesPerPixel;
                        int outputPixelOffset = outputOffset + x * bytesPerPixel;

                        for (int i = 0; i < bytesPerPixel; i++)
                        {
                            outputPtr[outputPixelOffset + i] = inputPtr[inputPixelOffset + i];
                        }
                    }
                }
            }
        }


        private void consequentialDownsizing()
        {

            setParams();
            unsafe
            {
                inputPtr = (byte*)inputData.Scan0;
                outputPtr = (byte*)outputData.Scan0;
               
                for (int y = 0; y < newHeight; y++)
                {
                    for (int x = 0; x < newWidth; x++)
                    {

                        int originalX = (int)Math.Round(x * (double)inputImage.Width / newWidth);
                        int originalY = (int)Math.Round(y * (double)inputImage.Height / newHeight);

 
                        for (int i = 0; i < bytesPerPixel; i++)
                        {
                            outputPtr[i] = inputPtr
                                [(originalY * inputData.Stride) + (originalX * bytesPerPixel) + i];
                        }

                        outputPtr += bytesPerPixel;
                    }

                    outputPtr += outputData.Stride - (newWidth * bytesPerPixel);
                }
                SaveImage();
            }


        }
        private void setParams()
        {
            inputImage = new Bitmap(selectedFilePath);

            newWidth = (int)(inputImage.Width * downsizeFactor / 100);
            newHeight = (int)(inputImage.Height * downsizeFactor / 100);

            outputImage = new Bitmap(newWidth, newHeight);

            rect = new Rectangle(0, 0, inputImage.Width, inputImage.Height);

            inputData = inputImage.LockBits
                    (rect, ImageLockMode.ReadOnly, inputImage.PixelFormat);

            outputData = outputImage.LockBits(
                new Rectangle(0, 0, newWidth, newHeight), ImageLockMode.WriteOnly, inputImage.PixelFormat);

            bytesPerPixel = System.Drawing.Image.GetPixelFormatSize(inputImage.PixelFormat) / 8;
        }
        private void SaveImage()
        {
            inputImage.UnlockBits(inputData);
            outputImage.UnlockBits(outputData);

            outputImage.Save(outputImagePath);
        }
    }
}
