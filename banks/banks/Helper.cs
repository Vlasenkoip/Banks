using System;
using System.Collections.ObjectModel;

namespace banks
{
    public static class Helper
    {
        public static ObservableCollection<Bank> Banks { get; set; }

        public static int sP = 5;
        public static int sH = 30;
    }
}
