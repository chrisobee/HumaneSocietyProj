USE HumaneSociety

GO
INSERT INTO Categories (Name)
VALUES ('Dogs')
INSERT INTO Categories (Name)
VALUES ('Cats')
INSERT INTO Categories (Name)
VALUES ('Small Animals')
INSERT INTO Categories (Name)
VALUES ('Birds')
INSERT INTO Categories (Name)
VALUES ('Reptiles')
GO

GO
INSERT INTO DietPlans (Name, FoodType, FoodAmountInCups)
VALUES('Science Diet', 'Dog Food', 4)
INSERT INTO DietPlans (Name, FoodType, FoodAmountInCups)
VALUES('Meow Mix', 'Cat Food', 2)
INSERT INTO DietPlans (Name, FoodType, FoodAmountInCups)
VALUES('Veggies', 'Small Animal Food', 1)
INSERT INTO DietPlans (Name, FoodType, FoodAmountInCups)
VALUES('Seeds', 'Bird Food', 1)
INSERT INTO DietPlans (Name, FoodType, FoodAmountInCups)
VALUES('Insects', 'Reptile Food', 1)
GO

GO
INSERT INTO Addresses

GO 
INSERT INTO Employees (FirstName, LastName, UserName, Password, EmployeeNumber, Email)
VALUES ('Chris', 'Vaughn', 'CJV2000', 1234, 1, 'cjv20@gmail.com')
INSERT INTO Employees (FirstName, LastName, UserName, Password, EmployeeNumber, Email)
VALUES ('Frank', 'Bednarczyk', 'FSB1997', 5678, 2, 'fsb97@gmail.com')
INSERT INTO Employees (FirstName, LastName, UserName, Password, EmployeeNumber, Email)
VALUES ('Jack', 'Whitley', 'JCW2000', 9101112, 3, 'jcw20@gmail.com')
INSERT INTO Employees (FirstName, LastName, UserName, Password, EmployeeNumber, Email)
VALUES ('Chris', 'OBrien', 'CJO2000', 13141516, 4, 'cjo20@gmail.com')
INSERT INTO Employees (FirstName, LastName, UserName, Password, EmployeeNumber, Email)
VALUES ('Austin', 'Moen', 'ADM2000', 17181920, 5, 'adm20@gmail.com')
GO
INSERT INTO Addresses (AddressLine1, City, USStateId, Zipcode)
VALUES ('1234 Gamer St.', 'King City', 14, 46018)
INSERT INTO Addresses (AddressLine1, City, USStateId, Zipcode)
VALUES ('5678 KPop Ave.', 'Detroit', 22, 48127)
INSERT INTO Addresses (AddressLine1, City, USStateId, Zipcode)
VALUES ('4444 Fable Dr.', 'Detroit', 22, 48127)
INSERT INTO Addresses (AddressLine1, City, USStateId, Zipcode)
VALUES ('8888 Citrus Dr.', 'Muskego', 49, 53150)
INSERT INTO Addresses (AddressLine1, City, USStateId, Zipcode)
VALUES ('1111 Harvard Circle', 'New York', 32, 10002)
GO

GO
INSERT INTO Clients (FirstName, LastName, UserName, Password, AddressId, Email)
VALUES ('Lynda', 'Hinojosa', 'CjIqT20', 20191817, 1, 'lmv20@gmail.com')
INSERT INTO Clients (FirstName, LastName, UserName, Password, AddressId, Email)
VALUES ('Jess', 'Dahmer', 'AmIqT20', 16151413, 2, 'jdm20@gmail.com')
INSERT INTO Clients (FirstName, LastName, UserName, Password, AddressId, Email)
VALUES ('Aaron', 'Marcus', 'JdIqT20', 1211109, 3, 'am20@gmail.com')
INSERT INTO Clients (FirstName, LastName, UserName, Password, AddressId, Email)
VALUES ('Shannon', 'Schwartz', 'CjIqT20', 8765, 4, 'sls20@gmail.com')
INSERT INTO Clients (FirstName, LastName, UserName, Password, AddressId, Email)
VALUES ('Ben', 'Dickens', 'ben20', 4321, 5, 'bnd20@gmail.com')
GO

GO
INSERT INTO Animals (Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus, CategoryId, DietPlanId, EmployeeId)
VALUES ('Apyr', 120, 5, 'Life of the Party', 1, 0, 'Male', 'Waiting for Furever Home', 1, 1, 1)
INSERT INTO Animals (Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus, CategoryId, DietPlanId, EmployeeId)
VALUES ('Grovetender', 8, 2, 'Clingy', 0, 0, 'Female', 'Fostered', 2, 2, 2)
INSERT INTO Animals (Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus, CategoryId, DietPlanId, EmployeeId)
VALUES ('Imp', 2, 1, 'Nervous', 1, 0, 'Male', 'Awaiting Adoption Details', 3, 3, 3)
INSERT INTO Animals (Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus, CategoryId, DietPlanId, EmployeeId)
VALUES ('Jelly', 1, 8, 'Needs Some Warming Up To', 0, 0, 'Female', 'Looking for Some Lovin''', 4, 4, 4)
INSERT INTO Animals (Name, Weight, Age, Demeanor, KidFriendly, PetFriendly, Gender, AdoptionStatus, CategoryId, DietPlanId, EmployeeId)
VALUES ('Newt', 1, 3, 'Likes to Kick It', 1, 1, 'Male', 'Waiting for New Home', 5, 5, 5)
GO

GO
INSERT INTO Rooms (RoomNumber, AnimalId)
VALUES (1, 1)
INSERT INTO Rooms (RoomNumber, AnimalId)
VALUES (2, 2)
INSERT INTO Rooms (RoomNumber, AnimalId)
VALUES (3, 3)
INSERT INTO Rooms (RoomNumber, AnimalId)
VALUES (4, 4)
INSERT INTO Rooms (RoomNumber, AnimalId)
VALUES (5, 5)
INSERT INTO Rooms (RoomNumber, AnimalId)
VALUES (6, null)
INSERT INTO Rooms (RoomNumber, AnimalId)
VALUES (7, null)
INSERT INTO Rooms (RoomNumber, AnimalId)
VALUES (8, null)
INSERT INTO Rooms (RoomNumber, AnimalId)
VALUES (9, null)
INSERT INTO Rooms (RoomNumber, AnimalId)
VALUES (10, null)
GO

