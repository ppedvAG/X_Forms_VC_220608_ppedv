using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.PersonenDb.Services
{
    internal static class ToastController
    {
        public static void ShowToast(string message, bool isLong = true)
        {
            switch (isLong)
            {
                case true:
                    toastService.ShowLongToast(message);
                    break;
                case false:
                    toastService.ShowShortToast(message);
                    break;
            }
        }

        private static IToastService toastService { get; set; } = DependencyService.Get<IToastService>();
    }
}
