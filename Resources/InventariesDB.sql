-- Inventaries.dbo.Category definition

-- Drop table

-- DROP TABLE Inventaries.dbo.Category;
CREATE DATABASE Inventaries;

GO

-- Inventaries.dbo.Category definition

-- Drop table

-- DROP TABLE Inventaries.dbo.Category;

CREATE TABLE Inventaries.dbo.Category (
	Id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Name varchar(30) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Description varchar(500) COLLATE Modern_Spanish_CI_AS NULL,
	Status bit DEFAULT 1 NULL,
	CONSTRAINT Category_PK PRIMARY KEY (Id),
	CONSTRAINT Category_UN UNIQUE (Name)
);


-- Inventaries.dbo.Customer definition

-- Drop table

-- DROP TABLE Inventaries.dbo.Customer;

CREATE TABLE Inventaries.dbo.Customer (
	Id varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Name varchar(50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Address varchar(100) COLLATE Modern_Spanish_CI_AS NULL,
	Phone varchar(15) COLLATE Modern_Spanish_CI_AS NULL,
	Email varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT Customer_PK PRIMARY KEY (Id)
);


-- Inventaries.dbo.Bill definition

-- Drop table

-- DROP TABLE Inventaries.dbo.Bill;

CREATE TABLE Inventaries.dbo.Bill (
	Customer varchar(15) COLLATE Modern_Spanish_CI_AS NOT NULL,
	CreationDate date NOT NULL,
	ExpirationDate date NOT NULL,
	Total decimal(18,2) NOT NULL,
	Id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	CONSTRAINT Bill_PK PRIMARY KEY (Id),
	CONSTRAINT Bill_FK FOREIGN KEY (Customer) REFERENCES Inventaries.dbo.Customer(Id)
);


-- Inventaries.dbo.Product definition

-- Drop table

-- DROP TABLE Inventaries.dbo.Product;

CREATE TABLE Inventaries.dbo.Product (
	Id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Name varchar(50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Description varchar(500) COLLATE Modern_Spanish_CI_AS NULL,
	Category varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Price decimal(18,2) NOT NULL,
	Stock int NOT NULL,
	Status bit DEFAULT 1 NOT NULL,
	CONSTRAINT Product_PK PRIMARY KEY (Id),
	CONSTRAINT Product_FK FOREIGN KEY (Category) REFERENCES Inventaries.dbo.Category(Id)
);


-- Inventaries.dbo.[Transaction] definition

-- Drop table

-- DROP TABLE Inventaries.dbo.[Transaction];

CREATE TABLE Inventaries.dbo.[Transaction] (
	Id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Bill varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Product varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Units int NOT NULL,
	Subtotal decimal(18,2) NOT NULL,
	CONSTRAINT Transaction_PK PRIMARY KEY (Id),
	CONSTRAINT Transaction_UN UNIQUE (Bill,Product),
	CONSTRAINT Transaction_FK FOREIGN KEY (Bill) REFERENCES Inventaries.dbo.Bill(Id),
	CONSTRAINT Transaction_FK_1 FOREIGN KEY (Product) REFERENCES Inventaries.dbo.Product(Id)
);