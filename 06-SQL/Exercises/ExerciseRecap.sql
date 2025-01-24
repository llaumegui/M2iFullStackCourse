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

-- Sélectionnez les utilisateurs nés avant l'année 1990.
SELECT *
FROM [Users]
WHERE YEAR(birth_date) <1990;

/*Affichez les utilisateurs
dont le lieu de naissance est "London" ou "Berlin" et dont le travail est "Designer".*/
SELECT *
FROM [Users]
WHERE birth_location IN ('London','Berlin')
AND job = 'Designer'

-- Sélectionnez les 10 utilisateurs avec les salaires les plus élevés.
SELECT TOP(10) *
FROM [Users]
ORDER BY salary DESC

-- Affichez les noms, prénoms et âges des utilisateurs nés entre 1980 et 1990.
SELECT first_name, last_name, age
FROM [Users]
WHERE YEAR(birth_date) IN (1980,1990)

-- Sélectionnez les utilisateurs par ordre décroissant d'âge.
SELECT *
FROM [Users]
ORDER BY age DESC

/*Sélectionnez les utilisateurs
dont le travail est "Doctor" et dont le salaire est supérieur à 3000.*/
SELECT *
FROM [Users]
WHERE salary > 3000
AND job = 'Doctor'

-- Affichez les utilisateurs triés par lieu de naissance, puis par salaire.
SELECT *
FROM [Users]
ORDER BY birth_location,salary

-- Sélectionnez les utilisateurs nés à Paris et dont le travail est "Lawyer".
SELECT *
FROM [Users]
WHERE birth_location = 'Paris'
AND job = 'Lawyer'

-- Affichez le salaire le plus bas de tout les utilisateurs en utilisant un alias.
SELECT MIN(salary) as min_salary
FROM [Users]

/*Sélectionnez les utilisateurs
nés après l'année 1985 et dont le travail est "Engineer".*/
SELECT *
FROM [Users]
WHERE YEAR(birth_date) > 1985
AND job = 'Engineer'

-- Affichez les utilisateurs dont le prénom est "John" et le nom de famille est "Doe".
SELECT *
FROM [Users]
WHERE first_name = 'John'
AND last_name = 'Doe'

/*Sélectionnez les 6 utilisateurs
dont le salaire est le plus bas en omettant les trois premiers résultats.*/
SELECT *
FROM [Users]
ORDER BY salary
OFFSET 3 ROWS
FETCH NEXT 6 ROWS ONLY

/*Affichez les utilisateurs par ordre croissant d'âge, limités aux 5 premiers.*/
SELECT TOP(5) *
FROM [Users]
ORDER BY age