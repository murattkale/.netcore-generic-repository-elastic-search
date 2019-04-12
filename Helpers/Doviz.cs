using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


public static class Doviz
{
    public static double? Get(string type, double? Price)
    {
        var result = new Dictionary<double, double>();
        try
        {
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);

            switch (type)
            {
                case "&#8378;":
                case "₺":
                    {
                        //string USD_Alis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml.Replace('.', ',');
                        string USD_Satis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml.Replace('.', ',');
                        Price = Price * USD_Satis.ToDouble();
                        //result.Add(USD_Alis.ToDouble(), USD_Satis.ToDouble());
                    }
                    break;
                case "€":
                    {
                        //string EURO_Alis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/CrossRateOther").InnerXml.Replace('.', ',');
                        string EURO_Satis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/CrossRateOther").InnerXml.Replace('.', ',');
                        Price = Price / EURO_Satis.ToDouble();
                        //result.Add(EURO_Alis.ToDouble(), EURO_Satis.ToDouble());
                    }
                    break;
            }

        }
        catch (Exception ex)
        {
            return Price;
        }

        return Price;
    }

    public static double? Get(string type, double? Price, double? Kur)
    {
        var result = new Dictionary<double, double>();
        try
        {
            switch (type)
            {
                case "&#8378;":
                case "₺":
                    {
                        //string USD_Alis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml.Replace('.', ',');
                        Price = Price * Kur;
                        //result.Add(USD_Alis.ToDouble(), USD_Satis.ToDouble());
                    }
                    break;
                case "€":
                    {
                        //string EURO_Alis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/CrossRateOther").InnerXml.Replace('.', ',');
                        Price = Price / Kur;
                        //result.Add(EURO_Alis.ToDouble(), EURO_Satis.ToDouble());
                    }
                    break;
            }

        }
        catch (Exception ex)
        {
            return Price;
        }

        return Price;
    }

    public static double? Get(string type)
    {
        double doviz = 1;
        var result = new Dictionary<double, double>();
        try
        {
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);

            switch (type)
            {
                case "&#8378;":
                case "₺":
                    {
                        //string USD_Alis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml.Replace('.', ',');
                        string USD_Satis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml.Replace('.', ',');
                        doviz = USD_Satis.ToStr().ToDouble();
                        //Price = Price * USD_Satis.ToDouble();
                        //result.Add(USD_Alis.ToDouble(), USD_Satis.ToDouble());
                    }
                    break;
                case "€":
                    {
                        //string EURO_Alis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/CrossRateOther").InnerXml.Replace('.', ',');
                        string EURO_Satis = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/CrossRateOther").InnerXml.Replace('.', ',');
                        doviz = EURO_Satis.ToStr().ToDouble();
                        //result.Add(EURO_Alis.ToDouble(), EURO_Satis.ToDouble());
                    }
                    break;
            }

        }
        catch (Exception ex)
        {
            return doviz;
        }

        return doviz;
    }



}

