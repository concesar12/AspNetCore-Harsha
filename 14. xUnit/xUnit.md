//--------------------------Project Overview
In here we already started with a new application
//--------------------------XUnit Basics
1. In the solution we use right click and new project
2. then select xunit
3. It is important the fact that it needs to have two packages xunit and xunit.runners
4. write the unit tests
5. go to view and open test Explorer
//--------------------------Add Country - xUnit
DTO-> Data transfer object-> they are used to be usend as response/request
1. added a new project 
2. GUID is not limit
3. Created an entity that wshould not be exposed neither to the controller nor to the view
4. Created servicecontracts
5. created DTO's
6. we will add the references to sercie contracts from the entities
7. right click on dependencies-> add project reference
//--------------------------Add Country - xUnit 2
1. We created a new DTO CountryResponse
2. we need to create a way to prepare the object to be sent as a response by creating the static class public static class CountryExtensions
3. then we worked in the interface ICountriesService
4. then we will add the test classes
5. the class services got the reference from services contracts
//--------------------------Add Country - xUnit 3
1. We added the project references to the test class the project added was services.
2. Created the first test case which is: //When the CountryName is null, it should throw ArgumentException
3. then AddCountry_CountryNameIsNull()
4. AddCountry_CountryNameIsDuplicated()
5. last AddCountry_CountryNameIsValid()
//--------------------------Add Country - Implementation
1. In the countries Services we have implemented the add country which converts the request into a domain model.
2. This long proces to hide from outside the world of service. (Domain control Country should not be visible to outside the service)
3. Generate validations for AddCountry(CountryAddRequest? countryAddRequest) in nCountriesService
//--------------------------Get All countries
1. We have added the method getallcountries to the Inteface
2. Then we have to  generate the implemnentation in CountriesService
3. In the unit tests we have added #addregion and #endregion in order to minimize all the methods
4. added method  GetAllCountries_EmptyList()
5. added public void GetAllCountries_AddFewCountries()
6. We added to the add country tests Assert.Contains(response, countryResponses);
//--------------------------Get all countries - Implementation
1. In here we started by adding the method to the interface
2. operator overriding to equalize the countries.
3. Now whne I assert with Assert.Contains(response, countryResponses); then It will call the equals method overriden automatically.
4. If operator overiding is used then is advisable to override Object.
//--------------------------Get Country by Country ID Xunit Test
1. first we are going to write the method in the interface
2. thenb we go to countriesService to actually implement the method of the interface
3. then we will build the unit tests for this specific case
//--------------------------Get Country by Country ID Implementation
1. in countries service we are implementing GetCountryByCountryID(Guid? countryID)
2. We used FirstOrDefault() which gets the first ocurrence.
3. Lastly test
//--------------------------Add Person - Creating Models
1. In entities we are going to create another model class for person
2. Model class should not be exposed outside the service
3. We have to use DTO's to modify or get information of person
4. We created PersonAddRequest in the DTO
5. We created an anumeration for the gender by creting a new folder Enums and adding enum there.
//---------------------------Add Person - Creating Models 2
1. We created the personResponse DTO now
2. in the response is what we want the user to see
3. meaning of public static PersonResponse ToPersonResponse(this Person person) is this is an extention method and I would like to include the same with person class
//---------------------------Add Person -xUnitTest
We will Create the unit tests for the person
1. We created the interface IPersonService and build the methods :
PersonResponse AddPerson(PersonAddRequest? personAddRequest);
List<PersonResponse> GetAllPersons();
2. Now We are going to implement that interface by creating the PersonService
3. It can implement the internet by clickong on quick actions and implement interface
4. Now We create the new test class PersonServiceTest
5. REMEMBER !!! always have to bring the nuget package -> Xunittest and microsoft.unit.test
//--------------------------- Add Person Implementation
 Time to implement.
 These are the steps to take to implement the add person service
 //Check if "personAddRequest" is not null
 //Validate all properties of "personAddRequest"
 //Convert "personAddRequest" from "PersonAddRequest" type to "Person".
 //Generate a new PersonID
 //Then add it into List<Person>.
 //Return PersonResponse object with generated PersonID  
 1. First implement the person service
 2. first check person request comes null we used nameof() because ArhumentNullException neest to know the name of the parameter.
 3. Aproblem in here is that we have to get in PersonResponse service the conutry name based on the country ID
