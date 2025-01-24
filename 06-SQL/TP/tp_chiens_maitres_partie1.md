## Script SQL : Création des tables **Personne** et **Chien**

Voici le script SQL pour créer les tables **Personne** et **Chien**, avec une relation `One-to-Many` (un chien peut avoir un maître, mais ce n'est pas obligatoire) :

```sql
-- Création de la table Personne
CREATE TABLE Personne (
    id INT PRIMARY KEY IDENTITY(1,1),     -- Identifiant unique
    first_name NVARCHAR(50) NOT NULL,     -- Prénom
    last_name NVARCHAR(50) NOT NULL,      -- Nom
    age INT NOT NULL,                     -- Âge
    phone_number NVARCHAR(20),            -- Numéro de téléphone
    address NVARCHAR(100)                 -- Adresse
);

-- Création de la table Chien
CREATE TABLE Chien (
    id INT PRIMARY KEY IDENTITY(1,1),     -- Identifiant unique
    name NVARCHAR(50) NOT NULL,           -- Nom du chien
    breed NVARCHAR(50),                   -- Race
    age INT,                              -- Âge
    size DECIMAL(5,2),                    -- Taille (en cm)
    weight DECIMAL(5,2),                  -- Poids (en kg)
    id_maitre INT NULL,                   -- Identifiant du maître (clé étrangère)
    CONSTRAINT FK_Personne_Chien FOREIGN KEY (id_maitre) REFERENCES Personne(id)
);
```

---

## Données initiales pour les tables **Personne** et **Chien**

Voici un jeu de données réaliste et varié pour démontrer les jointures.

```sql
-- Insertion de données dans la table Personne
INSERT INTO Personne (first_name, last_name, age, phone_number, address)
VALUES 
    ('Tintin', 'Dupont', 30, '1234567890', '123 Rue du Temple'),
    ('Asterix', 'Gaulois', 40, '9876543210', '456 Village Gaulois'),
    ('Sherlock', 'Holmes', 45, '5554443333', '221B Baker Street'),
    ('Hercule', 'Poirot', 50, '4443332222', '11 Rue du Luxembourg'),
    ('Gandalf', 'Le Gris', 1000, '1112223333', 'Hobbiton'),
    ('Luke', 'Skywalker', 28, '9988776655', 'Tatooine'),
    ('Harry', 'Potter', 35, '5556667777', '4 Privet Drive'),
    ('Daenerys', 'Targaryen', 32, '8887776666', 'Meereen'),
    ('Frodo', 'Baggins', 33, '1237894560', 'Bag End'),
    ('Waldo', 'Rosenbaum', 50, '7778889999', 'Nowhere Street');

-- Insertion de données dans la table Chien
INSERT INTO Chien (name, breed, age, size, weight, id_maitre)
VALUES 
    ('Milou', 'Fox Terrier', 5, 30.0, 8.0, 1), -- Lié à Tintin Dupont
    ('Idefix', 'Dogmatix', 4, 25.0, 6.0, 2), -- Lié à Asterix Gaulois
    ('Watson', 'Bulldog', 6, 60.0, 30.0, 3), -- Lié à Sherlock Holmes
    ('Hercules', 'Pitbull', 3, 60.0, 28.0, 4), -- Lié à Hercule Poirot
    ('Gandalf', 'Great Dane', 8, 80.0, 50.0, 5), -- Lié à Gandalf Le Gris
    ('Chewie', 'Malamute', 7, 70.0, 40.0, 6), -- Lié à Luke Skywalker
    ('Buck', 'Saint Bernard', 6, 70.0, 50.0, 7), -- Lié à Harry Potter
    ('Drogo', 'Dobermann', 5, 55.0, 35.0, 8), -- Lié à Daenerys Targaryen
    ('Baggins', 'Shiba Inu', 4, 30.0, 10.0, 9), -- Lié à Frodo Baggins
    ('Waldo', 'Chihuahua', 3, 20.0, 2.5, 10), -- Lié à Waldo Rosenbaum
    ('Rex', 'Chihuahua', 3, 20.0, 3.0, NULL), -- Pas de maître
    ('Pepette', 'Rottweiler', 6, 60.0, 40.0, NULL), -- Pas de maître
    ('Princesse', 'Dobermann', 4, 50.0, 30.0, NULL), -- Pas de maître
    ('Rex', 'Dalmatian', 2, 45.0, 25.0, NULL), -- Pas de maître
    ('Trixie', 'Poodle', 5, 30.0, 12.0, NULL), -- Pas de maître
    ('Nina', 'Boxer', 4, 50.0, 35.0, NULL), -- Pas de maître
    ('Pikachu', 'Corgi', 2, 25.0, 10.0, NULL), -- Pas de maître
    ('Rolo', 'Dachshund', 3, 28.0, 8.5, NULL), -- Pas de maître
    ('Fifi', 'Maltese', 4, 25.0, 6.0, NULL), -- Pas de maître
    ('Charlie', 'Beagle', 6, 40.0, 15.0, NULL), -- Pas de maître
    ('Max', 'Labrador', 5, 55.0, 30.0, NULL), -- Pas de maître
    ('Biscuit', 'Shih Tzu', 2, 25.0, 6.0, NULL), -- Pas de maître
    ('Daisy', 'Pug', 3, 35.0, 10.0, NULL), -- Pas de maître
    ('Oscar', 'Terrier', 4, 28.0, 8.0, NULL), -- Pas de maître
    ('Nala', 'Pitbull', 4, 50.0, 30.0, NULL); -- Pas de maître

```

---

## Questions

### Niveau 1 : Questions basiques
1. Sélectionnez tous les chiens avec leur nom, leur race et leur poids.
2. Listez tous les propriétaires (prénom et nom).
3. Récupérez les chiens qui n'ont pas de maître.
4. Sélectionnez tous les chiens de race "Labrador".

### Niveau 2 : Jointures simples (INNER JOIN)
5. Affichez le nom des chiens avec le prénom et le nom de leur maître.
6. Récupérez les maîtres qui possèdent un chien pesant plus de 20 kg.

### Niveau 3 : LEFT JOIN
7. Affichez tous les propriétaires et les chiens qu'ils possèdent, y compris les propriétaires sans chien.
8. Listez tous les chiens, avec leurs maîtres s'ils en ont, sinon affichez "No Owner".

### Niveau 4 : FULL OUTER JOIN
9. Récupérez tous les chiens et tous les maîtres, même ceux sans correspondance.

### Niveau 5 : Filtrage avancé
10. Affichez les chiens dont le poids est supérieur à 10 kg mais inférieur à 30 kg.
11. Récupérez les chiens de maîtres habitant dans la ville "123 Main St".

### Niveau 6 : Agrégats et GROUP BY
12. Affichez le nombre de chiens pour chaque maître.
13. Calculez le poids total des chiens appartenant à chaque maître.

### Niveau 7 : Sous-requêtes
14. Récupérez les maîtres qui possèdent le chien le plus lourd.
15. Affichez les chiens qui ont un maître dont l'âge est supérieur à 40 ans.

### Niveau 8 : Cas complexes
16. Listez les maîtres n'ayant pas de chien.
17. Affichez la race la plus courante parmi les chiens.
18. Listez tous les maîtres qui possèdent au moins deux chiens.

### Niveau 9 : FULL OUTER JOIN combiné
19. Récupérez une liste combinée de chiens sans maîtres et de maîtres sans chiens.
20. Affichez le maître et ses chien associés avec somme de leur tailles respectives (taille du maître et des chiens).
