create table Categories(
	CategoryID bigint primary key identity(1,1),
	CategoryName varchar(50)
)GO

create table Brands(
	BrandID bigint primary key identity(1,1),
	BrandName varchar(50)
)GO	

create table Products(
	ProductID bigint primary key identity(1,1),
	ProductName varchar(50),
	Price decimal(15,2),
	DateOfPurchase datetime,
	AvailabilityStatus varchar(50),
	CategoryID bigint references Categories(CategoryID) on delete set null,
	BrandID bigint references Brands(BrandID) on delete set null,
	Active bit default(1)
)GO	

insert into Categories values ('Electronrics'), ('Home Appliances')

insert into Brands values ('Samsung'), ('Iphone'), ('Sony'), ('HP')

insert into Products values ('Samsung Galaxy S10', 84290, '2018-7-1', 'InStock', 1, 1, 1), 
							('Samsung Refrigerator', 27000, '2016-6-15', 'OutOdStock', 2, 1, 1), 
							('Iphone X', 99999, '2018-6-10', 'InStock', 1, 2, 1), 
							('HP Laptop', 34700, '2018-3-4', 'InStock', 1, 4, 1), 
							('Sony Home Theatre 5.1', 87000, '2017-5-18', 'InStock', 1, 3, 1), 
							('Sony Bravia 40 LED', 67000, '2018-7-19', 'InStock', 2, 3, 1)

Select * from Products