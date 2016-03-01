using System;
using System.Linq;
using Xamarin.Forms;

namespace banks
{
    public class PageBanks : ContentPage
    {
        public PageBanks()
        {
            Title = "Курс доллара в Зеленограде";
            BackgroundColor = Color.White;

            var rl = new RelativeLayout();

            var lvBanks = new ListView()
            {
                ItemTemplate = new DataTemplate(typeof(BankView)),
                ItemsSource = Helper.Banks,
                HasUnevenRows = true
            };
            lvBanks.ItemSelected += (s, e) => 
            {
                lvBanks.SelectedItem = null;
            };

            var lvTitle = new Label()
            {
                Text = "Сколько долларов нужно обменять?",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                TextColor = Color.Black,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center,
                IsVisible = false
            };
            var edNum = new Entry() { Keyboard = Keyboard.Numeric, IsVisible = false };
            var bCalc = new Button() { Text = "Расчитать", IsVisible = false };

            bCalc.Clicked += (s, a) =>
            {
                try
                {
                    var x = Convert.ToDouble(edNum.Text);
                    var sum = x*Helper.Banks.Max(b => b.curr);

                    DisplayAlert("Успех", $"Максимальная сумма {sum} рублей", "OK");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Ошибка", ex.Message, "OK");
                }
            };

            rl.Children.Add(bCalc,
                Constraint.RelativeToParent(p => p.Width * 2 / 3 - Helper.sP),
                Constraint.RelativeToParent(p => p.Height - Helper.sH - Helper.sP),
                Constraint.RelativeToParent(p => p.Width / 3),
                Constraint.RelativeToParent(p => Helper.sH));

            rl.Children.Add(edNum,
                Constraint.RelativeToParent(p => Helper.sP),
                Constraint.RelativeToParent(p => p.Height - Helper.sH - Helper.sP),
                Constraint.RelativeToParent(p => p.Width * 2 / 3 - 3 * Helper.sP),
                Constraint.RelativeToParent(p => Helper.sH));

            rl.Children.Add(lvTitle,
                Constraint.RelativeToParent(p => Helper.sP),
                Constraint.RelativeToParent(p => p.Height - 2 * Helper.sH - 2 * Helper.sP),
                Constraint.RelativeToParent(p => p.Width - 2 * Helper.sP),
                Constraint.RelativeToParent(p => Helper.sH));

            rl.Children.Add(lvBanks,
                Constraint.RelativeToParent(p => Helper.sP),
                Constraint.RelativeToParent(p => Helper.sP),
                Constraint.RelativeToParent(p => p.Width - 2 * Helper.sP),
                Constraint.RelativeToView(lvTitle, (p, v) => v.Y - 2 * Helper.sP));

            Content = rl;

            MessagingCenter.Subscribe<Bank>(this, "ShowControls", (b) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    lvBanks.ItemsSource = Helper.Banks.OrderByDescending(bank => bank.curr);

                    lvTitle.IsVisible = true;
                    edNum.IsVisible = true;
                    bCalc.IsVisible = true;
                });
            });
        }
    }
}
