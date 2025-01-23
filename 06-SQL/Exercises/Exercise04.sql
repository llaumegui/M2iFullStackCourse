-- 1. Sélectionnez tous les enregistrements où le métier est "Engineer"
SELECT *
FROM [Users]
WHERE birth_location IN ('New York');

/* 2. Sélectionnez les prénoms et les noms de famille des utilisateurs
nés à Londres, Paris ou Berlin*/
SELECT first_name,last_name
FROM [Users]
WHERE birth_location IN ('London','Paris','Berlin');

/* 3. Sélectionnez les utilisateurs dont l'âge est compris entre 25 et 35
ans*/
SELECT *
FROM [Users]
WHERE age BETWEEN 25 AND 36;

/* 4. Sélectionnez les utilisateurs qui sont à la fois des développeurs et
dont le salaire est supérieur à 2500€*/
SELECT *
FROM [Users]
WHERE job = 'Developer' AND salary >2500;