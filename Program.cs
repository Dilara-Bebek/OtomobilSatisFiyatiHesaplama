using System.ComponentModel.Design;

namespace oto_satis_fiyat_hesaplama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___________________________________TÜRKİYE OTOMOBİL SATIŞ FİYATI HESAPLAMA OTOMASYONU___________________________________\n");
           

            Console.Write( "Lütfen aracınızın vergisiz satış tutarını giriniz : " );
            String vergisizTutar0 = Console.ReadLine();
            decimal vergisizTutar = decimal.Parse(vergisizTutar0); // kullancıdan aldığım veriler string old. için Parse ile int e çevirdim.

            Console.Write( "Lütfen aracınızın motor  tipi içten yanmalı ise '1' , elektrikli ise '2' yazınız : ");
            String motorTipi0 = Console.ReadLine();
            int motorTipi = int.Parse(motorTipi0);

            Console.Write("Lütfen aracınızın silindir hacmini giriniz : ");
            String silindirHacmi0 = Console.ReadLine();
            double silindirHacmi = double.Parse(silindirHacmi0);

            // decimal kullandım.Çünkü ondalıklı kısım çok hassas ve bir fiyat hesaplayacağımız için sayıların her basamağı önemli

            decimal kdvOrani = 0.18m; // kdv oranı sabit
            decimal otvOrani = 0;     // otv orani degisken

            if(motorTipi == 1)  // içten yanmalı motor
            {
                if(silindirHacmi <= 1600)
                {
                    if (vergisizTutar <= 184000)
                    {
                        otvOrani = 0.45m;
                    }
                    else if (vergisizTutar < 220000)
                    {
                        otvOrani = 0.5m;
                    }
                    else if (vergisizTutar < 250000)
                    {
                        otvOrani = 0.6m;
                    }
                    else if (vergisizTutar < 280000)
                    {
                        otvOrani = 0.7m;
                    }
                    else if (vergisizTutar>=280000)
                    {
                        otvOrani = 0.8m;
                    }
                }

                else if (silindirHacmi < 2000)
                {
                    if (vergisizTutar < 170000)
                    {
                        otvOrani = 1.3m;
                    }
                    else if (vergisizTutar >= 170000)
                    {
                        otvOrani = 1.5m;
                    }



                }
                else
                {
                    otvOrani = 2.2m;
                }
            }

            else if (motorTipi==2) // elektrikli arac
            {
                if(silindirHacmi < 160)
                {
                    if (vergisizTutar < 700000)
                    {
                        otvOrani = 0.1m;
                    }
                    else if (vergisizTutar >= 700000)
                    {
                        otvOrani = 0.4m;
                    }
                }
                else
                {
                    if (vergisizTutar < 750000)
                    {
                        otvOrani = 0.5m;
                    }
                    else otvOrani = 0.6m;
                }

            }

            // ÖTV li fiyat
            decimal otvTutari = vergisizTutar * otvOrani;
            decimal otvliFiyati = vergisizTutar + otvTutari;

            // kdv dahil fiyat
            decimal kdvTutari = otvliFiyati * kdvOrani;
            decimal satisFiyati = otvliFiyati + kdvTutari;

            Console.WriteLine( "ÖTV TUTARI : " + otvTutari + "TL");
            Console.WriteLine("KDV TUTARI : " + kdvTutari + "TL");
            Console.WriteLine("OTOMOBİLİN SATIŞ FİYATI : " + satisFiyati + "TL");

            Console.WriteLine( "\n\"İYİ GÜNLER DİLERİZ.\" ");
        }
    }
}
