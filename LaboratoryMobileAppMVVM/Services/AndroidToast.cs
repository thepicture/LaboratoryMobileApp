using Android.App;
using Android.Widget;

namespace LaboratoryMobileAppMVVM.Services
{
    public class AndroidToast : IToast
    {
        public void Show(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
}
