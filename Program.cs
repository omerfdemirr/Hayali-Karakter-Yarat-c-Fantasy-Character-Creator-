using System;
using System.Collections.Generic;
using System.IO;

namespace HayaliKarakterYaratici
{
    class Program
    {
        static Random random = new Random();
        static List<Karakter> karakterler = new List<Karakter>();

        static void Main(string[] args)
        {
            Console.WriteLine("[*] Fantastik Karakter Yaratıcıya Hoş Geldiniz!");
            Console.WriteLine("------------------------------------------------");

            while (true)
            {
                Console.WriteLine("\nSeçenekler:");
                Console.WriteLine("1. Yeni Karakter Yarat");
                Console.WriteLine("2. Varolan Karakterleri Listele");
                Console.WriteLine("3. Karakter Kaydet");
                Console.WriteLine("4. Karakteri Yükle");
                Console.WriteLine("5. Çıkış");
                Console.Write("Lütfen bir seçenek seçin (1/2/3/4/5): ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        KarakterYarat();
                        break;
                    case "2":
                        KarakterListele();
                        break;
                    case "3":
                        KarakterKaydet();
                        break;
                    case "4":
                        KarakterYukle();
                        break;
                    case "5":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        static void KarakterYarat()
        {
            string[] siniflar = { "Savaşçı", "Büyücü", "Okçu", "Hırsız", "Şifacı" };
            string[] ozellikler = { "Cesur", "Zeki", "Hızlı", "Dayanıklı", "Kurnaz" };
            string[] yetenekler = { "Ateş Topu", "Kılıç Darbesi", "Gizlilik", "Hızlı İyileşme", "Keskin Nişancılık" };
            string[] hikayeBaslangiclari =
            {
                "Bir ormanda büyüdü ve doğayla iç içe yaşadı.",
                "Kraliyet sarayında eğitim aldı, ancak sürgün edildi.",
                "Küçük bir köyde doğdu, ancak büyük hayalleri vardı.",
                "Bir mağarada, gizemli bir büyücü tarafından büyütüldü.",
                "Yıllarca bir lejyoner olarak savaştı ve hayatta kaldı."
            };

            // Fiziksel özellikler
            int yas = RandomSayilariGetir(18, 100);
            double boy = RandomSayilariGetir(1.50, 2.20);
            double kilo = RandomSayilariGetir(40, 150);

            // Kullanıcıdan Karakter Sınıfı Seçmesini İstiyoruz
            Console.WriteLine("Sınıf Seçiniz:");
            for (int i = 0; i < siniflar.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {siniflar[i]}");
            }
            Console.Write("Bir sınıf numarası seçin (1-5): ");
            int secilenSinif = Convert.ToInt32(Console.ReadLine()) - 1;

            // Kullanıcıdan Özellik Seçmesi
            Console.WriteLine("\nÖzellik Seçiniz:");
            for (int i = 0; i < ozellikler.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {ozellikler[i]}");
            }
            Console.Write("Bir özellik numarası seçin (1-5): ");
            int secilenOzellik = Convert.ToInt32(Console.ReadLine()) - 1;

            // Kullanıcıdan Yetenek Seçmesi
            Console.WriteLine("\nYetenek Seçiniz:");
            for (int i = 0; i < yetenekler.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {yetenekler[i]}");
            }
            Console.Write("Bir yetenek numarası seçin (1-5): ");
            int secilenYetenek = Convert.ToInt32(Console.ReadLine()) - 1;

            // Hikaye Başlangıcını Seçme
            Console.WriteLine("\nHikaye Başlangıcı Seçiniz:");
            for (int i = 0; i < hikayeBaslangiclari.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {hikayeBaslangiclari[i]}");
            }
            Console.Write("Bir hikaye başlangıcı numarası seçin (1-5): ");
            int secilenHikaye = Convert.ToInt32(Console.ReadLine()) - 1;

            // Yeni Karakter Oluşturuluyor
            Karakter yeniKarakter = new Karakter
            {
                Sinif = siniflar[secilenSinif],
                Ozellik = ozellikler[secilenOzellik],
                Yetenek = yetenekler[secilenYetenek],
                Hikaye = hikayeBaslangiclari[secilenHikaye],
                Yas = yas,
                Boy = boy,
                Kilo = kilo
            };

            karakterler.Add(yeniKarakter);
            Console.WriteLine("\n[+] Yeni karakter başarıyla oluşturuldu!");
            Console.WriteLine($"- Sınıf: {yeniKarakter.Sinif}");
            Console.WriteLine($"- Özellik: {yeniKarakter.Ozellik}");
            Console.WriteLine($"- Yetenek: {yeniKarakter.Yetenek}");
            Console.WriteLine($"- Hikaye: {yeniKarakter.Hikaye}");
            Console.WriteLine($"- Yaş: {yeniKarakter.Yas}");
            Console.WriteLine($"- Boy: {yeniKarakter.Boy}m");
            Console.WriteLine($"- Kilo: {yeniKarakter.Kilo}kg");
        }

        static void KarakterListele()
        {
            if (karakterler.Count == 0)
            {
                Console.WriteLine("\n[!] Henüz hiçbir karakter oluşturulmadı.");
                return;
            }

            Console.WriteLine("\n[+] Oluşturulan Karakterler:");
            foreach (var karakter in karakterler)
            {
                Console.WriteLine($"ID: {karakter.Id} | Sınıf: {karakter.Sinif}, Özellik: {karakter.Ozellik}, Yetenek: {karakter.Yetenek}, Hikaye: {karakter.Hikaye}, Yaş: {karakter.Yas}, Boy: {karakter.Boy}m, Kilo: {karakter.Kilo}kg");
            }
        }

        static void KarakterKaydet()
        {
            string dosyaYolu = "karakterler.txt";
            using (StreamWriter writer = new StreamWriter(dosyaYolu))
            {
                foreach (var karakter in karakterler)
                {
                    writer.WriteLine($"{karakter.Id},{karakter.Sinif},{karakter.Ozellik},{karakter.Yetenek},{karakter.Hikaye},{karakter.Yas},{karakter.Boy},{karakter.Kilo}");
                }
            }
            Console.WriteLine("\n[+] Karakterler başarıyla kaydedildi!");
        }

        static void KarakterYukle()
        {
            string dosyaYolu = "karakterler.txt";
            if (File.Exists(dosyaYolu))
            {
                karakterler.Clear();
                foreach (var line in File.ReadLines(dosyaYolu))
                {
                    string[] parts = line.Split(',');
                    Karakter karakter = new Karakter
                    {
                        Id = Convert.ToInt32(parts[0]),
                        Sinif = parts[1],
                        Ozellik = parts[2],
                        Yetenek = parts[3],
                        Hikaye = parts[4],
                        Yas = Convert.ToInt32(parts[5]),
                        Boy = Convert.ToDouble(parts[6]),
                        Kilo = Convert.ToDouble(parts[7])
                    };
                    karakterler.Add(karakter);
                }
                Console.WriteLine("\n[+] Karakterler başarıyla yüklendi!");
            }
            else
            {
                Console.WriteLine("\n[!] Kaydedilmiş karakter bulunamadı.");
            }
        }

        // Rastgele sayı aralığı
        static T RandomSayilariGetir<T>(T min, T max)
        {
            dynamic minimum = min;
            dynamic maximum = max;
            return (T)(minimum + random.NextDouble() * (maximum - minimum));
        }
    }

    class Karakter
    {
        public int Id { get; set; } = new Random().Next(1000, 9999); // Her karakter için benzersiz ID
        public string Sinif { get; set; }
        public string Ozellik { get; set; }
        public string Yetenek { get; set; }
        public string Hikaye { get; set; }
        public int Yas { get; set; }
        public double Boy { get; set; }
        public double Kilo { get; set; }
    }
}
