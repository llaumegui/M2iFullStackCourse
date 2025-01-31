CREATE TABLE student
(
    id           INT IDENTITY (1,1) PRIMARY KEY,
    first_name   NVARCHAR(50) NOT NULL,
    last_name    NVARCHAR(50) NOT NULL,
    class        INT,
    date_diploma DATE
);

INSERT INTO student(first_name, last_name, class, date_diploma)
VALUES ('John', 'Doe', '2', '2017-08-01')

CREATE TABLE clients
(
    id         INT IDENTITY (1,1) PRIMARY KEY,
    first_name NVARCHAR(50)  NOT NULL,
    last_name  NVARCHAR(50)  NOT NULL,
    adress     NVARCHAR(100) NOT NULL,
    postalCode NVARCHAR(10)  NOT NULL,
    city       NVARCHAR(50)  NOT NULL,
    telephone  NVARCHAR(50)  NOT NULL,
)

EXEC sp_rename 'client','clients';
EXEC sp_rename 'dbo.clients.postalCode','postal_code', 'COLUMN';

CREATE TABLE commands
(
    id        INT IDENTITY (1,1) PRIMARY KEY,
    client_id INT,
    date      DATE,
    total     DECIMAL,
    CONSTRAINT FK_ClientId FOREIGN KEY (client_id)
        REFERENCES client (id)
);