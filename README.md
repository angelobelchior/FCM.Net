<p align="center">
  <img src="https://raw.githubusercontent.com/angelobelchior/FCM.Net/master/FCM.Net.png" width="200">
</p>


# FCM.Net
O FCM.Net foi criado para facilitar envio de **Push Notification** usando o **Firebase Cloud Messaging** do **Google**

Essa biblioteca foi escrita seguindo a [documentação do próprio Google](https://firebase.google.com/docs/cloud-messaging/) com o intuito de facilitar o envio de mensagens a partir de um server app ou um desktop app (Console Application, Asp.Net, Windows Forms, WPF, etc).

##Exemplo de envio

```csharp
var registrationId = "ID gerado quando o device é registrado no FCM";
var serverKey = "acesse https://console.firebase.google.com/project/MY_PROJECT/settings/cloudmessaging";

var sender = new Sender(serverKey);
var message = new Message
{
    RegistrationIds = new List<string> { registrationId }, //Pode-se passar uma lista de devices...
    Notification = new Notification
    {
        Title = "FCM.Net :)",
        Body = $"Olá Mundo!"
    }
};
var result = await sender.SendAsync(message);
```

[Tabela de referência para maiores detalhes de como montar sua notificação](https://firebase.google.com/docs/cloud-messaging/http-server-ref#table1)

##Instalação
O FCM.Net está disponível para instalação via [Nuget](https://www.nuget.org/packages/FCM.Net/1.0.0)

```nuget
Install-Package FCM.Net
```
