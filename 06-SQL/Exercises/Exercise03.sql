/*Créez une requête qui permet de récupérer toutes les personnes qui
sont nées à New York, dont le salaire est compris entre 3000 et 3500
(compris) et qui ne sont ni docteur ni avocat.*/
SELECT *
FROM [Users]
WHERE salary >= 3000 AND salary <= 3500
AND birth_location = 'New York'
AND NOT (job = 'Lawyer' OR job = 'Doctor');