# airbnb
**Casus NoTS-WAPP: Inside Airbnb Amsterdam**

**Datum: 12- 01 - 2018**

**Auteur: Marcel Verheij**

```
Airbnb © 2018
```

## Inhoudsopgave

- 1. Businesscase
- 2. Opdracht : Ontwikkel een webapplicatie
   - 2.1. De applicatie moet voldoen aan de volgende eisen:
   - 2.2. Use Cases’s:
- 3. Opdracht: Voer een onderzoek uit volgens de ICA onderzoeksmethodieken:
   - 3.1. Onderzoeksopdracht
   - hostingomgeving: 3.2. Onderzoeksvragen, uitgaande van/op basis van de casus, eisen en ontwikkel-
   - 3.3. Maak een onderzoeksplan en laat dit goedkeuren door de docent.
- gepresenteerd 4. Opdracht : De resultaten van het onderzoek worden uiterlijk in week 2 van de course
- 5. Ontwikkelomgeving
- 6. Gegevens GOOGLE CLOUD SERVICES
   - a. Tutorials & documentatie GCS
   - b. GCS met Visual Studio
   - c. BUDGET
- 7. MAPBOX
- 8. Criteria
- Bijlage A : Frontend InsideAirBnB.com
- Bijlage B: Bronnen


## 1. Businesscase

Het management van Airbnb wil inzicht in het gebruik van Airbnb locaties in Amsterdam. Zij willen
weten wat het gemiddelde aantal overnachtingen is in een maand, wat de opbrengsten zijn per
buurt, en wat de gemiddelde reviews zijn in een buurt. Zij willen ook graag andere stuurinformatie
die tijdens het ontwikkeltraject naar boven kan komen. De site is bedoeld voor medewerkers van
AirBnB gebruik maar het management vindt het belangrijk dat de look-and-feel hetzelfde is als voor
externe gebruikers. Inspiratiebron voor het front-end ontwerp is de site van insideairbnb.com.

## 2. Opdracht : Ontwikkel een webapplicatie

Ontwikkel een webapplicatie op basis van de allernieuwste ASP.NET CORE2 technologie die gehost
wordt op GOOGLE CLOUD SERVICES. Er moet gebruik worden gemaakt van de publieke data die
beschikbaar is via insideairbnb.com van de stad Amsterdam. De webapplicatie moet een oplossing
bieden voor de businesscase van Airbnb.

### 2.1. De applicatie moet voldoen aan de volgende eisen:

- Ontwikkeld met de laatste Microsoft ASP.Net Core 2 versie
- Wordt gehost op het Google Cloud Service Platform
- Maakt gebruik van ASP.Net MVC
- Maakt gebruik van MSSQL Server (versie van Google Cloud Service)
- De applicatie moet veilig zijn. Gebruik de OWASP top 5 om de meest voorkomende
    onveiligheden op te sporen en af te dichten.
- De applicatie is aantoonbaar highly-scalable. Er worden daarvoor performance tests als
    bewijsmateriaal opgeleverd (voor de performance-verbeteringen en daarna).

### 2.2. Use Cases’s:

1. Registeren en inloggen (must)
2. Authenticatie en autorisatie via IdentityServer4 (Authentication As A Service) (must)
3. Filter op prijs (must)
4. Filter op buurt (must)
5. Filter op review (must)
6. Locaties van zoekresultaat zichtbaar op kaart (could)
7. Kaart is clickable, details rechts op pagina, maakt gebruik van de mapbox API (must)
8. Hosting op Google Cloud Services op Microsoft Ecosysteem (must)
9. Layout idem als insideairbnb.com (could)
10. Details per item waarop gefiltered is: #overnachtingen, #opbrengst in de maand, (must)
11. Resultaten worden weergegeven in charts (must)
12. Trends worden weergegeven in geschikte weergaven (must)


## 3. Opdracht: Voer een onderzoek uit volgens de ICA onderzoeksmethodieken:

### 3.1. Onderzoeksopdracht

```
Elke groep van drie studenten doet een onderzoek. De onderwerpen zijn, elke groep kiest twee
onderwerpen waarvan er in ieder geval één over of een Security onderwerp of een Performance
onderwerp gaat. Als een groep afvalt of niet in staat is om voldoende invulling te geven aan een
gekozen onderzoek moet dit door anderen overgenomen worden. Het is dus de
verantwoordelijkheid van alle deelnemers om de voortgang te monitoren en zonodig bij te
sturen:
```
- Security (OWASP Top 5)
- Displaying GeoData on a Map in Browser
- Displaying Charts
- Performance improvements (DATABASE, GOOGLE CLOUD SERVICES, WEBAPP)
    o Storage Locking
    o Caching
    o Asynchrony
    o Queuing & Isolation
    o Redundancy & Fault Tolerance

### hostingomgeving: 3.2. Onderzoeksvragen, uitgaande van/op basis van de casus, eisen en ontwikkel-

### ontwikkel- hostingomgeving:

```
Kies één van de OWASP Top 5 security issues.
```
- Wat is het?
- Hoe werkt het?
- Hoe merk je het?
- Hoe voorkom je het?
- Hoe implementeer je het?

```
Kies een performance onderwerp
```
- Wat is het?
- Hoe werkt het?
- Hoe implementeer je het?

