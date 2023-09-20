using System;

public class Siswa
{
    protected string nama;
    protected string kelas;
    protected string nisn;
    protected string jenisKelamin;

    // Constructor siswa
    public Siswa(string nama, string kelas, string nisn, string jenisKelamin)
    {
        this.nama = nama;
        this.kelas = kelas;
        this.nisn = nisn;
        this.jenisKelamin = jenisKelamin;
    }

    public string GetNama()
    {
        return nama;
    }

    public string GetKelas()
    {
        return kelas;
    }

    public string GetNISN()
    {
        return nisn;
    }

    public string GetJenisKelamin()
    {
        return jenisKelamin;
    }

    // Menghitung nilai rataan siswa
    public static float RataanNilai(float nilai1, float nilai2, float nilai3)
    {
        return (nilai1 + nilai2 + nilai3) / 3;
    }

    // Menentukan kelulusan siswa
    public static string Kelulusan(float rataanNilai)
    {
        if (rataanNilai >= 75)
            return "Lulus";
        else
            return "Tidak Lulus";
    }

    // Print data siswa
    public virtual void DataSiswa()
    {
        Console.WriteLine("Nama : " + nama);
        Console.WriteLine("Kelas : " + kelas);
        Console.WriteLine("NISN : " + nisn);
        Console.WriteLine("Jenis Kelamin : " + jenisKelamin + "\n");
    }
}

public class SiswaIPA : Siswa
{
    private float NilaiBiologi { get; set; }
    private float NilaiKimia { get; set; }
    private float NilaiFisika { get; set; }

    // Constructor siswa IPA
    public SiswaIPA(string? nama, string? kelas, string? nisn, string? jenisKelamin) : base(nama, kelas, nisn, jenisKelamin)
    {
        NilaiBiologi = 0;
        NilaiKimia = 0;
        NilaiFisika = 0;
    }

    // Getter dan setter untuk nilai Biologi
    public float GetBiologi()
    {
        return NilaiBiologi;
    }

    public void SetBiologi(float nilai)
    {
        NilaiBiologi = nilai;
    }

    // Getter dan setter untuk nilai Fisika
    public float GetFisika()
    {
        return NilaiFisika;
    }

    public void SetFisika(float nilai)
    {
        NilaiFisika = nilai;
    }

    public float GetKimia()
    {
        return NilaiKimia;
    }

    public void SetKimia(float nilai)
    {
        NilaiKimia = nilai;
    }

    // Print data siswa IPA
    public override void DataSiswa()
    {
        base.DataSiswa();
        Console.WriteLine($"Nilai Biologi : {NilaiBiologi}");
        Console.WriteLine($"Nilai Fisika : {NilaiFisika}");
        Console.WriteLine($"Nilai Kimia : {NilaiKimia}");
    }

    public void KelulusanSiswaIPA()
    {
        base.DataSiswa();
        Console.WriteLine($"Nilai Rata-rata : {RataanNilai(NilaiBiologi, NilaiKimia, NilaiFisika)}");
        Console.WriteLine($"Hasil Kelulusan : {Kelulusan(RataanNilai(NilaiBiologi, NilaiKimia, NilaiFisika))}\n");
    }
}

public class SiswaIPS : Siswa
{
    private float NilaiGeografi { get; set; }
    private float NilaiSosiologi { get; set; }
    private float NilaiEkonomi { get; set; }

    //Constructor siswa IPS
    public SiswaIPS(string nama, string kelas, string nisn, string jenisKelamin) : base(nama, kelas, nisn, jenisKelamin)
    {
        NilaiGeografi = 0;
        NilaiSosiologi = 0;
        NilaiEkonomi = 0;
    }

    // Getter dan setter untuk nilai Geografi
    public float GetGeografi()
    {
        return NilaiGeografi;
    }

    public void SetGeografi(float nilai)
    {
        NilaiGeografi = nilai;
    }

    // Getter dan setter untuk nilai Ekonomi
    public float GetEkonomi()
    {
        return NilaiEkonomi;
    }

    public void SetEkonomi(float nilai)
    {
        NilaiEkonomi = nilai;
    }

    // Getter dan setter untuk nilai Sosiologi
    public float GetSosiologi()
    {
        return NilaiSosiologi;
    }

    public void SetSosiologi(float nilai)
    {
        NilaiSosiologi = nilai;
    }

    // Print data siswa IPS
    public override void DataSiswa()
    {
        base.DataSiswa();
        Console.WriteLine($"Nilai Sosiologi : {NilaiSosiologi}");
        Console.WriteLine($"Nilai Geografi : {NilaiGeografi}");
        Console.WriteLine($"Nilai Ekonomi : {NilaiEkonomi}");
    }

    public void KelulusanSiswaIPS()
    {
        base.DataSiswa();
        Console.WriteLine($"Nilai Rata-rata : {RataanNilai(NilaiSosiologi, NilaiGeografi, NilaiEkonomi)}");
        Console.WriteLine($"Hasil Kelulusan : {Kelulusan(RataanNilai(NilaiSosiologi, NilaiGeografi, NilaiEkonomi))}\n");
    }
}

