using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using AndroidXamarinApp.UI;
using Firebase.Database;
using Firebase.Xamarin.Database;
using AndroidXamarinApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndroidXamarinApp
{
    [Activity(Label = "AndroidXamarinApp", MainLauncher = true, Icon = "@drawable/icon", Theme= "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            f();

        }

        async void f()
        {
            var database = new FirebaseClient("https://quiz-915c6.firebaseio.com/");
            
            var q = await database.Child("/").OnceAsync<Question>();
            List<Question> qs = new List<Question>();
            foreach (var c in q) { qs.Add(c.Object); }

            Quiz.quizState = new QuizState(qs);

            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.container, new OptionFragment()).Commit();

            //return qs;
        }
    }
}