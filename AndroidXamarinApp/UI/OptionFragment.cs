using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using AndroidXamarinApp.Data;
using Firebase.Xamarin.Database;
using Square.Picasso;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AndroidXamarinApp.UI
{
    public interface IOptionFragment {
        void OnOptionSelect(Option option);
    }

    public class OptionFragment : Fragment, IOptionFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public void OnOptionSelect(Option option)
        {
            Toast.MakeText(Context, "Option: " + option.Number, ToastLength.Long).Show();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fmt_question, container, false);
        }

        Question question;

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            question = Quiz.Questions[0];

            //view.FindViewById<ImageView>(Resource.Id.iv_image).
            Picasso.With(Context)
                .Load(question.ImageUrl)
                .Into(view.FindViewById<ImageView>(Resource.Id.iv_image), 
                () => { Init(view, question); }, 
                () => {});
        }

        void Init(View view, Question question)
        {
            var rv = view.FindViewById<RecyclerView>(Resource.Id.rv_options);
            rv.SetAdapter(new OptionAdapter(this, question));
            rv.SetLayoutManager(new GridLayoutManager(Context, 2));


            view.FindViewById<TextView>(Resource.Id.tv_question).Text = question.Text;
        }
    }
}