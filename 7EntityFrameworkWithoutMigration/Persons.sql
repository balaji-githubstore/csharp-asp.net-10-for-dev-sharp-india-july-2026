CREATE TABLE Persons (
  PersonID int PRIMARY KEY,
  LastName varchar(255) NOT NULL,
  FirstName varchar(255),
  Address varchar(255),
  City varchar(255)
);

-- Insert 5 records
INSERT INTO Persons (PersonID, LastName, FirstName, Address, City)
VALUES
(1, 'Doe', 'John', '123 Main St', 'New York'),
(2, 'Smith', 'Jane', '456 Oak Ave', 'Los Angeles'),
(3, 'Johnson', 'Robert', '789 Pine Rd', 'Chicago'),
(4, 'Williams', 'Mary', '321 Elm St', 'Houston'),
(5, 'Brown', 'Michael', '654 Maple Dr', 'Phoenix');
