-- Niveau 1 : Questions basiques
-- Sélectionnez tous les chiens avec leur nom, leur race et leur poids.
SELECT name, breed, weight
FROM [Chien];

-- Listez tous les propriétaires (prénom et nom).
SELECT first_name, last_name
FROM [Personne];

-- Récupérez les chiens qui n'ont pas de maître.
SELECT *
FROM [Chien]
WHERE owner_id = NULL;

-- Sélectionnez tous les chiens de race "Labrador".
SELECT *
FROM [Chien]
WHERE breed = 'Labrador';

-- Niveau 2 : Jointures simples (INNER JOIN)
-- Affichez le nom des chiens avec le prénom et le nom de leur maître.
SELECT c.name, p.first_name, p.last_name
FROM [Personne] AS p
    INNER JOIN [Chien] AS c
    ON p.id = c.owner_id;

-- Récupérez les maîtres qui possèdent un chien pesant plus de 20 kg
SELECT p.first_name, p.last_name
FROM [Personne] AS p
    INNER JOIN [Chien] AS c
    ON p.id = c.owner_id
WHERE c.weight>20;

-- Niveau 3 : LEFT JOIN
/* Affichez tous les propriétaires et les chiens qu'ils possèdent,
y compris les propriétaires sans chien.*/
SELECT *
FROM [Personne]
    LEFT JOIN [Chien]
    ON Personne.id = Chien.owner_id;

/*Listez tous les chiens, avec leurs maîtres s'ils en ont,
sinon affichez "No Owner".*/
SELECT
    c.name, c.breed,
    COALESCE(p.first_name,'No Owner') AS owner_first_name,
    COALESCE(p.last_name,'No Owner') AS owner_last_name
FROM [Chien] AS c
    LEFT JOIN [Personne] AS p
    ON c.owner_id = p.id;

-- Niveau 4 : FULL OUTER JOIN
-- Récupérez tous les chiens et tous les maîtres, même ceux sans correspondance.
SELECT *
FROM [Chien] AS c
    FULL JOIN [Personne] AS p
    ON p.id = c.owner_id

-- Niveau 5 : Filtrage avancé
-- Affichez les chiens dont le poids est supérieur à 10 kg mais inférieur à 30 kg.
SELECT *
FROM [Chien] AS c
WHERE weight IN (10,30)

-- Récupérez les chiens de maîtres habitant dans la ville "123 Main Street".
SELECT c.name, p.address
FROM [Chien] AS c
LEFT JOIN [Personne] AS p
ON p.id = c.owner_id
WHERE p.address = '123 Main Street'

-- Niveau 6 : Agrégats et GROUP BY
-- Affichez le nombre de chiens pour chaque maître.
SELECT p.first_name, COUNT(*) AS nbr_dogs FROM [Chien] c
INNER JOIN [Personne] AS p
ON p.id = c.owner_id
GROUP BY p.first_name


-- Calculez le poids total des chiens appartenant à chaque maître.
SELECT p.first_name, SUM(c.weight) AS dog_weights FROM [Chien] c
INNER JOIN [Personne] AS p
ON p.id = c.owner_id
GROUP BY p.first_name

-- Niveau 7 : Sous-requêtes
-- Récupérez les maîtres qui possèdent le chien le plus lourd.

-- Affichez les chiens qui ont un maître dont l'âge est supérieur à 40 ans.