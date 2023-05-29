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

//----------------------------------------12. Async EF Operations
So we will add asyncronous methods since every time we interact with other apps we have to wait
1. In ICountries service we will modify methods to be Async
2. No we have to go to the actual Country service to provide the implementation with Task and add Async and add methos with async
3. now since we have changed to async most of the methods we got some errors that will be fixed in next lesson

//----------------------------------------13. Async Controller Action Methods
Cleaning up the signature of methods for Async methods so controller and service test need to change
1. in person controller we will add the sync in List<PersonResponse> persons = await _personsService.GetFilteredPersons(searchBy, searchString);
2. The controller itself now has to be async
3. we change all the async methods
4. It is always advisable to put the async in controllers
5. so now we went to the tests to make them async the test made async were country test, but still we have to make person async in the next lesson

//--------------------------------------14. Async Unit Test Methods
1. in here we have to change all the non async methods for async and await them

//------------------------------------- 15. Generate PDF Files
With Rotativa we can create a PDF in .NET
1. We will need to create a separate view in order to have the PdF printed without all the things like search bar ans titles
2. We are going to create a new view
3. now we have to set the layout to null to prevent the things to load 
4. removed the persons and links, search box was deleted too
5. form tag too and form tag was deleted too
6. the sorting icon is not necessary
7. We have to manually and explicitly call the css file since the layot we set it as null
8. now we have to add the package in the main project: right click on project/dependenciew and click on manage nuget packages
9. then we look for rotativa and select rotativa.Asp.net core
10. Once installed we went to persons controller and we created a new method action personsPDF
11. and then we go to index view and add the link to generate a pdf
12. we got an error when trying to export a pdf because we needed to include this file -> wkhtmltopdf
13. so we downloaded that file and extract the .exe file
14. then we created a new folder in wwwroot with name Rotativa to place the .exe file
15. the we go to program.cs to add rotativa and run the program
16. I got an error with the view personsPDF, it was not set as content in the build propertie so when I changed I was able to make it work again.

//--------------------------------------16. Generate CSV Files - Part 1
if we want to convert to convert to csv files I have to use csh helper
1. the first thing to do is to add a new method to the interface of persons to get the csv file
2. so now we have to implement that method on the service (Streamwriter writes in the memory stream)
3. we have to add csvhelper as a packet in the services project
4. then we handle the population of the data in the memory stream
5. Now we go to persons controller to convert the stream into a csv file when it gets called
6. once we have got the info into csv we have to go to the index view to create the link to convert to CSV
7. in the index view we added the link and added some marging left to give order

//-------------------------------------17. Generate CSV Files - Part 2
Problem with write records is that we can't filter the values that we want to show for example persoon ID so in this lesson we will understand how to do that Writefield(value) is the method
1. in person service we will call the method csvconfiguration to adapt the values
2. then we have writefield every value we want to include
3. then we have to loop to our personresponse object to extract the values

//-------------------------------------18. Generate Excel Files
In order to generate Excel files the package EPPlus will be the most suitable
1. we will install in poerson service the package
2. in case to use just for own project we have to go to appsettings.json
3. Then we have to add the lines to state that is for noncommercial use
4. then In the persons interface we add a method Task<MemoryStream> GetPersonsExcel();
5. then we have to go to the service to implement the excel
6. after the excel is being terminated then we have to go and add the action method in the controller
7. in the index we have to create now the hiperlink to the view of the excel
8. then we added the formatting

//-------------------------------------19. Excel to Database Upload - Part 1
if we want to add the upload functionality in the database table we can do it as follows:
1. First thing is we are going to add a new method in the interface Countries UploadFromExcelFile
2. Task<int> UploadCountriesFromExcelFile(IFormFile formFile); then add on using using Microsoft.AspNetCore.Http;
3. then we have to add to the dependencies in the service contracts the package (AspNetCoreHttp // It is deprecated in the time)
4. now we are implementing the new method in the countries service
5. first we create the memory dtream 
6. then we convert to excel file we use copytiAsync to do that
7. then in the workbook we will select the name and the data to be passed
8. we opened an excel and added the values we wanted in there
9. we had to add the country instead of country add request since we are dealing with the database

//------------------------------------20. Excel to Database Upload - Part 2
From the last lesson we have to create the UI so the process from the controller to the view
1. Create a new controller for the country
2. and give the routing
3. Then adding the view of that controller
4. multipart from data will allow to upload files
5. once done with the view for upload we have to move to Layout view
6. In the Layout view we will add the link for the uploadcountries and then we should be ready to go

//-----------------------------------21. Excel to Database Upload - Part 3
now we have to receive the post request in the controller method
1. go to Uploaad controller and add the methods
2. IFormFile to receive the file this name excelFile has to be the same as the one in the view for it to work propperly
3. so once the methos are created and validated we have to go to the view
4. In the view we will add the error messages from the controller