namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            FileStream fileStreamReader = new FileStream(inputFilePath, FileMode.Open);
            FileStream fileStreamWriter = new FileStream(outputFilePath, FileMode.Create);

            byte[] bytes = new byte[256];
            while (true)
            {
                int currentBytes = fileStreamReader.Read(bytes, 0, bytes.Length);

                if (currentBytes == 0)
                {
                    break;
                }

                fileStreamWriter.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
