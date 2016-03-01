using Xamarin.Forms;

namespace banks
{
    class BankView : ViewCell
    {
        public BankView()
        {
            var rl = new RelativeLayout();

            var lTitle = new Label()
            {
                TextColor = Color.Black,
                YAlign = TextAlignment.Center,
                XAlign = TextAlignment.Start
            };
            lTitle.SetBinding(Label.TextProperty, "Currency");

            /*var lCurrency = new Label()
            {
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start
            };
            lCurrency.SetBinding(Label.TextProperty, "Currency");*/


            var bBankInfo = new Button() { Text = "info" };
            bBankInfo.SetBinding(Button.CommandProperty, new Binding("GotoSite", BindingMode.TwoWay));

            rl.Children.Add(lTitle,
               Constraint.RelativeToParent(p => Helper.sP),
               Constraint.RelativeToParent(p => Helper.sP),
               Constraint.RelativeToParent(p => p.Width - 50 - Helper.sP),
               Constraint.RelativeToParent(p => Helper.sH));

            rl.Children.Add(bBankInfo,
               Constraint.RelativeToParent(p => p.Width - 40 - Helper.sP),
               Constraint.RelativeToView(lTitle, (p, v) => /*v.Y + v.Height*/ + Helper.sP),
               Constraint.RelativeToParent(p => 50),
               Constraint.RelativeToParent(p => Helper.sH));

            /*rl.Children.Add(lCurrency,
               Constraint.RelativeToParent(p => Helper.sP),
               Constraint.RelativeToView(lTitle, (p, v) => v.Y + v.Height + Helper.sP),
               Constraint.RelativeToView(bBankInfo, (p, v) => p.Width - v.Width - Helper.sP),
               Constraint.RelativeToParent(p => Helper.sH));*/

            View = rl;
        }
    }
}
