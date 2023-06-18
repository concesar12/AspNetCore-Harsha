//-------------------------------01. Interface Segregation Principle
instead of having a single big interface, the idea is to group several interfaces with few methods, so what we will perform here is, since we created an interface for each table and not for operations like, addperson or get persons. That is what we will do here
1. Created a copy of IpersonsService for each operation(add, delete, update, etc...)
2. We implemented the same for the service
3. ctrl +m + o -> this will collapse all the methods
4. We have fixed errors created in the controller of persons

//-------------------------------02. ISP in Tests
We will fix the tests of the interfaces created before
1. So we added the actual logger and mocks for the controller
2. Added services into IOC container
3. rename database to have it working
4. todo---> do the same for countries

//------------------------------03. Open-Closed Principle - interfaces
This is in case we have to modify the code base, the best is not to change the actual code, but create a separate implementation or a extension of that, so the problem to solve here is, we want to add just few attributes to the country when downloading csv
1. First we created a new class PersonsGetterServiceWithFewExcelFields in service
2. Then we have added the same things as personsGetter Service
3. In the IOC we added our new service
4. don't forget we have to change in the IOC for the actual previous class(Seeexample)

//------------------------------04. OCP with Inheritance
We will try the same previous scenario but wih inheritance
1. in this case we have created a new class in services PersonsGetterServiceChild
2. Then we have change signaturo on the person service to be virtual
3. now we are just overriding the method GetPersonsExcel to have our preffered behaviour
4. then we have to addded it into the IOC in order to be called

//------------------------------05. Liskov Substitution Principle
So basically, when we inherit, we should always return the save value if parameters are the same, and we should not introduce new exception that the [arent class did not have 
1. We have seen that the previous example was braking the liskov substitution and then we kept it with interfaces