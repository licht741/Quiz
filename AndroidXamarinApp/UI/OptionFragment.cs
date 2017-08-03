using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using AndroidXamarinApp.Data;
using Square.Picasso;
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
            
            var isCorrect = Quiz.IsCorrectOption(option);
            if (isCorrect)
            {
                Quiz.quizState.CorrectQuestionsCount++;
                View.FindViewById<RelativeLayout>(Resource.Id.rl_correct_answer).Visibility = ViewStates.Visible;
                View.Post(async () =>
                {
                    await Task.Delay(2500);
                    View.FindViewById<RelativeLayout>(Resource.Id.rl_correct_answer).Visibility = ViewStates.Gone;

                    await Task.Delay(500);
                    loadQuestion(View);
                });
            }
            else
            {
                View.FindViewById<RelativeLayout>(Resource.Id.rl_invalid_answer).Visibility = ViewStates.Visible;
                View.Post(async () =>
                {
                    await Task.Delay(2500);
                    View.FindViewById<RelativeLayout>(Resource.Id.rl_invalid_answer).Visibility = ViewStates.Gone;

                    await Task.Delay(500);
                    loadQuestion(View);
                });
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fmt_question, container, false);
        }

        Question question;

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            if (Quiz.quizState.Questions.Count > Quiz.quizState.PassedQuestionsCount)
            {
                loadQuestion(view);
            }
        }

        void loadQuestion(View view)
        {

            if (Quiz.quizState.Questions.Count <= Quiz.quizState.PassedQuestionsCount)
            {
                Activity.SupportFragmentManager.BeginTransaction().Replace(Resource.Id.container, new FinishFragment()).Commit();
                return;
            }

            question = Quiz.quizState.Questions[Quiz.quizState.PassedQuestionsCount++];
            Picasso.With(Context)
                .Load(question.ImageUrl)
                .Into(view.FindViewById<ImageView>(Resource.Id.iv_image),
                () => { Init(view, question); },
                () => { });
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