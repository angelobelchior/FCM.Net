using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views.Animations;
using System.Threading.Tasks;

namespace FCM.Net.PCL.Playground
{
    [Activity(Label = "FCM.Net: Teste de envio de PN", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += async (s, e) =>
            {
                var registrationId = "ID gerado quando o device é registrado no FCM";
                var serverKey = "acesse https://console.firebase.google.com/project/MY_PROJECT/settings/cloudmessaging";

                using (var sender = new Sender(serverKey))
                {
                    var message = new Message
                    {
                        RegistrationIds = new List<string> { registrationId },
                        Notification = new Notification
                        {
                            Title = "Test PCL Android",
                            Body = $"Hello World@!{DateTime.Now.ToString()}"
                        }
                    };
                    var result = await sender.SendAsync(message);
                    if (result.StatusCode == System.Net.HttpStatusCode.OK && result.MessageResponse.Success == 1)
                    {
                        var json = "{\"notification\":{\"title\":\"mensagem em json\",\"body\":\"funciona!\"},\"to\":\"" + registrationId + "\"}";
                        result = await sender.SendAsync(json);
                        if (result.StatusCode == System.Net.HttpStatusCode.OK && result.MessageResponse.Success == 1)
                        {
                            this.AlertDialog("Enviado...");
                        }
                    }
                    else
                    {
                        this.AlertDialog("Erro...");
                    }
                }
            };
        }

        private void AlertDialog(string message)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("Push Notification");
            builder.SetMessage(message);
            builder.SetCancelable(false);
            builder.SetPositiveButton("OK", (ss, ee) => { });
            builder.Show();
        }
    }
}

