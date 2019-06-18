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

namespace logreg
{
    [Activity(Label = "mainUser")]
    public class mainUser : Activity,View.IOnClickListener
    {
        Button B1;
        EditText userName, name, password, age;

        public void OnClick(View v)
        {

            if(v.Id.Equals(B1.Id))
            {
                StartActivity(new Intent(this, typeof(login)));
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mainUser);
            B1 = (Button)FindViewById(Resource.Id.button1);

            B1.SetOnClickListener(this);


            string username = this.Intent.GetStringExtra("uname");

            string[] data = username.Split("-");
            userName = (EditText)FindViewById(Resource.Id.editText1);
            name = (EditText)FindViewById(Resource.Id.editText2);
            age = (EditText)FindViewById(Resource.Id.editText3);

            userName.Text = data[0];
            name.Text = data[1];
            age.Text = data[2];


            // Create your application here
        }
    }
}