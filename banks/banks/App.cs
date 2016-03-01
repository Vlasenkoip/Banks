using Xamarin.Forms;

namespace banks
{
    public class App : Application
    {
        public App()
        {
            InitBanks();

            MainPage = new NavigationPage(new PageBanks());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        void InitBanks()
        {
            Helper.Banks = new System.Collections.ObjectModel.ObservableCollection<Bank>();

            Helper.Banks.Add(new Bank()
            {
                Encoding = "Windows-1251",
                Id = "runabank",
                IsExtended = false,
                Pattern = @"<USD_pok>([\d\.\,]+)",
                SpecialUrl = "http://www.runabank.ru/Stavki/kurs_z.xml",
                Title = "Рунабанк [1011]",
                Url = "http://www.runabank.ru/contacts/"
            });
            
            Helper.Banks.Add(new Bank()
            {
                Encoding = "UTF-8",
                Id = "vtb",
                IsExtended = false,
                Pattern = @".CurrencyGroupAbbr.:.cash.,.CurrencyAbbr.:.USD.,[^\}]+?Buy.:.([\d\.\,]+)[^\}]+?Gradation.:1,",
                SpecialUrl = null,
                Title = "ВТБ [1805]",
                Url = "http://www.vtb24.ru/personal/Pages/default.aspx?geo=zelenograd"
            });
            
            Helper.Banks.Add(new Bank()
            {
                Encoding = "UTF-8",
                Id = "rgsbank",
                IsExtended = false,
                Pattern = @"arRates\[.USD_RUR.\]\s*=\s*([\d\.\,]+);",
                SpecialUrl = "http://rgsbank.ru/",
                Title = "Росбанк [601]",
                Url = "http://www.rosbank.ru/ru/offices/detail/moskovskaya_oblast/Zelenogradskij/"
            });
            
            Helper.Banks.Add(new Bank()
            {
                Encoding = "UTF-8",
                Id = "rsb",
                IsExtended = false,
                Pattern = @"<b>USD</b>[\s\S]+?<span[^>]+>([\d\.\,]+)",
                SpecialUrl = "http://www.rsb.ru/courses/",
                Title = "Русский стандарт [1824]",
                Url = "http://www.rsb.ru/about/branch/zelenograd/213637291/"
            });

            Helper.Banks.Add(new Bank()
            {
                Encoding = "UTF-8",
                Id = "openbank",
                IsExtended = false,
                Pattern = @"USD<\/span><span[^>]+>([\d\.\,]+)",
                SpecialUrl = "https://www.openbank.ru",
                Title = "Открытие [1824]",
                Url = "https://www.openbank.ru/addresses?city=%D0%9C%D0%BE%D1%81%D0%BA%D0%B2%D0%B0"
            });

            Helper.Banks.Add(new Bank()
            {
                Encoding = "UTF-8",
                Id = "smpbank",
                IsExtended = false,
                Pattern = @"<tr>\s*<td>USD<\/td>\s*<td><strong>([\d\.\,]+)",
                SpecialUrl = "http://smpbank.ru/",
                Title = "СМП [1824]",
                Url = "http://smpbank.ru/ru/about/contact?branch=37"
            });

            Helper.Banks.Add(new Bank()
            {
                Encoding = "UTF-8",
                Id = "psbank",
                IsExtended = false,
                Pattern = @"5\&nbsp;000\&nbsp;USD[^<]*[\s\S]+?>([\d\.\,]+)",
                SpecialUrl = "http://www.psbank.ru/Personal/Everyday/Rates/Geo/Moscow",
                Title = "Промсвязьбанк [445]",
                Url = "http://www.psbank.ru/Office?OfficeId=612"
            });            

            Helper.Banks.Add(new Bank()
            {
                Encoding = "Windows-1251",
                Id = "raiffeisen",
                IsExtended = false,
                Pattern = @"<tr>\s*<td class=.name.>USD<\/td>\s*<td>([\d\.\,]+)",
                SpecialUrl = "http://www.raiffeisen.ru/",
                Title = "Райффайзен [828]",
                Url = "http://www.raiffeisen.ru/offices/poi/?id=951"
            });
            
            Helper.Banks.Add(new Bank()
            {
                Encoding = "UTF-8",
                Id = "sdm",
                IsExtended = false,
                Pattern = @"кроме:[\s\S]*отделений:[\s\S]*<tr>\s*<td>USD<\/td>\s*<td>([\d\.\,]+)",
                SpecialUrl = "http://www.sdm.ru/",
                Title = "СДМ [БЦ]",
                Url = "http://www.sdm.ru/koordinaty/2130/"
            });
            
            Helper.Banks.Add(new Bank()
            {
                Encoding = "Windows-1251",
                Id = "sberbank",
                IsExtended = false,
                Pattern = @"alt=.USD. title=[\s\S]+?<td[\s\S]+?<td.*\s*([\d\.\,]+)",
                SpecialUrl = "http://data.sberbank.ru/moscow/ru/quotes/currencies/?base=beta",
                Title = "Сбербанк",
                Url = "http://sberbank.ru/ru/about/today/oib"
            });
        }
    }
}
