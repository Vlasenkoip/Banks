using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.Linq;

namespace banks
{
    public class Bank : INotifyPropertyChanged
    {
        public string SiteEncoding { get; set; }
        public string Id { get; set; }
        public string Encoding { get; set; }
        public bool IsExtended { get; set; }
        public string Pattern { get; set; }
        public string SpecialUrl { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public double? curr { get; set; }

        public string Currency { get {

                if (curr == null)
                {
                    Task.Run(async () =>
                    {
                        do
                        {
                            curr = await SiteParse();
                        } while (curr == null);

                        if (Helper.Banks.FirstOrDefault(b => b.curr == null) == null)
                            MessagingCenter.Send(this, "ShowControls");

                        SendPropChanged("Currency");
                    });
                    return Title;
                }
                else return $"{Title}, {Math.Round(curr.Value, 2).ToString("F2")}";

            } }

        public async Task<double?> SiteParse()
        {
            try
            {
                var client = new HttpClient();

                var response = await client.GetAsync(SpecialUrl ?? Url);

                if (!response.IsSuccessStatusCode) return null;

                var buf = await response.Content.ReadAsByteArrayAsync();
                var buffer = System.Text.Encoding.UTF8.GetString(buf, 0, buf.Length);

                if (buffer == null) return null;

                var regex = new Regex(Pattern);
                var match = string.Empty;

                match = regex.Match(buffer).Value;

                match = match
                    .Replace(" ", string.Empty)
                    .Replace(Environment.NewLine, string.Empty)
                    .Replace("<tr>", string.Empty)
                    .Replace("</tr>", string.Empty)
                    .Replace("<td>", string.Empty)
                    .Replace("</td>", string.Empty)
                    .Replace("<b>", string.Empty)
                    .Replace("</b>", string.Empty)
                    .Replace("<", string.Empty)
                    .Replace(">", string.Empty)
                    .Replace("span", string.Empty)
                    .Replace(";", string.Empty)
                    .Replace("\t", string.Empty)
                    .Replace("strong", string.Empty)
                    .Replace("USD_pok", string.Empty)
                    .Replace("arRates['USD_RUR']=", string.Empty)
                    .Replace("USD/class=\"col_02\"", string.Empty)
                    .Replace("tdclass=\"name\"USD", string.Empty)
                    .Replace("class=\"down\"", string.Empty)
                    .Replace("tdclass=\"name\"USD", string.Empty)
                    .Replace("5&nbsp;000&nbsp;USD)", string.Empty)
                    .Replace(".w", string.Empty)
                    .Replace("USD", string.Empty);

                if (Id == "sdm" || Id == "psbank" || Id == "sberbank")
                {
                    match = match.Substring(match.Length - 5, 5);
                }

                if (Id == "vtb")
                {
                    match = match.Substring(match.IndexOf("Buy") + 6, 5);
                }

                match = match.Replace(',', '.');

                return Convert.ToDouble(match, CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }
        }

        public Command GotoSite => new Command(()=> {
            Device.OpenUri(new System.Uri(Url));
        });

        #region INotifyPropertyChanged impl
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SendPropChanged(string name)
        {
            OnPropertyChanged(name);
        }
        #endregion
    }
}
