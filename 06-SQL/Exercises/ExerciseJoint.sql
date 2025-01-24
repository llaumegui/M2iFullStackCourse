-- SELECT *
-- FROM [Clients];
-- SELECT *
-- FROM [Purchases];

-- INNER JOIN
/*Sélectionnez les noms et prénoms des clients ainsi que les détails
de leurs achats (si disponibles)*/
SELECT c.first_name, c.last_name, p.product,p.amount 
FROM [Clients] AS c
INNER JOIN [Purchases] AS p
ON c.id = p.client_id

-- LEFT JOIN
/*Sélectionnez tous les clients et les détails de leurs achats s'ils ont
effectué des achats, sinon affichez les colonnes des achats avec des
valeurs NULL*/
SELECT *
FROM [Clients]AS c
LEFT JOIN [Purchases] AS p
ON c.id = p.client_id

-- RIGHT JOIN
SELECT *
FROM [Clients] AS c
RIGHT JOIN [Purchases] AS p
ON c.id = p.client_id
