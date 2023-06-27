//-----------------------------01. Creating Models
We will create the roles of the app and as well the identity of the user
1. First we created a new folder in the domain called IdentityEntities/ApplicationUUser
2. so, in order to inherit from IdentityUser we have to install some nuget packages: Identity and Identity framework core
//This packages have a function and it  is to add the roles in the databases and identify each user
3. we have to install the identity entity framework because we have to use it to call objects
4. we have added a new string user name in the application user
5. then We created the application role class inside of the domain
6. and now we are going to our applicationdbcontext and instead of inherit from Dbcontext we will from IdentityDbContext
//The difference between those two is that Identity already has dbsets

//------------------------------02. Register View
Creating the register view with validations
1. we will create first the class RegisterDTO inside of DTO -> this class will hold all details in the register form
2. Now we will create the view so we added in views/Account/Register.cshtml
3. After this we will add the namespace inside of the viewImports @using ContactsManager.Core.DTO @using ContactsManager.Core.DT
4. now we have added the controller for that view
5. now we have to create the hyperlinks in the layout view

//------------------------------03. Adding Identity
We have to add the Identity services in the IOC container
1. inside startupExtensions I have to add servcies.AddIdentity() (have to make sure we already installed that package)
2. and then we have to add couple of things : //Enable Identity in this project
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
                .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();
/*Explanation*/
services.AddIdentity<ApplicationUser, ApplicationRole>(): This line adds the Identity services to the dependency injection container (services). It specifies the custom ApplicationUser class as the user type and the ApplicationRole class as the role type for the Identity framework.

.AddEntityFrameworkStores<ApplicationDbContext>(): This line configures the Entity Framework as the persistence store for user and role data. It specifies the ApplicationDbContext class as the database context to be used for storing Identity-related data.

.AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>(): This line configures the custom UserStore to be used as the store for managing user-related operations (e.g., creating, updating, and deleting users). It specifies the types ApplicationUser, ApplicationRole, ApplicationDbContext, and Guid as generic parameters for the UserStore.

.AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>(): This line configures the custom RoleStore to be used as the store for managing role-related operations (e.g., creating, updating, and deleting roles). It specifies the types ApplicationRole, ApplicationDbContext, and Guid as generic parameters for the RoleStore.

By adding the Identity services and configuring the appropriate stores, the code sets up the infrastructure necessary for user and role management within the project. This allows for authentication, authorization, and other identity-related functionalities to be implemented using the Identity framework.

//------------------------------04. User Manager
provides business logic methods for managing users, in this case we have to create the logic to create a person or insert in the user database when register button is pressed
1. In account controller we will crete the user manager to do so
2. we added the logic -> validate registerDTO, create Application user and Identity for password
3. Then we check for errors, if succedes we retorn to persons index
4. If not then we put errors in viewbag and list them and return to the same view
============Make sure you are in infrastructure project===========================
5. Now we are going to update the database to store the users first : "Add-Migration IdentityTables" -> this will add all the relationships of the DB tables
6. Run "Update-Database" // Identitycontext already has all the essential db sets required to update database

//-----------------------------05. SignIn Manager
This provides the business methods for login and log out
1. Start by adding the SignIn Manager and Injecting in the constructor
2. If we succed Creating an User then we have to sign in that user// A cookie will be created to store the session
3. Then if we want to show the actual user logged in, we can go to the layoutview and use @user, which is a base variable that shows the actual user.
4. we added @User.Identity?.Name, in case of not null then show the name
5. After successfull creation we were unable to see the user printed in persons, that was because the autentication middleware has not read the cookie
6. We have added the autentication middleware in program.cs to have the name printed and read the identity from cookie

//----------------------------06. Login/Logout Buttons
The idea is that when a user is logged, then we don't want to show loggin or register and instead show Logout
1. We have to check the status of the user in case is logged in or not
2. In the Layout we have added a contition to render the Login or Register base in the authentication

//--------------------------07. Active Nav Link
We will try to highlight the current link were we are to do that we have to assign the current page in the viewbag and based on that apply css
1. we will add in every view ViewBag.CurrentUrl = and the actual page
2. Then in the Layout we will check what is the active page and we will put an underline with teh class  class="nav-active"

//--------------------------08. Password Complexity Configuration
While adding the identity I can configure how complex it should be the passwrod
1. in the configureservices while adding the Identity, we can pass a lambda expression to set password complexity
2. This will be doine in the Application role call
3. !!!IMPORTAT Even If I don't set this complexity, Asp will take default values

//--------------------------09. Login View
For the Login view We will create the view, the controller with post and get methods, and the DTO that will request the values and put them too the client is responsible of giving the cookies that has stored not the server
1. So first we created the DTO object for this
2. Then Then the view we just copied from register and left the login and password values
3. In the controller we added the get and post methods
4. We used this time _signInManager.PasswordSignInAsync to sign in and _signInManager.SignOutAsync() to sign out

