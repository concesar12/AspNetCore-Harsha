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