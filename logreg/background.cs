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
using Java.IO;
using Java.Lang;
using Java.Net;

namespace logreg
{
    class background : AsyncTask
    {
        Context cont;
        AlertDialog alert1;
        string type,username;
        
        public background(Context ext)
        {
            cont = ext;
        }

        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            type = @params[0].ToString();

            string login_url = "https://romars.000webhostapp.com/logreg/log.php";
            string reg_url = "https://romars.000webhostapp.com/logreg/reg.php";
            string userData_url = "https://romars.000webhostapp.com/logreg/userData.php";

            if (type.Equals("login"))
            {


                string username = @params[1].ToString();
                string password = @params[2].ToString();
                this.username = username;

                URL url = new URL(login_url);
                HttpURLConnection httpURLConnection = (HttpURLConnection)url.OpenConnection();



                httpURLConnection.RequestMethod = "POST";
                httpURLConnection.DoOutput = true;
                httpURLConnection.DoInput = true;
                BufferedWriter bufferedWriter = new BufferedWriter(new OutputStreamWriter(httpURLConnection.OutputStream, "UTF-8"));
                string post_data = URLEncoder.Encode("username", "UTF-8") + "=" + URLEncoder.Encode(username, "UTF-8") + "&" +
                    URLEncoder.Encode("password", "UTF-8") + "=" + URLEncoder.Encode(password, "UTF-8");
                bufferedWriter.Write(post_data);
                bufferedWriter.Flush();
                bufferedWriter.Close();



                BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(httpURLConnection.InputStream, "iso-8859-1"));

                string result = "";
                string line = "";
                while ((line = bufferedReader.ReadLine()) != null)
                {
                    result += line;
                }

                bufferedReader.Close();
                httpURLConnection.Disconnect();


                return result;


            }





           


            if (type.Equals("reg"))
            {
                string name = @params[1].ToString();
                string age = @params[2].ToString();
                string username = @params[3].ToString();
                string password = @params[4].ToString();


                URL url = new URL(reg_url);
                HttpURLConnection httpURLConnection = (HttpURLConnection)url.OpenConnection();



                httpURLConnection.RequestMethod = "POST";
                httpURLConnection.DoOutput = true;
                httpURLConnection.DoInput = true;
                BufferedWriter bufferedWriter = new BufferedWriter(new OutputStreamWriter(httpURLConnection.OutputStream, "UTF-8"));
                string post_data = URLEncoder.Encode("name", "UTF-8") + "=" + URLEncoder.Encode(name, "UTF-8") + "&" +
                    URLEncoder.Encode("age", "UTF-8") + "=" + URLEncoder.Encode(age, "UTF-8") + "&" +
                    URLEncoder.Encode("username", "UTF-8") + "=" + URLEncoder.Encode(username, "UTF-8") + "&" +
                    URLEncoder.Encode("password", "UTF-8") + "=" + URLEncoder.Encode(password, "UTF-8");
                bufferedWriter.Write(post_data);
                bufferedWriter.Flush();
                bufferedWriter.Close();



                BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(httpURLConnection.InputStream, "iso-8859-1"));

                string result = "";
                string line = "";
                while ((line = bufferedReader.ReadLine()) != null)
                {
                    result += line;
                }

                bufferedReader.Close();
                httpURLConnection.Disconnect();


                return result;


            }


            throw new NotImplementedException();
        }

        protected override void OnPreExecute()
        {
            alert1 = new AlertDialog.Builder(cont).Create();
            alert1.SetTitle("Status");

        }

        
        protected override void OnPostExecute(Java.Lang.Object result)
        {

            if(type.Equals("login"))
            { 
            if(!result.Equals("login unsuccessfull"))
            {
                    Intent intent = new Intent(cont, typeof(mainUser));
                    intent.PutExtra("uname",result.ToString());


               cont.StartActivity(intent);
            }
            else { 
            alert1.SetMessage(result.ToString());
            alert1.Show();
            }
            }


            if (type.Equals("reg"))
            {
                if (result.Equals("insert successfull"))
                {
                    alert1.SetMessage(result.ToString());

                    alert1.SetButton("ok", (c, ev) =>
                    {
                        cont.StartActivity(new Intent(cont, typeof(login)));

                    });
                    alert1.Show();



                }
                else
                {
                    alert1.SetMessage(result.ToString());
                    alert1.Show();
                }
            }






        }
       

    }
}