//-------------------------10. Authorization Policy
For this, the idea is to block access to selected views in case you ar not logged, we have authorization poliy as a service
1. In program.cs we have to add the app.UseAuthorization();
2. Now in Configure services collection we will add the services in the service collection
3. Now if we want to just allow some views, we have to explicity tell if they can be accessed without logging: that is done first in the account controller [AllowAnonymous]
4. We have done the same for homecontroller to see the errors

//-------------------------11. ReturnUrl
The purpose of the return URL after the user has successfully logged in, we have to send after the http post the actual page where we want the user to be redirect
1. In order to make this work we have to go to the login view and add additional values to the form, by using  asp-route-ReturnUrl="@Context.Request.Query["ReturnUrl"]" so the actual value of the return url will be appended to the post request
2. Then in the post method we can receive the post URL as a string value and validate if LocalRedirect(ReturnUrl)
//The idea of this is in case we send a a link to the upload action and the user is redirected to the login first, after login I expect to be redirected to upload

//------------------------12. Remote Validation
The idea of this lecture is to validate if there is any error, in case it finds any error, like for example dupicate email in the register form, we want to avoid reload the view to give the same data. This will be done by adding an action method. REAL TIMING CHECKS 
1. First thing to do is go to the account controller and create the action method that will handle the email is already resgistered through usermanager _userManager.FindByEmailAsync(email);
2. In order for this to work then we need a remot validation in the DTO object, in this case in the email
3. in order to use remote we have to add a new packet called view features

//-------------------------13. Conventional Routing
Conventional routing redirects all routes to an action method, this can be overriden by putting an attribue routing
1. first thing to do is to comment the controller route
2. Go to program.cs and in there before run, we have to add end points to manipulate the controllers route

//-------------------------14. User Roles
1. First We will create the enum that will have the user type roles
2. then whenever we register a new user we have to add it to handle it in the controller so we add it to the registerDTO
3. Now we will create a radio button in the register view to include the field
4. Now in the controller we have to handle the role when the http post is done

//------------------------15. Areas
Area is a group of controllers, views and models that are related to a specific module or specific user, so the idea in this lecture is to group everything related to administrator
1. firstly we will strat by adding a scaffolded Item, this is to create the Admin space, to do that we have to go to UI and right click then add new scaffolded and create MVC Area
2. This will generate code and directory trees, we have deleted the folder data sonce we already have that layer
3.  then we have created a new controller, this one will have an attribute [Area("Admin")] which indicates this is for admin control
4. after, we will create in the program.cs conventional routing(I can use attribute routing too)
5. after added the route, we are going to create the view
6. After the creation of the view we will add the flow in the login controller
7. So after we successfull login we will ask if that user is in role admin
8. Now we have to add a hyperlink for admin home, we will add it in the layoutview
9. Since the views now are different from our main project we have to add the tag-helpers so we create : viewimports to import the tag helpers
10. at the end we just aded a contition to see if the role of the user is Admin, then we will let him see the admin view

//-----------------------16. Role Based Authentication
we will add some pages for some partivular users only

1. so if we want to only allow a specific user we as well have to use [Authorize(Roles = "Admin")], so only for this particular Admin this controller will be visible

//---------------------17. Custom Authorization Policies
so in case we want to prevent users to use login or any page, we can make two things, create a filter or we can use policies, and policies is what we will implement here
1. The first step is to go to sonfigure service extension and in the autorization addPolicy
2. as well we have to add the attribute Authorize above the method so this will be applied, we did it in the register in accountcontroller
3. Then take out the allowanonymous because this will allow all pages even if they have policy restrictions

//--------------------18. HTTPS
The idea of https is to exchange messages between server and the client, the client will first send a message request, then the server will acknowledge that message, then the client will send a random value to the server, the server will ackowledge that random value and generate a certificate with signature, that is when the client receive that as a key.
1. To make a project work with HTTPS we have to go to the program.cs file first and add app.UseHttpsRedirection();
2. the we enforce https request and responses with HSTS
3. then in the properties, launch settings we can change to https

//----------------------19. XSRF
Cross Site Request Forgery - CSRF is a process of making a requet to a web server from another domain using an existing authentication
1. In this case the scenario is, from a legit request after we log in and received a auth token from the server, if we click on the wrong link an attacker might be able to steal information oir money. We will try to avoid this by using AntiForgeryToken
2. We need to make sure we are using correctly the tag-helpers
3. in the controllers we have to add [ValidateAntiForgeryToken]
4. but now in ordewr to enable it globally we have gone to configure service extensions and add options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); // Auto will validate in post action methods
