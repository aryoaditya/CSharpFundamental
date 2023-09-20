//NAMA       : ARYO ADITYA
//NO. REGIST : 1957065840-207

using System;

namespace PenilaianSiswa
{
    public class Program
    {
        public static void Main()
        {
            //Nilai siswa
            float[] nilaiSiswa1 = { 70, 80, 90, 65, 85, 80, 40 };
            float[] nilaiSiswa2 = { 75, 85, 85, 80, 50, 90, 100 };
            float[] nilaiSiswa3 = { 90, 95, 100, 85, 100, 80, 87 };

            //Kumpulan nilai siswa (Array multidimensi)
            float[][] kumpulanNilai = { nilaiSiswa1, nilaiSiswa2, nilaiSiswa3 };

            //Print penilaian
            for (int i = 0; i < kumpulanNilai.Length; i++)
            {
                float nilaiRataan = HitungRataan(kumpulanNilai[i]);
                string mutu = GenerateMutu(nilaiRataan);
                string textNilai = TeksNilai(mutu);
                Console.WriteLine("Nilai rata-rata siswa " + (i + 1) + " adalah " + nilaiRataan + ", nilai mutu " + mutu + ", nilai " + textNilai);
            }
        }

        //Fungsi looping hitung rataan nilai
        static float HitungRataan(float[] nilai)
        {
            float total = 0;

            for (int i = 0; i < nilai.Length; i++)
            {
                total += nilai[i];
            }

            return total / nilai.Length;
        }

        //Fungsi decision if-else untuk nilai mutu
        static string GenerateMutu(float nilaiRataan)
        {
            if (nilaiRataan >= 85)
            {
                return "A";
            }
            else if (nilaiRataan >= 75)
            {
                return "B";
            }
            else
            {
                return "C";
            }
        }

        //Fungsi if-else untuk dengan Logical Operator 'atau'
        static string TeksNilai(string nilaiMutu)
        {
            if (nilaiMutu == "A" || nilaiMutu == "B")
            {
                return "Baik";
            }
            else
            {
                return "Kurang Baik";
            }
        }
    }
}