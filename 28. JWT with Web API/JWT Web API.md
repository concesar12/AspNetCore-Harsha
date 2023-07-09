//---------------------------01. Identity with Web API
1. For Identity we have to create essential Nuget packages identity in thje core and infrastructure
2. We have createde a new folder Identity in core and add a class  
3. we will create the application user and role
4. Now in the ApplicationDbContext we will inherit from IdentityDbContext
5. Now in the program.cs we will add essential services for identity

//---------------------------02. Register Endpoint
We will create an endpoint for registration
1. first, we have to create the register DTO to transfer data from view to controllers and services the DTO was created in a folder and then we gave the name RegisterDTO
2. now in the Register DTO we have created the attributes that we want for the person, we added a remote attribute so then we can check wheter the email has been registered or not
3. in order to use Remote we have to install view features
4. So now we are ready to add our controller for the Account, in the V1 folder
5. once the controller has been created we have created the fields {UserManager, RoleMAnager and SignInMAnager}
6. we added the Post and get methods which will handle when someone clicks on register button or when someone go to register link
7. We have added the static files necessary in program.cs to prompt any images

//---------------------------03. Register UI
We will create the register UI of the controller previously created
1. In our client app, is to generate a new class with: ng g class models\RegisterUser
2. In this class we are creating the properties required for every user
3. So now to make a post request, we have to create an Angular service : ng g service services\Account
4. since our service is now ready returning the person and receiving the person we can create our component: ng g component Register
5. in order to create the component we have to: ng g component Register, after this a new folder register will be created and in app.module we will see that RegisterComponent was added
6. now in register.component we have to validate all fields and pass them in the form
7. Since we have our component complete we will need to go to the HTML side and create the actual view in register.component.html
8. The point of having a component in Angular is to have methods for validation and operation to be passed in the UI.
9. Now we have to add the link of register in the app.component.html file and then add the path to app-routing.module
10. now in the controller we will add in the httpost of Account controller the register route do be redirected.
11. Now we have to reate the users tables by going to the package manager and select the infrastructure project
12. run: Add-Migration IdentityChanges, once genereated run : Update-Database
13. Now we will create a password and confirm password match validatiors and inside of it we added a new object in web general, "TypeScript File"
14. we created a new folder called validations and inside we created the file custom-validators and added the validation in there.
15. now after running we should be able to see the register view and on real time 

//---------------------------04. Login Endpoint
We will create an endpoint that will mean an action method for login
1. first thing to do is create a DTO to receive the user from loging and add the required attributes
2. We will add Login as an action method as get and post in the controller

//---------------------------05. Login UI
We will create the view for he login form
1. We are going to go to our Angular application by using the console in CtiesAngularapp and type : ng g class models\LoginUser
2. Then the login-user will be created and we will put the attributes there
3. Now we will go to account service and create the get and post methods for login and logout
4. After this we wll need to crate the component where we will handle the data put in the view, in order to create the compoenent have to run in powershell ng g component Login.

full explanation: 
The constructor is the initialization method for the component. It takes two dependencies: AccountService and Router. These dependencies are injected into the component by Angular's dependency injection system.

The loginForm is an instance of the FormGroup class, which is used to manage form controls in Angular. It represents a form with two controls: email and password. The FormControl class is used to define individual form controls with their initial values and validators.

The login_emailControl and login_passwordControl are getter methods that provide convenient access to the email and password controls of the loginForm. These methods can be used in the component's template or other methods to access and manipulate the form controls.

The loginSubmitted() method is triggered when the login form is submitted. It performs the following actions:

Sets the isLoginFormSubmitted flag to true, indicating that the login form has been submitted.
Checks if the loginForm is valid using the valid property of the form group. If the form is valid, the code inside the if block is executed.
Calls the postLogin method of the accountService (presumably an HTTP service) and passes the loginForm.value as the request payload. It subscribes to the observable returned by postLogin.
In the subscription, the code inside the next callback function is executed when a successful response is received. It logs the response, sets isLoginFormSubmitted to false, assigns the response.email to currentUserName property of accountService, navigates to the /cities route using the router, and resets the login form.
If an error occurs during the HTTP request, the code inside the error callback function is executed, logging the error.
The complete callback function is empty and does nothing.
Overall, this code handles the submission of a login form, sends the form data to a backend service for authentication, and performs various actions based on the response received.
5. Now we are createing the HTML view which will receive the values and pass it to the component.
6. Then in the App routing we will add the routing for login
7. now we will create the logout functionality, so first in app.component we will create the controller to check if user has clicked logout button.
8. Now in the html we have created the log out validation that won't shouw up login if already.

//---------------------------07. Generating JWT Tokens - Part 1
we will generate actual JWT and send it as response to the client
1. We don't have to generate a way to generate the hash, that is done by a package AspNetCore.Authentication.JwtBearer, so first we will add it in the core project.
2. Now we will create a new DTO object that will represent the data as response
3. Then an intercface that will be in charge of generating this JWT token
4. now in the appsettings we have to set the jwt with the properties: Issuer, Audience, Expiration and the key.
5. so now we are ready to implement the JWT service to create our JWT
6. First we have to read the configuration from appsettings so we got it in the constructor
7. based on this we have to do: get the Sub, Jti, Iat for the token, optionally we canb add person name and the email, then we have to get the security key from config and convert it to bytes
8. then we generate a token with all the values before and finally we return it.

//---------------------------08. Generating JWT Tokens - Part 2
Now we have to call the creation of the token when Registration or when Login
1. First we have to go to the program.cs and add the service for jwt
2. Now in the Account controller we have to add it in the constructor to use it.
3. When we sign in in the login or register we have to pass the JWT tokens
4. Now we have to store it in the client side application, so we have to head to login component and add the key in local storage
5. now in account service we have to receive any in order to receive the key

//---------------------------09. Authorization with JWT
Now that we finally got the token, the goal now is to generate the token for all subsequent requests that can be made to the server, so we have to include the token in the header
1. In cities service we have now to receive the actual value of the token we have to use same names
2. now we will manage the logout to delete the key when pressed in app.component.ts
3. now the problem is to validate the token in the server side, we have to install in webAPI project the JWT package, this is for authorization to read the token
4. now in program.cs we will add the authentication for JWTs with validations
5. we have to add an authorize attrivute to the controller too. However, we decided to have it as a global policy in program.cs

//---------------------------10. Refresh Tokens - Part 1
After the expiration date we have to refresh it
1. First thing is we are changing the expiration times to 1 minute, and refresh token to 60
2. In authentication response DTO we will add the refresh token
3. So now we have to ensure that for a single user we will have to refresh once and store in the DB, so in the identity model we have added the refreshing values to store the token
4. since we have changed that value we have to run an update to the DB by using: Add-Migration RefreshToken in the infrastructure project and then Update-Database
5. To genereate a new refresh token we have to add it in JWT service
6. now in the account controller in the registration method we have to add the refresh token when success
7. In register component we have to add the refresh token to be stored locally
8. We are doing the same for login
//---------------------------11. Refresh Tokens - Part 2


