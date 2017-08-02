using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using AndroidXamarinApp.Data;

namespace AndroidXamarinApp.UI
{
    class OptionAdapter: RecyclerView.Adapter
    {
        private Question mQuestion;
        private IOptionFragment fragment;

        public OptionAdapter(IOptionFragment fragment, Question question)
        {
            mQuestion = question;
            this.fragment = fragment;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.card_item, parent, false);
            return new OptionViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((OptionViewHolder)holder).tvOption.Text = mQuestion.Options[position].OptionText;
            ((OptionViewHolder)holder).ItemView.Click += delegate { fragment.OnOptionSelect(mQuestion.Options[position]); };
        }

        public override int ItemCount => mQuestion.Options.Count;

        class OptionViewHolder: RecyclerView.ViewHolder
        {

            public TextView tvOption;

            public OptionViewHolder(View v): base(v)
            {
                tvOption = v.FindViewById<TextView>(Resource.Id.tv_option);
            }
        }
    }
}