USE [master]
GO

IF db_id('ListMaker') IS NULL
  CREATE DATABASE [ListMaker]
GO

USE [ListMaker]
GO

DROP TABLE IF EXISTS [GroceryListItem];
DROP TABLE IF EXISTS [GroceryList];
DROP TABLE IF EXISTS [RecipeItem];
DROP TABLE IF EXISTS [Recipe];
DROP TABLE IF EXISTS [Item];
DROP TABLE IF EXISTS [StoreSection];
DROP TABLE IF EXISTS [User];

CREATE TABLE [User] (
  [Id] int PRIMARY KEY identity,
  [FirebaseId] nvarchar(255) not null,
  [FirstName] nvarchar(255) not null,
  [LastName] nvarchar(255) not null,
  [FullName] nvarchar(255) not null,
  [Email] nvarchar(255) not null,
  [RegisterDate] datetime not null
)
GO

CREATE TABLE [Recipe] (
  [Id] int PRIMARY KEY identity,
  [UserId] int not null,
  [Name] nvarchar(255) not null,
  [Notes] nvarchar(255),
  [DateCreated] datetime not null
)
GO

CREATE TABLE [RecipeItem] (
  [Id] int PRIMARY KEY identity,
  [RecipeId] int not null,
  [ItemId] int not null,
  [Quantity] float not null
)
GO

CREATE TABLE [Item] (
  [Id] int PRIMARY KEY identity,
  [UserId] int not null,
  [StoreSectionId] int not null,
  [Name] nvarchar(255) not null,
  [Notes] nvarchar(255),
  [DateCreated] datetime not null
)
GO

CREATE TABLE [GroceryListItem] (
  [Id] int PRIMARY KEY identity,
  [GroceryListId] int not null,
  [ItemId] int not null,
  [Quantity] float not null
)
GO

CREATE TABLE [GroceryList] (
  [Id] int PRIMARY KEY identity,
  [UserId] int not null,
  [Name] nvarchar(255) not null,
  [Notes] nvarchar(255),
  [DateShopping] date,
  [DateCreated] datetime not null,
  [IsOpen] bit
)
GO

CREATE TABLE [StoreSection] (
  [Id] int PRIMARY KEY identity,
  [Name] nvarchar(255) not null,
  [OrderPosition] int not null
)
GO

ALTER TABLE [Recipe] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [RecipeItem] ADD FOREIGN KEY ([RecipeId]) REFERENCES [Recipe] ([Id])
GO

ALTER TABLE [RecipeItem] ADD FOREIGN KEY ([ItemId]) REFERENCES [Item] ([Id])
GO

ALTER TABLE [Item] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [Item] ADD FOREIGN KEY ([StoreSectionId]) REFERENCES [StoreSection] ([Id])
GO

ALTER TABLE [GroceryList] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
GO

ALTER TABLE [GroceryListItem] ADD FOREIGN KEY ([GroceryListId]) REFERENCES [GroceryList] ([Id])
GO

ALTER TABLE [GroceryListItem] ADD FOREIGN KEY ([ItemId]) REFERENCES [Item] ([Id])
GO



-- STARTING DATA --

INSERT INTO [User] (FirebaseId,FirstName,LastName,FullName,Email,RegisterDate)
VALUES
  ('aaaaaaa','Mason','Wheaton','Mason Wheaton','mlwheaton06@yahoo.com','2023-12-03T09:19:44.000Z')
GO

INSERT INTO [StoreSection] ([Name],OrderPosition)
VALUES
	('Produce',1),
	('Deli/Bakery',2),
	('Meat/Poultry',3),
	('Cereal',4),
	('Baking/Condiments',5),
	('Pasta/Canned/Intl',6),
	('Chips/Crackers',7),
	('Paper products',8),
	('Bathroom',9),
	('Dairy',10),
	('Freezer',11),
	('Alt',12)
GO

