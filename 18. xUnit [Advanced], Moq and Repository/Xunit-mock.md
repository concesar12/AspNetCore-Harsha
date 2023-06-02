//-------------------------------------------01. Mock DbContext
Most of the unit cases are failing because of the dbcontext so we are going to use mock on the unit tests, Moq is the most common library to use when mocking
Install-Package Moq | Install-Package EntityFrameworkCoreMock.Moq
1. in the dependencies of The unit tests we are going to add Moq in the nugget package
2. Then actually hel us with the mocking we will use another package : EntityFrameworkCoreMock;
3. now in countries tests we will start: we will add the usings (Imports)
4. first we create an empty country list as datasource
5. now we have to create a mock object for the db context
6. but first we need to change the name of personsDbContext for ApplicationDbContext
7. first right clink in the personsDbcontext and then rename it then on the entities right click on the class PersonsDbcontext and change it
8. then we started working in the constructor of the countries tests
9. we need to mock the sbsets as well
10. we ran into a problem since the mock need to override the bdsets in order to fake the methods we have to go to the applicationdbContext and make db sets virtual
11. Now We are going to change the tests for persons too

//--------------------------------------------02. AutoFixture - Part 1
The problem in here is: some of the tests implementations have dummy data of the models that are time consuming, so in this lecture we will create face data for this. that is autofixture
1. first we have to install that package autofixture
2. now in the top of person test we have to create the autofixture object and then add it to the constructor
3. now we are going back to add propper person unit test 
4. The Email value failed we we tried to use fixture because got a erroneus value
5. so we used Build to customize some values

//-------------------------------------------03. AutoFixture - Part 2
This lecture we will apply autofixture for all test cases
1. So in persons test cases we will apply autofixture everywhere
2. added to countries as well

//-------------------------------------------04. Fluent Assertions part 1
this change the way we make assert code the package is FluentAssertion
1. first instalkl the poackage
2. then we go to a unit test in persons
3. first create the func as delegate object and then use the fluent assertion

//-------------------------------------------04. Fluent Assertions part 2
1. we added the last of the persons acts and assertions 
2. We added all the countries

//------------------------------------------05. Introduction to Repository
There is a flaw with the implementation at the moment, the service is tight to the model (service is accesing the dbcontext directly), so in case if we want to change databases in the future we will need to change the services too, that is why repository pattern is good to be implemented we will keep things separated
1. In order to create the repository we have to go to the solution explorer and add a new project
2. the new project will be a class library in C#.
3. Then we will name it RepositoryContracts
4. after that we added two new interfaces for countries and persons
5. then we will add the reference of the entities in the dependencies
6. then we will start addding methods that use the DB we are doing this for both Countries and persons: methods are taken from the actual services

//------------------------------------------06. Repository Implementation - Part 1
The idea of this lesson is to implement the countries repository
1. the first thing is to add the class library and call it repositories
2. Then we will need to rename the class in that project to be countriesrepository
3. in taht class we will inherit from the interface created before, therefore we have to import the dependencies of repository contracts and entities
4. then we created the db contexts and addde to the constructor
5. then we are creating the implementation of each method

//-----------------------------------------07. Repository Implementation - Part 2
Now we will create the repository in the persons side, it is important to highlight the fact that repository should be lightweight
1. added new Item for persons repository
2. start implmenting the repositories

//-----------------------------------------08. Invoke Repository in Service - Part 1
In this lesson we will invoke the repository in the service class
1. so we add the dependecy in the service project and we will link the repository contracts only
2. then we go to countries service we have to rename the dbcontext for our new country repository which will be in charge of updating the db with our changes
3. then replace every part thst use the db with our repository
4. we encoutered an error because we were passing the actual database when we had to pass in the repository (fixed by passing null)

//------------------------------------------09. Invoke Repository in Service - Part 2
In this lesson we will do the same but for persons
1. rename the the db context for the repository
2. then change the code to use repository
3. then change the test to receive null instead of the dbcontext in the meantime in the tests
4. at the end we are going to add to the main project class the repository contracts and the repositories
5. then we added in the scope IoC in program.cs the two repositories

//------------------------------------------10. Mock Repository - Part 1
we will mock the repository to ask information in the test
1. first in the persons test we have to add the persons repository mock and then the persons repository too 
2. we have to add it in the constructor after
3. we are addding into add person test this line: _personRepositoryMock.Setup
             (temp => temp.AddPerson(It.IsAny<Person>())).ReturnsAsync(person);
4. in order to connect the actual test with the mock repository we have to assign the mock repository in the constructor to the variable _personRepository
5. Then we were able to mock by just using the repository

//---------------------------------------11. Mock Repository - Part 2
In this lesson we will continue mocking different methods to use repository
1. we are starting from the first test case to modify 
2. then we finish fixing test till we reach GetFilteredPersons_SearchByPersonNameToBeSuccessful

//---------------------------------------12. Mock Repository - Part 3
1. We started from sorted persons to fix those tests
2. then we added the country tests
3. In order for this to work we made some changes or things to be aware:
-> We have to add the mock repository at the begining same as the fixture
-> Normally we have to create a normal object to add it to the repository
-> have to check related methods when calling a method to be mocked for the repository

//---------------------------------------13. Controller Unit Test - Part 1
since the controller is apart we do have to create test for it too and mock the services
1. we have created a new class to mock the controller called personscontrollerTest
2. First create essential service persons and countries
3. as well as create the fields for the mock objects
4. bring the fixture
5. create a constructor where we are going to create all these fields
6. we have to add as a reference the CRUD project

//--------------------------------------14. Controller Unit Test - Part 2
We will try this time to create the post action method of the persons controller
1. we will have the tests for create post 
2. We will have two new tests: when model is not valid and when model is valid
3. create new tests for update and delete

//-------------------------------------15. Integration Test
integration test we care about the overall functionality of the application, we will create integration testing for each controller starting for index
1. the first thing to do is to crate a new class test for personcontrollerintegrationtest
2. inside of that class we will create the client that will access the url of the controller
3. in order to have a client to make http request, we have to create a webapplicationfactory\
4. so we right click on the test project and add that class above
5. We have to inherit this class from another in-build class called WebApplicationFactory<Program>
6. then we have to get the program to be available by creating a partial view.
7. so we added in program.cs : partial class Program { } // This will make the program available to the developer
8. so to make it available we have to modify the project config file, so click on the project and edit project file
9. We will add the project to be visible by using : <ItemGroup> <InternalsVisibleTo Include="CRUDTests"/></ItemGroup>
10. Now back in the webapplikcation factory we will have to add package microsoftaspcore testing
11. because we don't want to access the real database, then we will use inmemoryfremework which created as DB in memory to be used
12. We have to import a new package to add in the test project: frameworkcoreinmemory
13. then we added the client and create the http client inside of the PersonsControllerIntegrationTest
14. we got an error because can't find the file for pdf creator called wkhtmltopdf.exe
15. so for integration test we have to skip the step where that one gets created in the program.cs
16. the all thge tests should run fine

//-------------------------------------16. Integration Test with Response Body
in order to check what was the answer of the actual DOM we can use a third party library called Fizzlr
1. We have to install the package Fizzlr and the other package agilitypack of fizztler
2. then in the integration tests we will add the response of the reponse body
3. import all the fizztler that we added in the packages
4. then after read and creation of the html DOM
5. We will read as query the table in persons view index we added persons in that table
6. Create integration tests for all the routes