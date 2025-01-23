/*Sélectionnez les cinq utilisateurs les plus âgés de la table "Users",
triés par ordre décroissant d'âge.*/
SELECT TOP 5 *
FROM [Users]
ORDER BY age DESC;

/*Affichez les enregistrements 6 à 10 triés par ordre alphabétique du
prénom*/
SELECT *
FROM [Users]
ORDER BY first_name
OFFSET 5 ROWS
FETCH NEXT 5 ROWS ONLY;

/*Sélectionnez les trois utilisateurs ayant les salaires les plus élevés
de la table "Users", triés par ordre décroissant de salaire*/
SELECT TOP 3 *
FROM [Users]
ORDER BY salary DESC;