<h2 align="center">Projekt SpacePort</h2>
<h3 align="center">Grupp 3</h3>
<p align="center"><a href="https://github.com/samirehsani19">Samir</a>, <a href="https://github.com/pirren">Pierre</a>, <a href="https://github.com/oskarmorell">Oskar</a>, <a href="https://github.com/fjalling">Jakob</a></p>

##### Innehållsförteckning 

- [Lista över förkortningar och begrepp](#lista-över-förkortningar-och-begrepp)
- [Bakgrund](#bakgrund) 
  * [DevOps](#devops)
  * [Molntjänster](#molntjänster)
  * [CI/CD](#ci-cd)
- [Beslut om priser och kostnader](#beslut-om-priser-och-kostnader)
- [Metod](#metod)
  * [Arbetssätt](#arbetssätt)
  * [Tester](#tester)
  	* [Typ av tester](#typ-av-tester)
    * [Testkonvention](#testkonvention)
  * [3 lagers-arkitektur](#3-lagers-arkitektur)
    * [Presentationslager](#presentationslager)
    * [Applikationslager](#applikationslager)
    * [Datalager](#datalager)
  * [Code repository](#code-repository)
  * [Azure Portal](#azure-portal)
  * [Azure DevOps](#azure-devops) 
    * [Boards](#boards)
    * [Build och Test pipelines](#build-och-test-pipelines)
    * [Api build pipeline](#api-build-pipeline)
    * [Presentation build pipeline](#presentation-build-pipeline)
    * [Presentation release pipeline](#presentation-release-pipeline)
    * [API release pipeline](#api-release-pipeline)
- [Resultat](#resultat)

# Lista över förkortningar och begrepp
- **CI:** Continuous Integration
- **CD:** Continuous Development/Deployment
- **Presentation:** Frontend

# Bakgrund
Projektet innefattar att använda oss utav **Molntjänster** och **Azure DevOps**  samt bygga en applikation. Applikationen som ska byggas är ett parkeringssystem för ett företag där enbart folk med namn ifrån Star Wars får lov att parkera. Särskilt intressant med detta projekt är att vi redan är bekanta med applikationen från en tidigare uppgift. Alltså kan vi i detta projekt dra nytta utav misstag och framsteg vi tidigare gjort och integrera det i en så kallad *DevOps*-utvecklingsmiljö. Vi ska i projektet bland annat utnyttja oss av Continuous Integration (CI) samt Continuous Development (CD).

Projektet går ut på att öka vår kompetens i *Molntjänster* och *Azure DevOps*. Det är 2 - för oss - nya teknologier som vi studerar i denna kurs och i detta projekt får lära oss att arbeta med och fördjupa oss inom. I denna rapport kommer vi gå igenom:

* Verktyg vi använt oss av
* Metoderna vi använt oss av
* Resultat av projektet

## DevOps
DevOps är en förening av begreppen **Developer** och **Operations** som traditionelt sett är 2 olika discipliner inom IT utveckling. Utvecklare skriver kod och bygger applikationer och Operations svarar för kvalitét, testning och kundbehov. **DevOps** är kombinationen av dessa 2 företagskulturella filosofier.
## Molntjänster
I projektet ska vi utnyttja oss av Molnteknologi, och mer specifikt Azure Molntjänster. Förutom att det är namnet på kursen vi läser så kan man säga att Molntjänster är datortjänster som tillhandahålls över nätet. Det täcker allt ifrån lagring av data, säkerhetskopiering, publicering, säkerhetsanordningar, virtuella maskiner och mycket mer. 
En annan egenskap med molntjänster är deras elastiska priser, dvs man betalar för vad man använder. Sällan har molntjänster fasta priser.
Molntjänster vi ämnar att använda i projektet är åtminstone:

-  **SQL Database**
-  **Container Registry**
-  **Container Instance**, alternativt **App Service**

## CI CD
Continuous- Integration/Development var ett fokus för detta projekt. Dessa arbetsfilosofiska begrepp beskriver kontinuerligt integrerande av kod, byggnad, testning och slutligen publicering av projektet. Vi ämnar att använda främst CI då vi testar och bygger upp Docker Images kontinuerligt. Denna pipeline är länkad till vår GitHub master branch, vilket vill säga att varje commit till master - samt pull request mot master - bygger upp vår applikation.

# Beslut om priser och kostnader
## Kostnad för testapplikation
Då denna applikationen endast ska användas i test syfte så finns det lite besparingar men inte mycket. Vi kan använda oss utav Container Instance där vi endast behöver betala för tiden vi har uppe containern. Dessutom kan vi tjäna in lite pengar med en serverless databas.

**Container Registry**: Basic|2 enheter i 30 dagar|5GB bandbredd **87 kr**

**Container Instance**: 1 containergrupp i 7 dagar|2 GB minne|2 vCPU **73 kr**

**Databas i MySQL**: General Purpose|2 vCore|Pay as you go|5GB storage **42 kr**

**Totalbelopp: 202 kr i månaden**

## Kostnad för eventuell applikation

Om applikationen skulle gå att användas publikt så skulle kostnaden bli lite mycket högre. Den kan dessutom behöva höjas beroende på hur många som använder sig av applikationen

**Container Registry**: Basic|2 enhet i 30 dagar|5GB bandbredd **87 kr**

**App service**: Basic|Linux|1 enhet i 30 dagar|1 core|1.75 GB RAM|10 GB minne **113 kr**

**Databas i MySQL**: General Purpose|2 vCore|Pay as you go|50GB storage **42 kr**

**Totalbelopp: 242 kr i månaden**

# Metod
## Arbetssätt
Vi började dagarna med att samlas på Discord och diskutera hur vi låg till. Vi satte sedan gemensamt upp **Issues** för att arbeta med i separata GitHub-branches. Varje branch fick lov att mergas till GitHub master när minst 2 kontrollanter gav godkännande.

Våra arbetstider var vardagar **9** till **16**. Kunde man inte komma in och arbeta skulle man ge förvarning om det.

## Tester
### Typ av tester
Vi valde att endast använda oss av unit tester och inte försöka oss på integrations eller funktionell testning. Detta för att vi inte använt oss av annat än unit tester innan och detta då skulle ta alldeles för stor del i projektet.

### Testkonvention
Vi valde xUnit som vårat test ramverk. Så mycket som möjligt ska testas helst att alla klasser åtminstone har ett test. Dessa tester ska köras automatiskt i våran pipeline.

Testklassnamn ska skrivas utifrån följande:

```
KlassensNamnTests
```

Testmetodnamn ska skrivas utifrån följande:

```
MetodensNamn_VadSomTestas_VadSomFörväntas
```

Däremot valde vi att förutom namnen på klasser och metoder inte ha någon mer invecklad standard på hur man skriver själva testet utan att detta är upp till var och en vad man föredrar.

## 3 lagers-arkitektur
Programmet använder sig av 3 komponenter i ett så kallat 3 lagers-arkitektur (eller *n*-tiered architecture).
### Presentationslager
Vi valde att bygga vårat Presentationslager som en anpassad webbsida. Denna är byggd på HTML, CSS och JavaScript (JQuery). Vi gjorde och såg detta valet som fördelaktigt för att slippa lära oss t ex Razorpages, och kunde hellre fokusera på CI och CD genom projektets gång.

### Applikationslager
Vårat Applikationslager är ett .NET Core API som fungerar som en mellanhand och arbetare mellan presentationen och datalagret. API:et använder sig av 4 modeller: 
```csharp
public class Driver
{
    [Key] 
    public int DriverId { get; set; }
    public string Name { get; set; }
}
class Receipt 
{
    [Key] 
    public int ReceiptId { get; set; }
    public int Price { get; set; }
    public DateTime RegistrationTime { get; set; }
    public DateTime EndTime { get; set; }
	public Driver Driver { get; set; }
    public Parkingspot Parkingspot { get; set; }
}
class Parkinglot 
{
    [Key]
    public int ParkinglotId { get; set; }
    public string Name { get; set; }
    public ICollection<Parkingspot> Parkingspot { get; set; }
}
class Parkingspot 
{
    [Key]
    public int ParkingspotId { get; set; }
    public int Size { get; set; }
    public bool Occupied { get; set; }
    public Parkinglot Parkinglot { get; set; }
}
```
Varje Model har en tillhörande Controller och ett tillhörande Repository. Interfaces ska skrivas för samtliga repositories för att behålla låg koppling. En fördel med att bygga på detta viset är att vi inte får för avancerade relationer i databasen, och API:et blir behändigt att arbeta med.

### Datalager
Vi använder en Azure SQL relationsdatabas. Vi valde sedan att bygga upp och populera denna med EntityFrameworkCore och Code first metoden. Vi var alla som mest bekanta med relationsdatabaser och detta var ett väldigt billigt alternativ.

## Code Repository
För vårat projekt använder vi ett GitHub repository. Detta repository kopplar vi till ett projekt i Azure DevOps där vi tidigt i projektets gång satte upp våra build och test pipelines.

## Azure Portal
Vi valde använder Azure Portal för att skapa **App Service** och **Container Registry** eftersom vi finner alternativet enklare än Azure CLI. Man kan till exempel se vilken specifikation har en container registry har och vad det kostar per månad. Med CLI det är svårare att skapa saker eftersom man måste följa en viss ordning när man matar in kommandon och det är lätt att få fel på grund av felstavning. Om man får fel man är tvungen att skriva om allting från början vilket är besvärligt. 

## Azure DevOps 
### Boards
Vi valde att använda oss utav Azure DevOps Boards mestadels för att vi skulle ha ett bra sett att organisera oss på och för att ha ett bra sätt att dela upp vårat arbete på. När vi började projektet så diskuterade vi i gruppen om vi skulle använda oss utav Boards eller Jira. Vi valde i slutändan Boards eftersom ingen av oss hade använt sig utav det tidigare och vi tyckte det skulle vara intressant att lära oss ett till sätt att skapa sprints etc. Dessutom så var det en fördel med Boards eftersom vi redan använde oss utav Azure DevOps så det blev lite smidigare att ha så mycket samlat på samma plattform som möjligt.

###  Build och Test pipelines
Vi  separerar våra build pipelines i 2 st filer. Detta för att lättare hålla isär projektspecifika skillnader, och dela upp kod:
- **azure-pipelines-api.yml**
- **azure-pipelines-presentation.yml**

### API build pipeline

Vår API build pipeline gör flera saker.  Först och främst den gör en build av vår projekt för att se till att projektet kan utföra en build.  Om det inte går att göra en build av projektet då finns det ingen mening att gå vidare.  Sedan utför vi våra tester för att kolla om allting går igenom tester och därefter publicerar vi det.

Det sista vi gör är att builda en container och sedan pusha det till azure container registry. 

```yaml

trigger:
- master

pool:
  vmImage: 'ubuntu-latest'

variables:
  buildConfiguration: 'Release'

steps:
- task: DotNetCoreCLI@2
  inputs:
    command: 'build'
    projects: 'SpacePort/*.csproj'

- task: DotNetCoreCLI@2
  inputs:
    command: 'test'
    projects: 'SpacePort.Tests/*.csproj'
    arguments: '--configuration $(buildConfiguration)'

- task: DotNetCoreCLI@2
  inputs:
    command: 'publish'
    publishWebProjects: true
    zipAfterPublish: false
    workingDirectory: 'SpacePort'
    

- task: Docker@2
  inputs:
    containerRegistry: 'apiConnection'
    repository: 'spaceport-backend'
    command: 'buildAndPush'
    Dockerfile: 'SpacePort/Dockerfile'

```

### Presentation build pipeline
Vi har en enkel pipeline för frontend som gör sitt jobb med få rader kod. Vi bestämmer att den ska köras i gång varje gång en ändring kommer till master branchen.  Vi väljer en image med hjälp av pool från microsoft-hosted agent för att köra vår job på VM/Container.  Därefter bestämmer vi att den ska göra en build och sedan pusha vår container till **container registry** på azure.  När vår container är färdig med sin uppgift då körs vår **Presentation Release pipeline** igång.

```yaml
trigger:
- master
pool:
  vmImage: 'ubuntu-latest'
steps:
- task: Docker@2
  inputs:
    containerRegistry: 'sp3connection'
    repository: 'sp3presentation'
    command: 'buildAndPush'
    Dockerfile: Presentation/Dockerfile
```

### Presentation Release Pipeline
Vår Release pipeline för presentation körs igång varje gång vår *Presentation Build pipeline* körs, detta händer eftersom vi har lagt till en **Artifact** som är baserat på vår senast version av Build Pipeline och har aktiverat **continuous deployment trigger**. Därefter så tar vår release pipeline vår image och deployar det till en service app på azure. 

### API release pipeline
Denna pipeline hoppar igång när vår build pipeline för API är färdig med sitt jobb och pushat en container till azure container registry, detta för att i vår artifact har vi bestämt att den ska ta den senaste tag ID:n på vår container och sedan deploy det till vår app service. 

# Resultat
Resultatet av projektet blev nästan som förväntat. Vi har mestadels lyckats uppnå våra uppsatta mål av applikationen, fördjupning inom CI/CD, Molntjänster och Azure DevOps. 

Vi satte av med att först bygga upp basen för vårat API samt att sätta upp en relationsdatabas på Azure. Vi förde dagliga standups på morgonen med hög närvaro, och samlades alltid minst en gång innan lunch och innan dagens slut för att återkoppla. Cirka en vecka in i projektet så designade vi ett interface för vår Frontend och använde oss av jQuery Ajax för att kommunicera med API:et. Allt detta gick helt smärtfritt.

Vi låg bra till tidsmässigt fram emot slutet där vi började stöta på problem. **Release Pipelines** för API ville inte fungera för oss och detta stal mycket tid. Dessutom var detta i ett sent skede när vi nästan var färdiga och behövde fokusera på dokumentation och video presentation. 

Vår lösning innehåller: 

- De mest kostnadseffektiva Molnlösningarna vi kunde hitta på Azure Portal
  - Azure SQL
  - Azure Container Instance
  - Azure Container Registry
- Frontend byggd i statisk html, css och JavaScript (jQuery)
- .NET Core Backend API

Vi gjorde ett diagram av hur vi tänkte oss att applikationen ska fungera. Detta är mer eller mindre slutresultatet. En skillnad är att en använder inte kan återanvända sitt tidigare Konto utan behöver skapa ett nytt.

<div align="center"><img width="50%" src="gfx/diagram-flowchart.png"></div> 

En Frontend App byggd i HTML, JS, CSS som kommunicerar med vårat REST API för att presentera information. Slutresultatet av vår Frontend ser ni nedan:

<div align="center"><img width="75%" src="gfx/presentation-demo.png"></div> 

Vår lösning på API innehåller följande: 

<div align="center"><img src="gfx/api-solution.png"></div> 



Som tänkt från början ville vi ha en simpel tabellstruktur och inte allt för många tabeller och modeller till API:et. Vi ville ha en "minimum viable solution" och vår databas återspeglar detta:  

<div align="center"><img src="gfx/datalayer.png"></div> 

Våra Pipelines (Test, Build och Publish) kan enklast demonstreras med ett diagram:

<div align="center"><img src="gfx/diagram-pipelines.png"></div> 

