-- Quel est le salaire minimum parmi tous les utilisateurs ?
SELECT MIN(salary) as min_salary
FROM [Users];

/*Quel est l'âge maximum parmi les utilisateurs ayant le métier
"Engineer" ?*/
SELECT MAX(age) as max_age
FROM [Users]
WHERE job = 'Engineer';

/*Trouvez le salaire moyen des utilisateurs dont le métier est
"Teacher".*/
SELECT AVG(salary) as avg_salary_teacher
FROM [Users]
WHERE job = 'Teacher';

-- Trouvez le montant total des salaires de tous les utilisateurs.
SELECT SUM(salary) as sum_salary
FROM [Users];