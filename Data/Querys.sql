use [db-imprentaliberia]

drop table Users

CREATE TABLE Users
(
	Id bigint NOT NULL PRIMARY KEY,
    Name varchar(50),
    Lastname varchar(50),
    Email varchar(50),
    Password varchar(50) 
)

drop table Customers
drop table Orders

CREATE TABLE Customers
(
	Id bigint NOT NULL PRIMARY KEY,
	Name varchar(50),
	Telephone1 int,
	Telephone2 int,
	Email varchar(50),
	Address text
)

CREATE TABLE Orders
(
	Number int NOT NULL PRIMARY KEY,
	DateOrder date,
	CustomerID bigint NOT NULL FOREIGN KEY REFERENCES Customers(Id),
	DateDelivery date,
	DeliveredBy varchar(50),
	WorkType text,
	Computer text,
	Iron bit,
	Paper bit,
	Quantity varchar(25),
	Ink varchar(25),
	Sheets varchar(25),
	Trait1 varchar(25),
	Trait2 varchar(25),
	Trait3 varchar(25),
	Trait4 varchar(25),
	Trait5 varchar(25),
	Trait6 varchar(25),
	Size varchar(50),
	Glued bit,
	Perforated bit,
	Changes bit,
	Holes bit,
	InitialNum int,
	EndNum int,
	Observations text,
	NameDesign varchar(50),
	Design image,
	Price float,
	Payment float,
	Balance float
)



insert into Customers(Id, Name, Telephone1, Telephone2, Email)values(1, 'Cliente', 60435201, 0,  'cliente@gmail.com')