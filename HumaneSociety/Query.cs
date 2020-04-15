using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {        
        static HumaneSocietyDataContext db;

        static Query()
        {
            db = new HumaneSocietyDataContext();
        }

        internal static List<USState> GetStates()
        {
            List<USState> allStates = db.USStates.ToList();       

            return allStates;
        }
            
        internal static Client GetClient(string userName, string password)
        {
            Client client = db.Clients.Where(c => c.UserName == userName && c.Password == password).Single();

            return client;
        }

        internal static List<Client> GetClients()
        {
            List<Client> allClients = db.Clients.ToList();

            return allClients;
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int stateId)
        {
            Client newClient = new Client();

            newClient.FirstName = firstName;
            newClient.LastName = lastName;
            newClient.UserName = username;
            newClient.Password = password;
            newClient.Email = email;

            Address addressFromDb = db.Addresses.Where(a => a.AddressLine1 == streetAddress && a.Zipcode == zipCode && a.USStateId == stateId).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if (addressFromDb == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = streetAddress;
                newAddress.City = null;
                newAddress.USStateId = stateId;
                newAddress.Zipcode = zipCode;                

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                addressFromDb = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            newClient.AddressId = addressFromDb.AddressId;

            db.Clients.InsertOnSubmit(newClient);

            db.SubmitChanges();
        }

        internal static void UpdateClient(Client clientWithUpdates)
        {
            // find corresponding Client from Db
            Client clientFromDb = null;

            try
            {
                clientFromDb = db.Clients.Where(c => c.ClientId == clientWithUpdates.ClientId).Single();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("No clients have a ClientId that matches the Client passed in.");
                Console.WriteLine("No update have been made.");
                return;
            }
            
            // update clientFromDb information with the values on clientWithUpdates (aside from address)
            clientFromDb.FirstName = clientWithUpdates.FirstName;
            clientFromDb.LastName = clientWithUpdates.LastName;
            clientFromDb.UserName = clientWithUpdates.UserName;
            clientFromDb.Password = clientWithUpdates.Password;
            clientFromDb.Email = clientWithUpdates.Email;

            // get address object from clientWithUpdates
            Address clientAddress = clientWithUpdates.Address;

            // look for existing Address in Db (null will be returned if the address isn't already in the Db
            Address updatedAddress = db.Addresses.Where(a => a.AddressLine1 == clientAddress.AddressLine1 && a.USStateId == clientAddress.USStateId && a.Zipcode == clientAddress.Zipcode).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if(updatedAddress == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = clientAddress.AddressLine1;
                newAddress.City = null;
                newAddress.USStateId = clientAddress.USStateId;
                newAddress.Zipcode = clientAddress.Zipcode;                

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                updatedAddress = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            clientFromDb.AddressId = updatedAddress.AddressId;
            
            // submit changes
            db.SubmitChanges();
        }
        
        internal static void AddUsernameAndPassword(Employee employee)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();

            employeeFromDb.UserName = employee.UserName;
            employeeFromDb.Password = employee.Password;

            db.SubmitChanges();
        }

        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.Email == email && e.EmployeeNumber == employeeNumber).FirstOrDefault();

            if (employeeFromDb == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                return employeeFromDb;
            }
        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            Employee employeeFromDb = db.Employees.Where(e => e.UserName == userName && e.Password == password).FirstOrDefault();

            return employeeFromDb;
        }

        internal static bool CheckEmployeeUserNameExist(string userName)
        {
            Employee employeeWithUserName = db.Employees.Where(e => e.UserName == userName).FirstOrDefault();

            return employeeWithUserName != null;
        }


        //// TODO Items: ////
        
        // TODO: Allow any of the CRUD operations to occur here
        internal static void RunEmployeeQueries(Employee employee, string crudOperation)
        {
            switch (crudOperation)
            {
                case "create":
                    db.Employees.InsertOnSubmit(employee);
                    db.SubmitChanges();
                    return;
                case "read":
                    Employee employeeFromDb = db.Employees.Where(e => e.EmployeeNumber == employee.EmployeeNumber).FirstOrDefault();
                    if(employeeFromDb == null)
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        UserInterface.DisplayEmployeeInfo(employeeFromDb);
                    }
                    return;
                case "update":
                    Employee employeeToUpdate = null;
                    try
                    {
                        employeeToUpdate = db.Employees.Where(e => e.EmployeeNumber == employee.EmployeeNumber).FirstOrDefault();
                    }
                    catch(InvalidOperationException)
                    {
                        Console.WriteLine("There is no employee with that employee number");
                        Console.WriteLine("No changes were made");
                        return;
                    }
                    employeeToUpdate.FirstName = employee.FirstName;
                    employeeToUpdate.LastName = employee.LastName;
                    employeeToUpdate.Email = employee.Email;
                    db.SubmitChanges();
                    return;
                case "delete":
                    var employeeToDelete = db.Employees.Where(e => e.EmployeeNumber == employee.EmployeeNumber && 
                    e.LastName == employee.LastName).FirstOrDefault();
                    db.Employees.DeleteOnSubmit(employeeToDelete);
                    db.SubmitChanges();
                    return;
            }
        }

        // TODO: Animal CRUD Operations
        internal static void AddAnimal(Animal animal)
        {
            db.Animals.InsertOnSubmit(animal);
            db.SubmitChanges();
        }

        internal static Animal GetAnimalByID(int id)
        {
            Animal animal = db.Animals.Where(c => c.AnimalId == id).FirstOrDefault();
            return animal;
        }

        internal static void UpdateAnimal(int animalId, Dictionary<int, string> updates)
        {            
            throw new NotImplementedException();
        }

        internal static void RemoveAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
        
        // TODO: Animal Multi-Trait Search
        internal static IQueryable<Animal> SearchForAnimalsByMultipleTraits(Dictionary<int, string> updates) // parameter(s)?
        {

            IQueryable<Animal> animals = db.Animals;

            foreach(KeyValuePair<int, string> trait in updates)
            {
                animals = FilterAnimals(animals, trait);
            }
            return animals;
        }
        public static IQueryable<Animal> FilterAnimals(IQueryable<Animal> animals, KeyValuePair<int, string> trait)
        {
            var filteredAnimals = animals;
            
            switch (trait.Key)
            {
                case 1:
                    filteredAnimals = animals.Where(x => x.Category.Name == trait.Value);
                    break;
                case 2:
                    filteredAnimals = animals.Where(x => x.Name == trait.Value);
                    break;
                case 3:
                    filteredAnimals = animals.Where(x => x.Age.ToString() == trait.Value);
                    break;
                case 4:
                    filteredAnimals = animals.Where(d => d.Demeanor == trait.Value);
                    break;
                case 5:
                     bool kidFriendly;
                        if (trait.Value.ToUpper() == "YES" || trait.Value.ToUpper() == "Y")
                        {
                            kidFriendly = true;
                        }
                        else
                        {
                            kidFriendly = false;
                        }
                        filteredAnimals = db.Animals.Where(k => k.KidFriendly == kidFriendly);
                    break;
                case 6:
                    bool petFriendly;
                        if (trait.Value.ToUpper() == "YES" || trait.Value == "Y")
                        {
                            petFriendly = true;
                        }
                        else
                        {
                            petFriendly = false;
                        }
                        filteredAnimals = db.Animals.Where(k => k.KidFriendly == petFriendly);
                    break;
                case 7:
                    filteredAnimals = db.Animals.Where(w => w.Weight.ToString() == trait.Value);
                    break;
                case 8:
                    filteredAnimals = db.Animals.Where(i => i.AnimalId.ToString() == trait.Value);
                    break;
                default:
                    break;
            }
            return filteredAnimals;
        }
        // TODO: Misc Animal Things
        internal static int GetCategoryId(string categoryName)
        {
            var category = db.Categories.Where(c => c.Name == categoryName).FirstOrDefault();
            return category.CategoryId;
        }
        
        internal static Room GetRoom(int animalId)
        {
            Room room = new Room();
            room = db.Rooms.Where(x => x.AnimalId == animalId).SingleOrDefault();
            return room;
        }
        
        internal static int GetDietPlanId(string dietPlanName)
        {
            var dietPlan = db.DietPlans.Where(d => d.Name == dietPlanName).FirstOrDefault();
            return dietPlan.DietPlanId;
        }

        // TODO: Adoption CRUD Operations
        internal static void Adopt(Animal animal, Client client)
        {
            Adoption adoption = new Adoption()
            {
                AnimalId = animal.AnimalId,
                ClientId = client.ClientId,
                ApprovalStatus = "Pending",
                AdoptionFee = 75,
                PaymentCollected = false
            };
            db.Adoptions.InsertOnSubmit(adoption);
            db.SubmitChanges();
        }
   
        internal static IQueryable<Adoption> GetPendingAdoptions()
        {
            IQueryable<Adoption> adoptions = db.Adoptions;
            return adoptions;
        }

        internal static void UpdateAdoption(bool isAdopted, Adoption adoption)
        {
            throw new NotImplementedException();
        }

        internal static void RemoveAdoption(int animalId, int clientId)
        {
            throw new NotImplementedException();
        }

        // TODO: Shots Stuff
        internal static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateShot(string shotName, Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}