```
Kies één van de andere onderwerpen nodig voor deze opdracht
```
- Wat is het?
- Hoe werkt het?
- Hoe merk je het?
- Hoe implementeer je het?


### 3.3. Maak een onderzoeksplan en laat dit goedkeuren door de docent.

```
In het onderzoeksplan staan de te onderzoeken onderwerpen, per deelvraag wordt de aanpak
beschreven en een tijdsplanning.
```
## gepresenteerd 4. Opdracht : De resultaten van het onderzoek worden uiterlijk in week 2 van de course

# week 2 van de course gepresenteerd

```
Bereid een presentatie van 30 minuten voor met de hele groep. Het doel van de presentatie is:
```
- Kennisdeling over de gekozen onderwerpen
- Oefeningen/Workshop waarbij de resultaten geïmplementeerd worden samen met alle
    aanwezigen
- Q&A

## 5. Ontwikkelomgeving

Het doel van dit semester is dat er met de nieuwste versies gewerkt wordt van het MS ASP.NET CORE
ecosysteem. Dit betekent dat er veel zelf onderzocht, geëxperimenteerd en getest moet worden.

De opdracht moet met ASP.NET CORE versie 2.1 preview ontwikkeld worden. Dit kan alleen in
combinatie met de Visual Studio 2017 Preview editie.

Downloadlink ASP.NET CORE 2.1 preview:

https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300-preview

Downloadlink Visual Studio 2017 preview:

https://www.visualstudio.com/vs/preview/?dotnetid=2141560134.

## 6. Gegevens GOOGLE CLOUD SERVICES

Het project moet uiteindelijk gedeployed en gepublished worden op het Google Cloud Services
platform. Toegang tot het project krijg je via het GCS console: https://console.cloud.google.com.

Je hebt als het goed is een uitnodiging van de docent gekregen voor toegang tot je individuele
projectomgeving. Mocht je nog geen google account hebben dan moet je dit alsnog even aanmaken
zodat je uitgenodigd kunt worden voor je projectomgeving op GCS.

### a. Tutorials & documentatie GCS

Er zijn diverse tutorials en documentatie beschikbaar via:

- https://edutrainingcenter.withgoogle.com/gcp
- https://codelabs.developers.google.com/codelabs/cloud-aspnetcore-cloudshell/#
- https://codelabs.developers.google.com/codelabs/cloud-app-engine-aspnetcore/#


### b. GCS met Visual Studio

De volgende zaken zijn van belang voor het gebruik van GCS met VS:

- Download and install Cloud tools for Visual Studio: https://cloud.google.com/visual-
    studio/?hl=nl
- Configure Visual Studio for use with Google Cloud Service:
    https://cloud.google.com/tools/visual-studio/docs/quickstart?hl=nl Via this guide also a
    complete ASP.NET stack can be installed on a VM. Costs are approx. $90,- per month. The
    service is delivered by: Google Click To Deploy. More docs at:
    https://cloud.google.com/tools/visual-studio/docs/

### c. BUDGET

Je hebt in totaal **$150,- budget** om te spenderen aan dit project aan GCS diensten. Het project is nu
ingesteld op een **max. verbruik van €35,00 per maand**.

Je moet dit zelf goed monitoren en managen. Als je over je budget gaat loop je dus kans dat je het
project niet succesvol op GCS kunt deployen en publiceren en daardoor WAPP niet succesvol kunt
afronden.

TIP: Op het Google Cloud Platform dashboard kun je via App EngineVersies instanties stoppen die
je niet gebruikt op dat moment. Laat dus niet alles zomaar aanstaan want dat kost je geld.

## 7. MAPBOX

Via MAPBOX kun je kaarten aanmaken met geolocation bestanden. Voor de airbnb casus kan het
.geojson bestand gebruikt worden voor mapbox (account maken, mapstyle kiezen en via mapbox
studio kan deze ingelezen, geedit en gebruikt worden via de mapbox API.


## 8. Criteria

De presentatie van de resultaten wordt beoordeeld op de volgende punten:

- Doel/Inleiding
- Inhoud:
    o Relevantie
    o Actualiteit
    o Nut
    o Uitleg
    o Toepasbaarheid
    o Begeleiding workshop
- Einde: Koppeling aan doel.

Het beroepsproduct (Webapplicatie AirBNB) wordt beoordeeld op de volgende punten:

- Alle must have requirements geïmplementeerd.
- Bonus: alle requirements zijn geïmplementeerd (alleen als ook alle must have’s zijn
    geïmplementeerd).
- OWASP security issues opgelost
- Performance getest (loadtests, etc. uitgevoerd) en verbeterd
- Ontwerpdocumentatie up-to-date en opgeleverd
- Werkende demo opgeleverd en laten zien


## Bijlage A : Frontend InsideAirBnB.com


## Bijlage B: Bronnen

Airbnb. (z.d.). https://www.insideairbnb.com. geraadpleegd op 9 april 2018

InsideAirbnb. (z.d.). [http://insideairbnb.com/get-the-data.html.](http://insideairbnb.com/get-the-data.html.) geraadpleegd op 9 april 2018

OWASP (27- 03 - 2018). _Top 10 Security issues._ geraadpleegd op 9 april 2018, van
https://www.owasp.org/index.php/Top_10-2017_Top_10.


