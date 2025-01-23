/*Dans une première requête, récupérez tous les utilisateurs dont le
métier n'est pas développeur*/
SELECT *
FROM Users
WHERE job != 'Developer';

/*Dans une seconde requête, récupérez tous les utilisateurs dont le
prénom est John.*/
SELECT *
FROM Users
WHERE first_name = 'John';

/*Dans une dernière requête, récupérez tous les utilisateurs dont le
salaire est supérieur ou égal à 3000.*/
SELECT *
FROM Users
WHERE salary>=3000;