public class Program
{
    public static void Main()
    {
        List<SiswaIPA> daftarSiswaIPA = new();
        List<SiswaIPS> daftarSiswaIPS = new();

        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~ SELAMAT DATANG ~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        int opsi;
        //Tampilan menu
        do
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Input data");
            Console.WriteLine("2. Lihat nilai siswa");
            Console.WriteLine("3. Cek kelulusan");
            Console.WriteLine("4. Keluar");
            Console.Write("Silahkan pilih opsi (1-4): ");

            opsi = int.Parse(Console.ReadLine());
            if(opsi == 1 || opsi ==2 || opsi == 3 || opsi == 4)
                switch (opsi)
                {
                    case 1:
                        Console.WriteLine("\nAnda memilih: Input data");
                        // Fungsi untuk input data
                        //Nama
                        Console.Write("Nama: ");
                        var nama = Console.ReadLine();

                        //Kelas
                        Console.Write("Kelas: ");
                        var kelas = Console.ReadLine();

                        //NISN
                        Console.Write("NISN: ");
                        var nisn = Console.ReadLine();

                        //Jenis Kelamin
                        Console.Write("Jenis Kelamin: ");
                        var jenisKelamin = Console.ReadLine();

                        //Jurusan
                        Console.Write("Jurusan (IPA/IPS): ");
                        var jurusan = Console.ReadLine();

                        //input nilai khusus jurusan
                        if(jurusan == "IPA")
                        {
                            SiswaIPA siswa = new(nama, kelas, nisn, jenisKelamin);

                            Console.Write("Nilai Biologi: ");
                            float nilaiBiologi = float.Parse(Console.ReadLine());
                            siswa.SetBiologi(nilaiBiologi);

                            Console.Write("Nilai Fisika: ");
                            float nilaiFisika = float.Parse(Console.ReadLine());
                            siswa.SetFisika(nilaiFisika);

                            Console.Write("Nilai Kimia: ");
                            float nilaiKimia = float.Parse(Console.ReadLine());
                            siswa.SetKimia(nilaiKimia);

                            daftarSiswaIPA.Add(siswa);
                        }
                        else if(jurusan == "IPS")
                        {
                            SiswaIPS siswa = new(nama, kelas, nisn, jenisKelamin);

                            Console.Write("Nilai Sosiologi: ");
                            float nilaiSosiologi = float.Parse(Console.ReadLine());
                            siswa.SetSosiologi(nilaiSosiologi);

                            Console.Write("Nilai Geografi: ");
                            float nilaiGeografi = float.Parse(Console.ReadLine());
                            siswa.SetGeografi(nilaiGeografi);

                            Console.Write("Nilai Ekonomi: ");
                            float nilaiEkonomi = float.Parse(Console.ReadLine());
                            siswa.SetEkonomi(nilaiEkonomi);

                            daftarSiswaIPS.Add(siswa);
                        }
                        else
                            Console.Write("Masukan tidak valid.");
                        break;

                    case 2:
                        Console.WriteLine("\nAnda memilih: Lihat nilai siswa");
                        int index = 1;

                        //Menampilkan nilai siswa
                        if (daftarSiswaIPA.Count > 0 || daftarSiswaIPS.Count > 0)
                        {
                            //Menampilkan nilai siswa IPA
                            foreach (var siswa in daftarSiswaIPA)
                            {
                                Console.WriteLine($"~~~~~~~~~~~~~~ Siswa {index} ~~~~~~~~~~~~~~");
                                siswa.DataSiswa(); // Method print data nilai
                                index++;
                            }

                            //Menampilkan nilai siswa IPS
                            foreach (var siswa in daftarSiswaIPS)
                            {
                                Console.WriteLine($"~~~~~~~~~~~~~~ Siswa {index} ~~~~~~~~~~~~~~");
                                siswa.DataSiswa(); // Method print data nilai
                                index++;
                            }
                        }
                        else
                            Console.WriteLine("Tidak ada data siswa.");
                        break;

                    case 3:
                        Console.WriteLine("\nAnda memilih: Cek kelulusan");

                        int id = 1;
                        //Menampilkan nilai siswa
                        if (daftarSiswaIPA.Count > 0 || daftarSiswaIPS.Count > 0)
                        {
                            //Menampilkan nilai siswa IPA
                            foreach (var siswa in daftarSiswaIPA)
                            {
                                Console.WriteLine($"~~~~~~~~~~~~~~ Siswa {id} ~~~~~~~~~~~~~~");
                                siswa.KelulusanSiswaIPA();
                                id++;
                            }

                            //Menampilkan nilai siswa IPS
                            foreach (var siswa in daftarSiswaIPS)
                            {
                                Console.WriteLine($"~~~~~~~~~~~~~~ Siswa {id} ~~~~~~~~~~~~~~");
                                siswa.KelulusanSiswaIPS();
                                id++;
                            }
                        }
                        else
                            Console.WriteLine("Tidak ada data siswa.");
                        break;

                    case 4:
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("~~~~~~ TERIMA KASIH SUDAH MENGUNJUNGI KAMI, SAMPAI JUMPA KEMBALI ~~~~~~");
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        break;

                    default:
                        Console.WriteLine("Opsi tidak valid. Silakan pilih kembali.");
                        break;
                }
            else
            {
                Console.WriteLine("Masukan tidak valid. Silakan masukkan angka (1-4).");
            }
        } while (opsi != 4);
    }
}