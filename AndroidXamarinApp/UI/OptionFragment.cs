using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using AndroidXamarinApp.Data;
using System.Collections.Generic;

namespace AndroidXamarinApp.UI
{
    public class OptionFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fmt_question, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            var question = new Question()
            {
                Id = 1,
                CorrectOptionNumber = 3,
                Options = new List<Option>()
                {
                    new Option()
                    {
                        Number = 1,
                        OptionText = "Неправильный ответ"
                    },
                    new Option()
                    {
                        Number = 2,
                        OptionText = "Неправильный ответ"
                    },
                    new Option()
                    {
                        Number = 3,
                        OptionText = "Правильный ответ"
                    },
                    new Option()
                    {
                        Number = 4,
                        OptionText = "Неправильный ответ"
                    },

                },
                Text = "Выберите тот ответ, который правильный"
            };

            var rv = view.FindViewById<RecyclerView>(Resource.Id.rv_options);
            rv.SetAdapter(new OptionAdapter(question));
            rv.SetLayoutManager(new GridLayoutManager(Context, 2));

            view.FindViewById<TextView>(Resource.Id.tv_question).Text = question.Text;
        }
    }
}