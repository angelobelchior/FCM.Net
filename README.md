<p align="center">
  <img src="https://raw.githubusercontent.com/angelobelchior/FCM.Net/master/FCM.Net.png" width="200">
</p>


# FCM.Net
FCM.Net is designed to make it easy to send **Push Notification** using **Google's Firebase Cloud Messaging**

This library was written following Google's own [documentation](https://firebase.google.com/docs/cloud-messaging/) to make it easier to send messages from a server app / desktop app (Console Application, Asp.Net, Windows Forms, WPF, etc).

---

O FCM.Net foi criado para facilitar envio de **Push Notification** usando o **Firebase Cloud Messaging** do **Google**

Essa biblioteca foi escrita seguindo a [documentação do próprio Google](https://firebase.google.com/docs/cloud-messaging/) com o intuito de facilitar o envio de mensagens a partir de um server app ou um desktop app (Console Application, Asp.Net, Windows Forms, WPF, etc).

## Sample / Exemplo

```csharp
var registrationId = "ID generated when device is registered in FCM / ID gerado quando o device é registrado no FCM";

//You can get the server Key by accessing the url/ Você pode obter a chave do servidor acessando a url 
//https://console.firebase.google.com/project/MY_PROJECT/settings/cloudmessaging";
using(var sender = new Sender("serverKey"))
{
    var message = new Message
    {
        RegistrationIds = new List<string> { registrationId },
        Notification = new Notification
        {
            Title = "Test from FCM.Net",
            Body = $"Hello World@!{DateTime.Now.ToString()}"
        }
    };
    var result = await sender.SendAsync(message);
    Console.WriteLine($"Success: {result.MessageResponse.Success}");
        
    var json = "{\"notification\":{\"title\":\"json message\",\"body\":\"works like a charm!\"},\"to\":\"" + registrationId + "\"}";
    result = await sender.SendAsync(json);
    Console.WriteLine($"Success: {result.MessageResponse.Success}");
}
```

[Reference table for more details on how to set up your notification / Tabela de referência para maiores detalhes de como montar sua notificação](https://firebase.google.com/docs/cloud-messaging/http-server-ref#table1)

## Installation / Instalação
Package Manager
```
> Install-Package FCM.Net
```

.NET CLI
```
> dotnet add package FCM.Net
```

## Tests / Testes
There are three test projects within the Solution. Two of these projects are console-type applications.

.Net 4.6 Project, .Net Core Project and the third test application is an Android App made in Xamarin. To test it you need to have Xamarin installed and configured.

If you want to know more about Xamarin I created a playlist for beginners: http://bit.ly/XamarinParaIniciantes. [Pt-Br]

If you do not have Xamarin installed and want to test, you can disable it by right-clicking on the **FCM.Net.PCL.Playground** project and selecting **Unload Project**.

------

Existem três projetos de teste dentro da Solution. Dois desses projetos são aplicações do tipo console. 

Uma é para o .Net 4.6 e a outra para .Net Core. A terceira aplicação de testes é um App para Android feito em Xamarin. para testa-lo é necessário ter o Xamarin instalado e configurado. 

Caso queira conhecer mais sobre Xamarin criei uma playlist para iniciantes: http://bit.ly/XamarinParaIniciantes. 

Caso você não tenha o Xamarin instalado e queira testar, pode desativa-lo clicando com o botão direito no projeto **FCM.Net.PCL.Playground** e selecionando **Unload Project**.
