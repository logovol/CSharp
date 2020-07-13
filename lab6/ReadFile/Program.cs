using System;
using System.IO;
using System.Diagnostics;

// Лях Павел
// ** Считайте файл различными способами.Смотрите “Пример записи файла различными способами”.
// Создайте методы, которые возвращают массив byte (FileStream, BufferedStream),
// строку для StreamReader и массив int для BinaryReader.

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            long kbyte = 1024;
            long mbyte = 1024 * kbyte;
            long gbyte = 1024 * mbyte;
            long size = mbyte;
            //Write FileStream
            //Write BinaryStream
            //Write StreamReader/StreamWriter
            //Write BufferedStream

            Console.WriteLine("FileStream. Milliseconds:{0}", FileStreamSample("bigdata0.bin", size));
            Console.WriteLine("BinaryStream. Milliseconds:{0}", BinaryStreamSample("bigdata1.bin", size));
            Console.WriteLine("StreamWriter. Milliseconds:{0}", StreamWriterSample("bigdata2.bin", size));
            Console.WriteLine("BufferedStream. Milliseconds:{0}", BufferedStreamSample("bigdata3.bin", size));

            // 1.
            byte[] byteArr = BufferedStreamRead("bigdata3.bin");
            // 2.
            string str = StreamReader("bigdata2.bin");
            // 3.
            int[] intArr = BinaryStreamReader("bigdata1.bin");

            Console.ReadKey();
        }

        static long FileStreamSample(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            //FileStream fs = new FileStream("D:\\temp\\bigdata.bin", FileMode.CreateNew, FileAccess.Write);
            for (int i = 0; i < size; i++)
                fs.WriteByte(0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static long BinaryStreamSample(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < size; i++)
                bw.Write((byte)0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static int[] BinaryStreamReader(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            int size = (int)fs.Length / 4;

            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = br.ReadInt32();
            }   
            
            return arr;
        }

        static long StreamWriterSample(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < size; i++)
                sw.Write(0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static string StreamReader(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);           
            StreamReader sr = new StreamReader(fs);
            
            return sr.ReadToEnd();
        }

        static long BufferedStreamSample(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            int countPart = 4;//количество частей
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
                        
            BufferedStream bs = new BufferedStream(fs, bufsize);
            //bs.Write(buffer, 0, (int)size);//Error!
            for (int i = 0; i < countPart; i++)
                bs.Write(buffer, 0, (int)bufsize);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static byte[] BufferedStreamRead(string filename)
        {   
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int countPart = 4;//количество частей
            int bufsize = (int)(fs.Length / countPart);
            BufferedStream bs = new BufferedStream(fs, bufsize);

            byte[] buffer = new byte[bufsize];
            byte[] byteArr = new byte[fs.Length];
            for (int i = 0; i < countPart; i++)
            {
                bs.Read(byteArr, 0, bufsize);
            }
                        
            fs.Close();
            bs.Close();

            return byteArr;
        }

    }
}

   