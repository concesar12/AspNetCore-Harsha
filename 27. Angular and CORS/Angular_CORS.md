//-------------------------------01. Creating Angular App
We will create the angular app
1. first create a new folder for the client
2. We downloaded and installed Node.js
3. the we right click in the client folder and start the console there
4. now we will run: npm install @angular/cli -g, this is to install angular client
5. then we run:  ng new CitiesAngularApp --style=css --routing
8. if getting an error we have to set the terminal with our windows credentials by running : Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser
9. then we can try to create the angular application again

//-------------------------------02. Angular AppComponent
we will add some ui in the component
1. We will place ourselves in citiesAngularApp folder in the power shell 
2. then run: ng g component Cities, which means create a new component calles cities
3. then the cities component will be created
4. then we will have to add a route for cities component in app-routing.module.ts
5. deleted title propperty in app.components
6. then in app.component.html we have erased all
7. then we added the css file in the src
8. now we will run npm install to install all the packages necesary for the project in package.json file
9. now to run the application we have to run : ng serve or ng serve --open -> to start the live server
10. once is up and runnig we have made changes in the app.component.html

//--------------------------------03. Angular Service
display the list of cities in a table format
1. first we will open in a terminal our citiesAngularApp, thi is to create the models
2. Then we run : ng g class models\City
3. then in the City.ts we have added the proppertyies of city and created a constructor
4. once finished we have to create the services by running:  ng g service services\Cities
5. then we imported the city from moels in cities.service
6. then we will create some dummy data in there

//--------------------------------04. Angular Cities Component
we will invoke the cities service in the service component
1. go to cities component.ts file and create the constructor and the initial point of entry of the app
2. now we go to the html compoenent file, and create the view part of it
3. Then we run it and should be good to go

//---------------------------------05. Invoking Web API Services
we will fetch data from the API to fill up the table
1. first we get rid of the data in the constructor of cities.service
2. and then we have to get our httpclient inside of the constructor, don't forget to bring the imports necessary
3. then we have to call the api and return it into an observable
4. Now we have to go to the cities.component and susbscribe to get the response 
5. Now we have to bring the htttp client in our app.module.ts
6. Now got an issue because the request was sent from another domain (different localhost + port number), we will fix next lecture

//---------------------------------06. CORS Basics
In this lecture we will fix the CORS problem(Cross origin Resource Sharing) so we will include an Access-Control-Allow-Origin in an automated way for all the responses
1. In order to add it we have to go to progam.cs file, by adding cros service
2. we added as well routing and cors at the end to generate response automatically everytime

//---------------------------------07. CORS Configuration
in here instead of having hardoded the port number and the single cflient we will have it in configuration.json
1. in app.json we have added an array with the allowed domains
2.  and now in program.cs we will change the service add corse to allow the configuration

//---------------------------------08. Default CORS Policy
We will try to understand how default and custom cors work
1. in cities.service we will add new headers, so by adding this authorization header we have to customize the policy, otherwise we will have cross origin error again
2. in program.cs now we have to add the headers that we will allow
3. Remember Browsers allways make a preflight request
//---------------------------------09. Custom CORS Policy
We will see if it is possible to maintain more than 1 cors policy (customization) in case we have another client visithost
1. In program.cs file we will copy the previos policy and we will customize to receive whatever we want
2. Then since we have allowedOriugins2 we can add the clients we want to add
3. So if we want to add this for only some controller we have to add [EnableCors] in this case we added in citiesController
4. So now the domain that works is: ng -serve --port 4100
//---------------------------------10. Angular POST
We will apply insertion operation in the application
1. in our angular app we have top go to cities.service and add our post method
2. as well we made something more dynamical and constant
3. now in cities component we will create the forms 
4. we have to expose the posty city in order to use it
5. we added the submit as well
6. Now we will create the view with the form that will have all the information to be processed
7. then we will need to import the reactiveFormsModule

//---------------------------------11. Angular PUT
We will implement edit or update operation in the cities
1. first we have to add the method put in cities.service
2. Now in cities component we are going to create the put controller for this
3. So now in the view that is cities component .html we will create the view for this
4. as well in the view we have to enable "disable control" so we have to run in power shell: ng g directive directives/DisableControl
5. now a new directive folder will be created , we have to add the directive in here to be applied

//----------------------------------12. Angular DELETE
we will implement the delete functionality for every city
1. In order to create the delete, we have to go to cities.service.ts and create the method for it.
2. then in the view we have to add the delete button
3. we will try to create the delete butrton in the controller, we creted the modethod delete
4. then in cities component we will try to add the list to form froup in order to show the list if a new element gets created.

//----------------------------------13. Clean Architecture with Web API
We will have clean architecture with API
1. in the solution we will add a new project and class library
2. now in dependencies we will add citiesmanager.core
3. then we moved from models the city class to our entities folder in Cities manager core
4. We changed the namespace and now we will create ou infrastructure project
5. now we created our folder DatabaseContext and in this one we have moved ApplicationDbContext
6. we moved migrations too to infrastructure folder
7. as well we have installed sql framework and fix the using libraries
8. And in the main app we have added references of the projects
9. now we ran the project to clean errors
10. after all error cleaning we will delete migrations and run again Add-Migration Initial
11. then Database-Update
