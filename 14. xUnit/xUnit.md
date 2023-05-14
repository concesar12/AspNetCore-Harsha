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
