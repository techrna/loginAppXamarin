using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace logreg
{
    [Activity(Label = "login", MainLauncher = true)]

    public class login : Activity ,View.IOnClickListener
    {
        Button b1,b2;
        EditText un, pass;
        int progVal = 0;
        ProgressBar progressBar;

        public void OnClick(View v)
        {

            string un1 = un.Text.ToString();

            string pass1 = pass.Text.ToString();


            string type = "login";
            if (v.Id.Equals(b1.Id))
            {

                progressBar.Visibility = Android.Views.ViewStates.Visible;
                ThreadStart threadStart = new ThreadStart(updateProg);
                Thread thread = new Thread(threadStart);
                thread.Start();
                background b1 = new background(this);
                b1.Execute(type, un1, pass1);

             





            }

            if (v.Id.Equals(b2.Id))
            {
                StartActivity(new Intent(this, typeof(reg)));
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.login);

            un = (EditText)FindViewById(Resource.Id.editText1);
            pass = (EditText)FindViewById(Resource.Id.editText2);


            b1 = (Button)FindViewById(Resource.Id.button1);
            b2 = (Button)FindViewById(Resource.Id.button2);

            b1.SetOnClickListener(this);
            b2.SetOnClickListener(this);

           progressBar = (ProgressBar)FindViewById(Resource.Id.progress_circular);
           





        }

        private void updateProg()
        {
            while (progVal<=100)
            {
                progVal += 10;
                progressBar.Progress = progVal;
                Thread.Sleep(3000);

            }
            RunOnUiThread(() =>
            {
                progressBar.Visibility = Android.Views.ViewStates.Invisible;

            });
        }
    }
}