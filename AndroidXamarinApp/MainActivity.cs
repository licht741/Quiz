using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using AndroidXamarinApp.UI;

namespace AndroidXamarinApp
{
    [Activity(Label = "AndroidXamarinApp", MainLauncher = true, Icon = "@drawable/icon", Theme= "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            //f (bundle != null)
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.container, new OptionFragment()).Commit();

            // Set our view from the "main" layout resource
            
        }
    }
}

