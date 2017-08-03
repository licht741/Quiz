using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AndroidXamarinApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AndroidXamarinApp.UI
{
    public class FinishFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.finish_fmt, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            view.FindViewById<TextView>(Resource.Id.tv_test_result).Text = Quiz.quizState.CorrectQuestionsCount + "/" + Quiz.quizState.Questions.Count;
        }

    }
}