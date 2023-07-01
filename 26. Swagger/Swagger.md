//--------------------------01. Swagger Open API
It is a set of open-source tools that help developers to generate interactive UI to document, test RESTful services
1. in order to use Swagger we have to install some nuget packages : first is open api asp net core and next is swashbuvle.swagger(This contains already swagger)
2. then in program.cs we will enable swagger
3. in the propperties in luanch settings we have changed api/cities for swagger in order to see the test swagger

//--------------------------02. Documentation Comments
we need to enable documentation comments in swagger
1. we have to add xml comments, this is done by right clicking the name of the method in the controller and in snippets click on insert comments
2. no we have to create those comments in a XML file in order to read them 
3. to do so we right click in the projkect and select properties
4. then in the build section we tick the Documentation file and then in the XML field we put api.xml, then a new file will be generated when we build thge project, this is a xml file
5. then in program.cs we will need to include in <AddSwaggerGen> the options to look this xml file generated for comments

//-------------------------03. Content Negotiation
interaction between client and server  about the apropiate format or lenguage of the contenbt to be exchanged between the client and the Web API, in this case we will make our API to accept appplication/json data
1. first we have to go to program.cs and in add controllers
2. then we will add globally in the controllers a filter that will make sure we will consume and produce json
3. if we want to make it for a particular action method then we can go to the actual method an add it as an attribute in our case we did it in citiescontroller

//--------------------------04. API Versions - Part 1
API versionnning is the practice of managing changes in the API and give responses acording to the version requested
1. so now we will try to divide the cities controller into 2 versions, to do so, we will create two folders one with v1 and other with v2 and we will paste the same controller in both
2. We have modified code in the v2 to only accept get method
3. we have to enable versioning in the program.cs file
4. we have to install two packages MVC versioning, for the versioning to wrk and the api explorer which is next to it for swagger to be recognized
5. then we added in the controllers in the route the version to be used
6. now we have to establish how we are going to pass that parameter,  that is done by adding the attribute [ApiVersion("1.0")]

//---------------------------05. API Versions - Part 2
Aside of URL segment reader we can include two more to read the API version-> HeaderApiVersion reader and QueryStringApiVersionReader
We will implement here the query
1. In program.cs we are using now the query version reader
2. if we change in this way we have to remove the previous versionning we added in the controllers
3. now in program.cs we can add a default version to use in case user don';t provide one.
4. 

//--------------------------06. API Versions - Part 3
Now we will fix the problem with Sweagger and the versioning 500 error
1. first we have to add the swagger doc for every version created
2. now in the program.cs in the swagger ui we have to enable the versioning too
3. now in we have to add the explorer options to tell what version actually use