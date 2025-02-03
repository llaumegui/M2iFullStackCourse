# M�mo EFCore

## M�thode 01 - dotnet ef CLI
1. Installer Entity Framework
	- installation du CLI de EFCore: `dotnet tool install --global dotnet-ef --version "6.x.x"` 
	- /!\ S�lectionner la version en lien avec votre SDK .NET (ex: 6.x.x)
	- Installer le package nugget : `Microsoft.EntityFrameworkCore.SqlServer` 
	- Puis : `Microsoft.EntityFrameworkCore.Design` qui permet d'ex�cuter des commandes dans le terminal
2. Cr�er des mod�les de l'application
3. Cr�ation de la classe DbContext
	- Cr�er une classe qui h�rite de `DbContext` g�n�ralement `ApplicationDbContext`
	- Surcharger la m�thode `OnConfiguring()` pour utiliser la base de donn�es souhait�e
	- Cr�er des propri�t�s `DbSet<>` pour vos entit�s, nommer les au pluriel !
	- Cr�er un constructeur de base qui utilise le constructeur du parent
4. Commandes dotnet ef
	- Pour cr�er une migration, taper `dotnet ef migrations add <nom migration>`
	- Pour mettre � jour le sch�ma de la base de donn�es taper : `dotnet ef database update`
5. Supprimer la base de donn�es
	- `dotnet ef database drop`

## M�thode 02 - Package Tools
1. Installer Entity Framework
	- /!\ S�lectionner la version en lien avec votre SDK .NET (ex: 6.x.x)
	- Installer le package nugget : `Microsoft.EntityFrameworkCore.SqlServer` 
	- Puis : `Microsoft.EntityFrameworkCore.Tools` qui permet d'ex�cuter des commandes dans le terminal
2. Cr�er des mod�les de l'application
3. Cr�ation de la classe DbContext
	- Cr�er une classe qui h�rite de `DbContext` g�n�ralement `ApplicationDbContext`
	- Surcharger la m�thode `OnConfiguring()` pour utiliser la base de donn�es souhait�e
	- Cr�er des propri�t�s `DbSet<>` pour vos entit�s, nommer les au pluriel !
	- Cr�er un constructeur de base qui utilise le constructeur du parent
4. Commandes dotnet ef dans la console du Package Manager `Outils -> Gestionnaire de package Nugget -> Console du gestionnaire de package`
	- Pour cr�er une migration, taper `Add-Migration <nom>`
	- Pour mettre � jour le sch�ma de la base de donn�es taper : `Update-Database`
5. Supprimer la base de donn�es
	- `Drop-Database`
