-- Affichez toutes les colonnes de la table "Users" pour tous les utilisateurs.
SELECT *
FROM Users

-- Sélectionnez les noms et prénoms des utilisateurs nés à New York ou à Paris.
SELECT first_name, last_name
FROM [Users]
WHERE birth_location IN('New York', 'PARIS');

-- Affichez les utilisateurs dont le travail est "Developer" ou "Designer".
SELECT *
FROM [Users]
WHERE job = 'Developer' OR job ='Designer';

-- Sélectionnez les utilisateurs dont l'âge est supérieur à 30 ans.
SELECT *
FROM [Users]
WHERE age > 30;

-- Affichez les utilisateurs dont le salaire est compris entre 2500 et 3000.
SELECT *
FROM [Users]
WHERE salary IN (2500,3000);

-- Sélectionnez les utilisateurs dont le travail n'est ni "Developer" ni "Designer".
SELECT *
FROM [Users]
WHERE job NOT IN('Developer','Designer');

/*Affichez les utilisateurs
triés par ordre alphabétique du nom de famille, puis du prénom.*/
SELECT *
FROM [Users]
ORDER BY last_name, first_name;