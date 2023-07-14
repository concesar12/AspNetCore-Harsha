//------------------------------01. Creating Basic Minimal API
we will create a new application called minimal
1. application from asp.net empty project
2. create map post and get to retrieve and post values

//------------------------------02. GET and POST
We will try to have our post and get methods for an actual product
1. first we will create the folder models, and a class for it to store the attributes
2. then in program.cs file we will try to create a list of products
3. and aside of doing that we will perform the operations of each method
4. then we have to override toString in order to show exactly what we expect in pproduct class 

//------------------------------03. Route Parameters
we will learn how to pass attributes in the parameters like product ID
1. we will add the route and the product/{id}

//------------------------------04. MapGroups
map groups or route groups is a concept of grouping the endpoints based on a particular route prefix
1. we will first create a map group in program.cs
2. this map group will handle all the routing assigned to that map
3. Since we have this map now we can separate the logic in the program.cs and put it in another file
4. we will create a new folder with route groups that will have an extension methos
5. then we will call the ProductsAPI in program.cs
6. then we aded all the CRUD to the new class and added group to call the routse instead of map

//------------------------------05. IResult
in order to return results IResult is an interface that has all those methods implemented to use
1. We have implemented the IResult in program.cs

//------------------------------06. End Point Filters
to use filter we have before logic and after logic, till now there is only one type of filter in minimal API
1. We have to add the required validation in the model in products
2. We have to go to our extension class and use the filters in there

//-------------------------------07. IEndpointFilter
In order to write end points in different files and have a more organized project, here is the solution
1. first we have to create a new folder in the application, then we will create our custom endpointfilter.
2. then we will inherit from IEndpointFilter and implemente the interface
3. Now we will implement logging and inject this service in the constructor
4. after we log before and after logic we will addd this filter in the productsmapgroup, in map post