INSERT INTO [Item] (UserId,StoreSectionId,[Name],Notes,DateCreated)
VALUES
  (1,3,'Chicken breast',null,'2023-12-03T09:19:44.000Z'),
  (1,12,'Cream cheese',null,'2023-12-03T09:19:44.000Z'),
  (1,1,'Cucumber',null,'2023-12-03T09:19:44.000Z'),
  (1,1,'Lettuce',null,'2023-12-03T09:19:44.000Z'),
  (1,6,'Tortilla shells',null,'2023-12-03T09:19:44.000Z'),
  (1,1,'Sauce for wrap',null,'2023-12-03T09:19:44.000Z'),
  (1,12,'Eggs',null,'2023-12-03T09:19:44.000Z'),
  (1,2,'Bagels',null,'2023-12-03T09:19:44.000Z'),
  (1,2,'Cheese (sliced)',null,'2023-12-03T09:19:44.000Z'),
  (1,3,'Bacon',null,'2023-12-03T09:19:44.000Z'),
  (1,5,'Mayonnaise',null,'2023-12-03T09:19:44.000Z'),
  (1,6,'Rice',null,'2023-12-03T09:19:44.000Z'),
  (1,1,'Shallot',null,'2023-12-03T09:19:44.000Z'),
  (1,5,'Soy sauce',null,'2023-12-03T09:19:44.000Z'),
  (1,5,'Sweet chili sauce',null,'2023-12-03T09:19:44.000Z'),
  (1,5,'Olive oil',null,'2023-12-03T09:19:44.000Z'),
  (1,6,'Pasta noodles',null,'2023-12-03T09:19:44.000Z'),
  (1,1,'Onion (yellow, medium)',null,'2023-12-03T09:19:44.000Z'),
  (1,6,'Whole canned peeled tomatoes (28oz)',null,'2023-12-03T09:19:44.000Z'),
  (1,1,'Garlic clove',null,'2023-12-03T09:19:44.000Z'),
  (1,1,'Squash (yellow)',null,'2023-12-03T09:19:44.000Z'),
  (1,12,'Butter (unsalted)',null,'2023-12-03T09:19:44.000Z'),
  (1,1,'Bell pepper (green)',null,'2023-12-03T09:19:44.000Z'),
  (1,5,'Sugar',null,'2023-12-03T09:19:44.000Z'),
  (1,1,'Basil',null,'2023-12-03T09:19:44.000Z')
GO

INSERT INTO [Recipe] (UserId,[Name],Notes,DateCreated)
VALUES
  (1,'Shredded Chicken Wrap',null,'2023-12-03T09:19:44.000Z'),
  (1,'Bacon, Egg, and Cheese Bagel',null,'2023-12-03T09:19:44.000Z'),
  (1,'Simple Egg Fried Rice',null,'2023-12-03T09:19:44.000Z'),
  (1,'Pasta With Vegetables',null,'2023-12-03T09:19:44.000Z')
GO

INSERT INTO [RecipeItem] (RecipeId,ItemId,Quantity)
VALUES
  (1,1,3),
  (1,2,1),
  (1,3,1),
  (1,4,1),
  (1,5,1),
  (1,6,1),
  (1,16,1),
  (2,7,1),
  (2,8,1),
  (2,9,1),
  (2,10,1),
  (2,11,1),
  (3,7,1),
  (3,12,1),
  (3,13,1),
  (3,14,1),
  (3,15,1),
  (4,17,1),
  (4,18,2),
  (4,19,2),
  (4,20,4),
  (4,21,1),
  (4,22,1),
  (4,23,2),
  (4,24,1),
  (4,25,1)
GO

INSERT INTO [GroceryList] (UserId,[Name],Notes,DateShopping,DateCreated,IsOpen)
VALUES
  (1,'2023/12/01',null,'2023-12-01','2023-12-01T09:19:44.000Z','0'),
  (1,'2023/12/02',null,'2023-12-02','2023-12-02T09:19:44.000Z','0'),
  (1,'Today',null,'2023-12-03','2023-12-03T09:19:44.000Z','1')
GO

INSERT INTO [GroceryListItem] (GroceryListId,ItemId,Quantity)
VALUES
  (1,1,1),
  (1,2,1),
  (1,3,1),
  (1,4,1),
  (1,5,2),
  (1,6,3),
  (1,10,1),
  (1,11,1),
  (1,12,2),
  (1,20,1),
  (2,20,1),
  (2,21,1),
  (2,22,1),
  (2,5,1),
  (2,6,1),
  (2,7,2),
  (2,18,2),
  (2,14,1),
  (2,13,1),
  (3,4,1),
  (3,3,1),
  (3,2,1),
  (3,1,2),
  (3,7,3),
  (3,18,1),
  (3,19,1),
  (3,20,1),
  (3,1,2),
  (3,23,1),
  (3,22,1)
GO