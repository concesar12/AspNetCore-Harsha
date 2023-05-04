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
4. then we will add the test class
5. the class services got the reference from services contracts
