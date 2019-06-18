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
    [Activity(Label = "Registration")]
    public class reg : Activity, View.IOnClickListener
    {
        Button b1;
        EditText userName,name,password,age;
        string type;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

           SetContentView(Resource.Layout.reg);

            b1 = FindViewById<Button>(Resource.Id.button1);
            b1.SetOnClickListener(this);
            type = "reg";
            userName = (EditText)FindViewById(Resource.Id.editText3);
            name = (EditText)FindViewById(Resource.Id.editText1);
            password = (EditText)FindViewById(Resource.Id.editText4);
            age= (EditText)FindViewById(Resource.Id.editText2);

        }


        public void OnClick(View v)
        {
            if (v.Id.Equals(b1.Id))
            {

                string sage = age.Text;
                string suserName = userName.Text;
                string spassword = password.Text;
                string sname = name.Text;
                background b1 = new background(this);
                b1.Execute(type,sname,sage,suserName,spassword);






               // StartActivity(new Intent(this, typeof(login)));
            }
        }
    }
}