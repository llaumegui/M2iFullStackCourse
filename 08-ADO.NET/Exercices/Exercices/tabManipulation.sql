CREATE TABLE student
(
    id           INT IDENTITY (1,1) PRIMARY KEY,
    first_name   NVARCHAR(50) NOT NULL,
    last_name    NVARCHAR(50) NOT NULL,
    class        INT,
    date_diploma DATE
);

INSERT INTO student(first_name, last_name, class, date_diploma)
VALUES (
        'John','Doe','2','2017-08-01'
       )