4. Nex lecture we wil use model validation.
//------------------------- Add Person Validation
the problem raises because we are only validating one condition in the person name. So will validate the PersonaddRequest Model.
1. We are going to personaddrequest
2. we aded as an example: [Required(ErrorMessage = "Person Name can't be blank")]
        public string? PersonName { get; set; }
3. Now in personsService we added the model validation: 
4. bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true); in here the true at last means that it will not only validate the required values but all the values. Validationresults stores all the errors.
5. Then the other problem is that as we added new models then we have to add the same pieces of code several times that is the reason the helpers are created
6. We have made the validation as an objectg to be generic in the helper and it is static to avoid creating a new object validation.
//---------------------------- Get Person By Person ID -Xunit test
1. In IPersonService we added a new method PersonResponse? GetPersonByPersonID(Guid? personID);
2. then we have to create the implementation in the actual service.
3. then We stated adding the tests cases
4. We added countries on top to be verified in the test case GetPersonByPersonID_WithPersonID
//---------------------------14. Get Person By Person ID - Implementation
Things we have to check to implement this: 
//Check if "personID" is not null.
//Get matching person from List<Person> based personID
//Convert matching person object from "Person" to "PersonResponse" type
//Return PersonResponse object
1. So we started the implementation in person service
//----------------------------15. Get All Persons - xUnit Test
1. first we go to the person service test
2. so we created the scenario with coutries first
3. then the person with the info
4. then we verify that all the persons are in the list.
//---------------------------- 16. Get All Persons - Implementation
We are going to implement the next: 
//Convert all persons from "Person" type to "PersonResponse" type.
//Return all PersonResponse objects
1. We are going into person Service
return _persons.Select(temp => temp.ToPersonResponse()).ToList();
//---------------------------17. TestOutputHelper
The problem to handle here is when running the unit test there is no value shown there. So we will have something printed when running them.
1. We started by injecting in the person test constructor ItestOutputHelper
in order to use this helper we have to add :using Xunit.Abstractions;
2. so now we added the prints over the tests
3. the problem was that tostring did not print the actual value so we have to implement our own tostring
4. We went to PersonResponse to override the tostring method
//--------------------------18. Get Filtered Persons - xUnit Test
The idea now is to on top of getting all person we are going to search persons we are going to create a method called getfilteredpersons.
1. We created the method in the IPersoninterface GetFilteredPersons we are returning a PersonResponse because is not a good practice to expoce the domain model outside the service.
2. now we are creating dummy implementation for the method created in the interface.
3. Then we created the tests for this method.
//----------------------------19. Get Filtered Persons - Implementation
now we are going to implement getfilteredpersons
//Check if "searchBy" is not null
//Get matching persons from List<Person> based on given searchBy and searchString
//Convert the matching persons from "Person" type to "PersonResponse" type.
//Return all matching PersonResponse objects
1. We went to person service to implement the filtered persons
2. Important to know always check if we have an argument null before using Contains or similar, since it can cause a lot of troubles
3. we created switch cases for this implementation and it was recommended to use reflection to avoid code repetition.
//----------------------------20. Get Sorted Persons - xUnit Test
The intend for this sort is to get the order based on a specific column.
1. We went to the person interface to create the method GetSortedPersons
2. We have created inside our Enums a new class for SortOrderOptions which will hold if it should be ascending or descending order
3. now we will add the dummy implementation.
4. And finally the unit tests for that.
//-----------------------------21. Get Sorted Persons - Implementation
PersonService implementation
1. First check if it is null
2. then start with the switch case to check the data and ordering
//-----------------------------22. Update Person - Creating DTO
