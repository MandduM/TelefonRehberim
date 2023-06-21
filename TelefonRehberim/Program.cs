using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TelefonRehberim
{
    class Program
    {
        static void Main(string[] args)
        {
                Rehber rehber = new Rehber();
                rehber.DefaultKisileriEkle();

                bool cikis = false;
                while (!cikis)
                {
                    Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("(1) Yeni Numara Kaydetmek");
                    Console.WriteLine("(2) Varolan Numarayı Silmek");
                    Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                    Console.WriteLine("(4) Rehberi Listelemek");
                    Console.WriteLine("(5) Rehberde Arama Yapmak");
                    Console.WriteLine("*******************************************");

                    int secim;
                    if (int.TryParse(Console.ReadLine(), out secim))
                    {
                        switch (secim)
                        {
                            case 1:
                                rehber.YeniNumaraKaydet();
                                break;
                            case 2:
                                rehber.NumaraSil();
                                break;
                            case 3:
                                rehber.NumaraGuncelle();
                                break;
                            case 4:
                                rehber.RehberiListele();
                                break;
                            case 5:
                                rehber.RehberdeAramaYap();
                                break;
                            default:
                                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    }

                    Console.WriteLine("Devam etmek için herhangi bir tuşa basın, çıkmak için 'q' tuşuna basın.");
                    if (Console.ReadLine() == "q")
                    {
                        cikis = true;
                    }

                    Console.Clear();
                }
            }
        }

        class Rehber
        {
            private List<Kisi> kisiler;

            public Rehber()
            {
                kisiler = new List<Kisi>();
            }

            public void DefaultKisileriEkle()
            {
                kisiler.Add(new Kisi("Ali", "Kaan", "1234567890"));
                kisiler.Add(new Kisi("Mahmut", "Tuncer", "9876543210"));
            }

            public void YeniNumaraKaydet()
            {
                Console.WriteLine("Lütfen isim giriniz:");
                string ad = Console.ReadLine();

                Console.WriteLine("Lütfen soyisim giriniz:");
                string soyad = Console.ReadLine();

                Console.WriteLine("Lütfen telefon numarası giriniz:");
                string telefon = Console.ReadLine();

                Kisi kisi = new Kisi(ad, soyad, telefon);
                kisiler.Add(kisi);

                Console.WriteLine("Yeni numara başarıyla kaydedildi.");
            }

            public void NumaraSil()
            {
                Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                string kelime = Console.ReadLine();

                var bulunanKisiler = kisiler.Where(kisi => kisi.Ad.Contains(kelime) || kisi.Soyad.Contains(kelime)).ToList();

                if (bulunanKisiler.Count == 0)
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için      : (2)");

                    int secim;
                    if (int.TryParse(Console.ReadLine(), out secim))
                    {
                        switch (secim)
                        {
                            case 1:
                                break;
                            case 2:
                                NumaraSil();
                                break;
                            default:
                                Console.WriteLine("Geçersiz seçim. Silme işlemi sonlandırıldı.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim. Silme işlemi sonlandırıldı.");
                    }
                }
                else
                {
                    Kisi silinecekKisi = bulunanKisiler.First();

                    Console.WriteLine($"{silinecekKisi.Ad} {silinecekKisi.Soyad} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");
                    string onay = Console.ReadLine();

                    if (onay.ToLower() == "y")
                    {
                        kisiler.Remove(silinecekKisi);
                        Console.WriteLine("Kişi rehberden silindi.");
                    }
                    else
                    {
                        Console.WriteLine("Silme işlemi iptal edildi.");
                    }
                }
            }

            public void NumaraGuncelle()
            {
                Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                string kelime = Console.ReadLine();

                var bulunanKisiler = kisiler.Where(kisi => kisi.Ad.Contains(kelime) || kisi.Soyad.Contains(kelime)).ToList();

                if (bulunanKisiler.Count == 0)
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
                    Console.WriteLine("* Yeniden denemek için              : (2)");

                    int secim;
                    if (int.TryParse(Console.ReadLine(), out secim))
                    {
                        switch (secim)
                        {
                            case 1:
                                break;
                            case 2:
                                NumaraGuncelle();
                                break;
                            default:
                                Console.WriteLine("Geçersiz seçim. Güncelleme işlemi sonlandırıldı.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim. Güncelleme işlemi sonlandırıldı.");
                    }
                }
                else
                {
                    Kisi guncellenecekKisi = bulunanKisiler.First();

                    Console.WriteLine($"{guncellenecekKisi.Ad} {guncellenecekKisi.Soyad} isimli kişinin yeni telefon numarasını giriniz:");
                    string yeniTelefon = Console.ReadLine();

                    guncellenecekKisi.Telefon = yeniTelefon;

                    Console.WriteLine("Kişinin telefon numarası güncellendi.");
                }
            }

            public void RehberiListele()
            {
                Console.WriteLine("Telefon Rehberi");
                Console.WriteLine("**********************************************");

                foreach (var kisi in kisiler.OrderBy(k => k.Ad))
                {
                    Console.WriteLine($"İsim: {kisi.Ad} \nSoyisim: {kisi.Soyad} \nTelefon Numarası: {kisi.Telefon}\n");
                }

                Console.WriteLine();
            }

            public void RehberdeAramaYap()
            {
                Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                Console.WriteLine("**********************************************");
                Console.WriteLine("İsim veya soyisime göre arama yapmak için : (1)");
                Console.WriteLine("Telefon numarasına göre arama yapmak için : (2)");

                int secim;
                if (int.TryParse(Console.ReadLine(), out secim))
                {
                    switch (secim)
                    {
                        case 1:
                            Console.WriteLine("Aramak istediğiniz isim veya soyisimi giriniz:");
                            string kelime = Console.ReadLine();

                            var bulunanKisiler = kisiler.Where(kisi => kisi.Ad.Contains(kelime) || kisi.Soyad.Contains(kelime)).ToList();

                            if (bulunanKisiler.Count == 0)
                            {
                                Console.WriteLine("Aranan kriterlere uygun veri bulunamadı.");
                            }
                            else
                            {
                                Console.WriteLine("Arama Sonuçlarınız:");
                                Console.WriteLine("**********************************************");

                                foreach (var kisi in bulunanKisiler)
                                {
                                    Console.WriteLine($"isim: {kisi.Ad} Soyisim: {kisi.Soyad} Telefon Numarası: {kisi.Telefon}");
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Aramak istediğiniz telefon numarasını giriniz:");
                            string telefon = Console.ReadLine();

                            var bulunanKisi = kisiler.FirstOrDefault(kisi => kisi.Telefon == telefon);

                            if (bulunanKisi == null)
                            {
                                Console.WriteLine("Aranan kriterlere uygun veri bulunamadı.");
                            }
                            else
                            {
                                Console.WriteLine("Arama Sonuçlarınız:");
                                Console.WriteLine("**********************************************");
                                Console.WriteLine($"isim: {bulunanKisi.Ad} Soyisim: {bulunanKisi.Soyad} Telefon Numarası: {bulunanKisi.Telefon}");
                            }
                            break;
                        default:
                            Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                }
            }
        }

        class Kisi
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public string Telefon { get; set; }

            public Kisi(string ad, string soyad, string telefon)
            {
                Ad = ad;
                Soyad = soyad;
                Telefon = telefon;
            }
        }

    }

