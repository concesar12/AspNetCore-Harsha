//------------------------------------------Introduction Entity framework core
Entity framework can't perform faster than ADO.net so performance is a drawback : good ones to know Dapper and ADO.net for larger applications

//----------------------------------------Approaches
1. db first approach-> here both concept are independent so I will need to make changes both sides
2. Codefirst Approach -> this one if I want to modify a table, then I can migrate changes to the DB by modifying the code

//---------------------------------------01. DbContext and DbSet
Db context is binded to a specific database, and db set is bind to specific table
1. first step is to go to Entities country and add the primary key
2. We did the same for person Entity addind the string restrictions
3. then we created a new class having the dbContext
4. then We have added to the entities project the NUget package frameworkcore.sqlserver
5. There is another way to add nu get packages by going to tools and package manager console
6. in the console we have to start with "Install-package nameOf_package"
7. now we have to add the db context as a service in the program.cs
8. so since the program.cs did not have sql server nuget package, then we had to installet again the the crudexample project
9. then in the db context we have to specify the context (inside program.cs)

//-----------------------------------------02. Connection String
Each developer should have their own database
1. to create a new DB we have to go to view->Sql server object Explorer then I can see Instances
2. there could be two instances Local and a project one
3. We have selected the local one, then expanded and then right click on databases->add new DB-> then type name of DB and ok(we can change thge path of the DB)
4. now we can see our new database, now we right click on the DB and properties -> We are doing this to automatically add the connection string
5. then we have to find the connection string
6. after we copied the connection strings we are going to add it to appseting.json
7. then to add the configuration stored in appsettings.json we go to program.cs and add: builder.Configuration.GetConnectionString("DefaultConnection"))

//-------------------------------------------03. SeedData
seed data refers to add initial information to the tables
1. first in the PErsonsDbContext we want to populate data with seed
2. we added some json files with countries and persons in the CRUD project
3. we are reading the jsons
4. we are descerializing every json 
5. the we use a system method that selrialize
6. so we can deserialize into our model (pass the data)
for every country we call the method has data methos, so all the countries are created in the countries.
7. we are doing those things as well for Persons

//--------------------------------------------04. Migrations
create a table or make changes to the table structure
1. we are set to create the database now
2. going to tools->nugetPackage manager->Package manager console we have to make sure the project is into the entities, sionce is the one having the tables
3. in the console we type --> add-Migration Initial
4. this will give an error if we don't add entity framework tools : we added into the console by: --> Install-Package Microsoft.EntityFrameworkCore.Tools
5. then we can run add-Migration Initial
6. Will still fail unless we install the microsoft entity design
7. then we have to run IMPORTANT ---THIS MUST BE IN THE STARTUP PROJECT -----> Install-Package Microsoft.EntityFrameworkCore.Design
8. We had an isue with the Db context because we haven't added a contructor in our dbcontext so we have created one
9. now we run the initial command again (****Make sure all the projects have the same version to run correctly)
10. new folder in entities called migration with two files, migration and the name we have given
11. We created the database but we have not run it with : Update-Database -Verbose /// menaning that the script will be in the same packege console
12. So now everything has been created, and to see that we can go to: View-> Sqlk server Object explorer-> and in the name of our database we can see the actual database and the tables

//--------------------------------------------05. EF CRUD Operations
So now to populate information we are going to inject a new db context inside of Countries service
1. so in countries service we refactor countries for _db and pass it on to the constructor
2. We have done the same for persons
3. we change the where for count to check all the persons and countries
4. Have to put saveChanges() aftger an insertion or any CRUD operation
5. we got an error because of the scope so we had to navigate to program to change the scope
6. so instead of addsingleton we added scope this was happening because db context has its own scope
7. there was another error since ConvertPersonToPersonResponse can't be converted straight from the contexts
8. so we changed to use Tolist()

//-------------------------------------------db calls explanation
how does it work 
linq performs quering 
savechanges() performs the CRUD

