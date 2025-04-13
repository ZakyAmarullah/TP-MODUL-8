using System;
using tpmodul8_103022300045;

class Program
{
    static void Main(string[] args)
    {
        string configPath = "covid_config.json";
        CovidConfig config = CovidConfig.LoadFromFile(configPath);

        Console.Write("Berapa suhu badan anda saat ini? Dalam nilai " + config.satuan_suhu + ": ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        double batasSuhu = config.satuan_suhu == "celcius" ? 36.5 : 37.5;
        int batasHari = int.Parse(config.batas_hari_demam);

        if (suhu < batasSuhu && hariDemam >= batasHari)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        // Ubah satuan suhu jika diperlukan
        Console.Write("Apakah Anda ingin mengubah satuan suhu? (y/n): ");
        string input = Console.ReadLine();
        if (input.ToLower() == "y")
        {
            config.UbahSatuan();
            Console.WriteLine("Satuan suhu berhasil diubah menjadi: " + config.satuan_suhu);
        }
    }
}
