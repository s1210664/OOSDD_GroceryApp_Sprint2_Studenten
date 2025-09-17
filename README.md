# GroceryApp sprint2 

## Git branching strategie
In deze repository wordt gitflow gebruikt als branching strategie. Hierin worden de branches main, release en develop standaard gebruikt naast verschillende feature en hotfix branches wanneer nodig. 

### Feature branches
Wanneer een nieuwe feature toegevoegd wordt dient een feature branch aangemaakt te worden vanaf develop, de naam hiervan moet met "feature/" starten. Wanneer de feature compleet is, moet deze branch via een pull request naar develop gemerged worden. 
### Hotfix branches
Wanneer er een patch nodig is in main, zal een hotfix branch aangemaakt moeten worden van main, de naam hiervan moet met "hotfix/" starten. Wanneer de hotfix klaar is dient de hotfix branch naar main en develop gemerged te worden via een pull request.
### Develop branch
De develop branch bestaat voor het actief ontwikkelen van de applicatie. Er mogen geen commits direct naar develop uitgevoerd worden, alle aanpassing moeten via feature branches.
### Release branch
Wanneer de develop branch klaar is voor een nieuwe release zal deze naar release gemerged moeten worden, in release mogen er alleen patches en kleine aanpassingen gemaakt worden. Als release klaar is voor productie zal deze naar develop en main gemerged moeten worden via pull requests.


## Docentversie  
In deze versie zijn de wijzigingen doorgevoerd en is de code compleet.  

## Studentversie:  
### UC04 Kiezen kleur boodschappenlijst  
Is compleet.

### UC05 Product op boodschappenlijst plaatsen:   
- `GetAvailableProducts()`  
	De header van de functie bestaat maar de inhoud niet.  
	Zorg dat je een lijst maakt met de beschikbare producten (dit zijn producten waarvan nog voorraad bestaat en die niet al op de boodschappenlijst staat).  
- `AddProduct()`   
	Zorg dat het gekozen beschikbare product op de boodschappenlijst komt (door middel van de GroceryListItemsService).  

### UC06 Inloggen  
Een collega is ziek maar heeft al een deel van de inlogfunctionaliteit gemaakt.  
Dit betreft het Loginscherm (LoginView) met bijbehorend ViewModel (LoginViewModel),  
maar ook al een deel van de authenticatieService (AuthServnn,mnmice in Grocery.Core),  
de clientrepository (ClientRepository in Grocery.Core.Data)  
en de client class (Client in Grocery.Core).  
De opdracht is om zelfstandig de login functionaliteit te laten werken.  

*Stappenplan:*  
1. Begin met de Client class en zorg dat er gebruik wordt gemaakt van Properties.  
2. In de ClienRepository wordt nu steeds een vaste client uit de lijst geretourneerd. Werk dit uit zodat de juiste Client wordt geretourneerd.  
3. Werk de klasse AuthService verder uit, zodat daadwerkelijk de controle op het ingevoerde password wordt uitgevoerd.
4. Zorg dat de LoginView.xaml wordt toegevoegd aan het Grocery.App project in de Views folder (Add ExistingItem). De file bevindt zich al op deze plek, maar wordt nu niet meegecompileerd.  
5. In MauiProgramm class van de Grocery.App staan de registraties van de AuthService en de LoginView in comment --> haal de // weg.  
6. In App.xaml.cs staat /*LoginViewModel viewModel*/ haal hier /* en */ weg, zodat het LoginViewModel beschikbaar komt.  
7. In App.xaml.cs staat //MainPage = new LoginView(viewModel); Haal hier de // weg en zet de regel erboven in commentaar, zodat AppShell wordt uitgeschakeld.  
8. Uncomment de route naar het Login scherm in AppShell.xaml.cs: //Routing.RegisterRoute("Login", typeof(LoginView)); 
 
