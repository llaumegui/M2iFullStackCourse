CREATE TABLE Chat
(
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(50) NOT NULL,
    age INT,
    color VARCHAR(50) NOT NULL,
    owner_id INT,
    FOREIGN KEY (owner_id) REFERENCES Personne(id)
);

CREATE TABLE RelationCC
(
    id_cat INT,
    id_dog INT,
    relation_type NVARCHAR(50),
    CONSTRAINT check_type CHECK (relation_type IN ('loves','hates','neutral')),
    FOREIGN KEY (id_cat) REFERENCES Chat(id),
    FOREIGN KEY (id_dog) REFERENCES Chien(id)
);


SELECT *
FROM Personne;
SELECT *
FROM Chat;
SELECT *
FROM Chien;
SELECT *
FROM RelationCC;

INSERT INTO Chat
VALUES
    ('Garfield', 5, 'orange', 5),
    ('Salem', 7, 'black', 9);

