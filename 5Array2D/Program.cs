using System;

namespace _5Array2D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }
            int hasil = -9 * 7;
            int hitungRow = arr.Length;
            int hitungCol = arr[0].Length;

            for (int i = 0; i < hitungCol -2; i++)
            {
                for (int j = 0; j < hitungRow - 2; j++)
                {
                    int jumlahRowPertama = arr[j][i] + arr[j][i + 1] + arr[j][i + 2];
                    int jumlahRowKedua = arr[j + 1][i + 1];
                    int jumlahRowKetiga = arr[j + 2][i] + arr[j + 2][i + 1] + arr[j + 2][i + 2];
                    int total = jumlahRowPertama + jumlahRowKedua + jumlahRowKetiga;

                    hasil = Math.Max(hasil, total);
                }
            }
            Console.WriteLine(hasil);
        }
    }
}