//-------------------------------------------06. EF Stored Proc
perform or complex multiple database oprations, the discussion is how to create store procedure from code first approach any changes in the database won't be good in this approarch
1. we are going to the package manager console and make sure we are in Entities project
2. we will run then: Add-Migration GetPersons_StoredProcedure
3. We had an error because in teh text we don't have the boolean to fill up the data anymore so we are passing a db context with the options thtat it must have on it             _countriesService = new CountriesService(new PersonsDbContext(new DbContextOptionsBuilder<PersonsDbContext>().Options));
4. We are gonig to do the same with persons but this one requires to add coutries as well
5. now we can run the command
6. a new migration has been created in the project
7. in Migrations in the get stored procedures we have to create and populate the stored procedures
8. so in order to execute the stored procedure we have to follow in thge command line: Update-Database
9. we can check the stored procedures inside of the folder programability
10. so now in persons DBcontext is the place where we are going to call the stored procedures
11. so now in PErsons service we can return something easier in getallpersons: return _db.sp_GetAllPersons().Select(temp => ConvertPersonToPersonResponse(temp)).ToList();

//---------------------------------------07. EF Stored Proc with Parameters
The task in this lesson is convert insert operation into a store procedure
1. in the add person of the service instead of this: //add person object to persons list
            _db.Persons.Add(person);
            _db.SaveChanges();
We want to use a stored procedure
2. we went to the package manager and run command: Add-Migration InsertPerson_StoredProcedure
3. this creates in entities/migration a store procedure called insertPerson
4. We will fill up that file with the stored procedures
5. Now we are going to the package manage again : Update-Database
6. so now in db Context we are adding a new method that retrieves the number of rows affected we are using : SqlParameter[] parameters = new SqlParameter[]
7. then we call executesqlraw() from here we call the stored procedure
8. so now we have to add this to our service whenever someone want to insert a new person
9. we comment out //_db.Persons.Add(person);
            //_db.SaveChanges(); and now we will use the stored procedure
10. in this lecture was optional to create Delete or Update

//---------------------------------------08. Changes in Table Structure
In this lecture we saw how to make changes in columns or data by using migration
1. We created in the person model TIN
2. we used in the console Add-Migration TINColumn
3. then for execution I have to run Update-Database
4. In here I can add a defaul value to prevent it to be null 

//---------------------------------------09. Fluent API - Part 1
so if I want to control the sql datatype meaning, how can I decide which datatype should I delegate for each table- it is a set of predefine methods that describe the table structure
1. First we went to personsDbcontext and on modeal creating we are doing this: modelbuilder I would like to select an etity of of person and I would like to select a property
2. Then we fill up with HasCoolumn
3. Then we used Add-Migration TIN_Updated
4. and finally we update and like this we change the configuration of datatype in a DB

//---------------------------------------10. Fluent API - Part 2
In this lesson we will see how to add contrains in the fluent API 
1. So now in the PersonsDbContext we will add the constrint by :  modelBuilder.Entity<Person>()
              .HasCheckConstraint("CHK_TIN", "len([TaxIdentificationNumber]) = 8");
            }
2. the run Add-Migration TIN_Updated_CHK then Update-Database

//----------------------------------------11. Table Relations with EF
In this lesson we wil see how to separate the primary tables and the secondary tables or foreign keys
1. Now in the person model class we will have a new attribute called country
2. then in the PersonService in get all we are going to have an include to bring the countries to live otherwise they wont't be populated(They work as Jonts)
3. now in the country propperty we will add a collection of persons
4. so now in PersonsDbContext we will try other way to add the keys
5. so now in personService in get person by Id, we have included the country to have them listed
6. so in service in convert person to person we do not need the country anymore since it is getting called before
7. so we could make ConvertPersonToPersonResponse an extension method instead of what we have now.
8. Now in person Response we can paste ConvertPersonToPersonResponse \\ However With Toperson is enough since it already has th country added so we just add  Country = person.Country?.CountryName at the end.
9. so now in PersonService we have changed all the convertPErson to just Topersonresponse
