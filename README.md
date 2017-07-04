<p align="center">
  <img src="https://raw.githubusercontent.com/angelobelchior/FCM.Net/master/FCM.Net.png" width="200">
</p>


# FCM.Net
O FCM.Net foi criado para facilitar envio de **Push Notification** usando o **Firebase Cloud Messaging** do **Google**

Essa biblioteca foi escrita seguindo a [documentação do próprio Google](https://firebase.google.com/docs/cloud-messaging/) com o intuito de facilitar o envio de mensagens a partir de um server app ou um desktop app (Console Application, Asp.Net, Windows Forms, WPF, etc).

## Exemplo de envio

```csharp
var registrationId = "ID gerado quando o device é registrado no FCM";
var serverKey = "acesse https://console.firebase.google.com/project/MY_PROJECT/settings/cloudmessaging";

using(var sender = new Sender(serverKey))
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
        
    var json = "{\"notification\":{\"title\":\"mensagem em json\",\"body\":\"funciona!\"},\"to\":\"" + registrationId + "\"}";
    result = await sender.SendAsync(json);
    Console.WriteLine($"Success: {result.MessageResponse.Success}");
}
```

[Tabela de referência para maiores detalhes de como montar sua notificação](https://firebase.google.com/docs/cloud-messaging/http-server-ref#table1)

## Instalação
O FCM.Net está disponível para instalação via Nuget
- .Net 4.6 https://www.nuget.org/packages/FCM.Net
```nuget
Install-Package FCM.Net
```

- .Net Core https://www.nuget.org/packages/FCM.Net.Core
```nuget
Install-Package FCM.Net.Core 
```

- .Net Standard https://www.nuget.org/packages/FCM.Net.Standard
```nuget
Install-Package FCM.Net.Standard 
```

- PCL https://www.nuget.org/packages/FCM.Net.PCL
```nuget
Install-Package FCM.Net.PCL
```

## Testes
Existem três projetos de teste dentro da Solution. Dois desses projetos são aplicações do tipo console. 

Uma é para o .Net 4.6 e a outra para .Net Core. A terceira aplicação de testes é um App para Android feito em Xamarin. para testa-lo é necessário ter o Xamarin instalado e configurado. 

Caso queira conhecer mais sobre Xamarin criei uma playlist para iniciantes: http://bit.ly/XamarinParaIniciantes. 

Caso você não tenha o Xamarin instalado e queira testar, pode desativa-lo clicando com o botão direito no projeto **FCM.Net.PCL.Playground** e selecionando **Unload Project**.