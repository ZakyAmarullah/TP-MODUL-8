using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300045
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public string batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public static CovidConfig LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new CovidConfig
                {
                    satuan_suhu = "celcius",
                    batas_hari_demam = "14",
                    pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                    pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
                };
            }

            string json = File.ReadAllText(filePath);
            var configRaw = JsonSerializer.Deserialize<CovidConfig>(json);

            // Ganti nilai CONFIG1–CONFIG4 jika belum diganti
            return new CovidConfig
            {
                satuan_suhu = configRaw.satuan_suhu == "CONFIG1" ? "celcius" : configRaw.satuan_suhu,
                batas_hari_demam = configRaw.batas_hari_demam == "CONFIG2" ? "14" : configRaw.batas_hari_demam,
                pesan_ditolak = configRaw.pesan_ditolak == "CONFIG3" ? "Anda tidak diperbolehkan masuk ke dalam gedung ini" : configRaw.pesan_ditolak,
                pesan_diterima = configRaw.pesan_diterima == "CONFIG4" ? "Anda dipersilahkan untuk masuk ke dalam gedung ini" : configRaw.pesan_diterima
            };
        }

        public void UbahSatuan()
        {
            satuan_suhu = satuan_suhu.ToLower() == "celcius" ? "fahrenheit" : "celcius";
        }
    }
}
