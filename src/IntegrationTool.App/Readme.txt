IntegrationTool

Een eenvoudige .NET console applicatie geschreven in C#, welke om de paar minuten gestart moet worden.

Doel van de tool:

    Excel bestanden in te sturen naar een web API om als databron te dienen.

    Integratie bestanden met formulier data te downloaden van de web API om lokaal verder te verwerken.

De tool heeft nodig:

    Internet toegang het adres van de web API via HTTPS.
   
    Leesrechten op de installatie map.
    Schrijf- en leesrechten op map .\AppData voor data opslag (locatie instelbaar in AppSettings.config).
    Schrijf- en leesrechten op map .\Logs voor log bestanden (locatie instelbaar in log4net.config).

    Leesrechten op de betreffende Excel bestanden die als databron dienen.

    Schrijf- en leesrechten op mappen ingesteld voor integraties.
    Schrijf- en leesrechten op de mappen ingesteld voor het opruimen van oude bestanden.

Werking van de tool:

    Elke keer dat de tool start verstuurd het een bericht naar de API op te laten weten dat het werkt (instelbaar).
    Delen van de configuratie worden meegestuurd zodat kunnen zien of alles goed ingesteld staat.
    Hierbij kan ook worden meegestuurd de beschikbaar ruimte voor de opgegeven locaties (instelbaar).

    Een databron bestand wordt verstuurd wanneer een van de volgende situaties zich voordoet:
        De grootte is veranderd.
        De aanmaakdatum is veranderd.
        De datum van laatste wijziging is veranderd.
        De laatste keer dat het bestand werd verstuurd is langer dan 12 uur (instelbaar) geleden.
        De hash van het bestand is veranderd, de hash wordt vernieuwd en vergeleken als het langer dan 1 uur (instelbaar) geleden is gedaan.

    Voor integraties wordt elke keer dat de tool start de lijst met integratie export bestanden opgevraagd.
    Vervolgens wordt elke bestand opgehaald en geplaatst in de ingestelde locatie.

    Elke keer dat de tool start worden oude bestanden opgeruimd.

    De applicatie kan niet meerdere keren gelijktijdig actief zijn onder dezelfde gebruiker.

    De applicatie gebruikt log4net om gebeurtenissen vast te leggen.

Instellingen:

    IntegrationTool.exe.config
    Geen aanpassingen nodig.

    log4net.config
    Instellingen voor log4net.
    Geen aanpassingen nodig.

    appsettings.json
    Instellingen voor de applicatie.
    Hier moeten diverse zaken worden ingesteld zoals de gegevens van de API en de locaties van bestanden.

    De instellingen zijn voorzien van tekst en uitleg.

    Bij Windows Taak 'start in' instellen op de map waar de tool staat.

Contact:

    Bij vragen of problemen contact op nemen via email met support at informapp.nl
