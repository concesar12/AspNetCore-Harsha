//----------------------------------------Starting with UI
This Section we will create the UI and functionality of the manager app
1. We are creating the Views Folder then The shared folder
2. We created the Layout Wich will contain the view that all pages will have
3. We creatde the View start to add the Layout in all the views.
4. Then We created view imports to bring the DTOs and the enums to use(Had to add as project reference)
5. Then we have created the controller that will contain the routes (PersonsController)
6. now we added the index view of the controller we added some content

//--------------------------------- 02. Mock Data
We will create the mock data to populate tables
1. in countries service we added a new boolean in the constructor to initialize the mock data in the countries
2. We added false in the countries test because we don't want to have it initialized.
3. Then In sountries service we have generated a new GUID by clicking in tools and then Create GUID
4. we started adding countries with different GUIDs
5. Now we have to add the boolean as well in the person service
6. as well as we populated the data in persons if the boolean is initialized to true
7. we use Mockaroo to generate random data

//---------------------------------03. List View
We will create the list in the index
1. We will inject the IPersonService into the controller to instiate in runtime the person
2. We added in program.cs the IoC container to be scoped
3. Now back into the persons controller then we added the IPersonService as DI and initialized it in the constructor
4. now We passed to the vieew the strong type model PersonResponse as IEnumerable
 
//--------------------------------04. Search in List View
We will create the search dropdown and the clear search
1. In index view we will create the presentation
2. put all in a box flex to show the elements side by side
3. first element dropdown list
4. then we use flex-1 wchich means we eill only take only one portion
5. Then we populate the previous view to show in the view
6. for the purpose of creating the get requests we will add a form
7. in order to use searchstring in the view it should match the exact name as the one in the controller in the insex area to work

//------------------------------04.5. Search in List View 2
1. In this first step we added searchBY and Search String to concatenate the searchBy and searchString in the controller
2. Now we used GetFilteredPersons to foilter the persons we want to get according to the search
3. now in PersonService we changed the switch of getperson by ID instead of using person now we are using person response to avoid conflicts because we use that name in the controller
4. at the end of the controller, we are adding the values in the viewbag to persist in the view the data queried.

//------------------------------ 05. Sort in List View
We have to order either ascending or descending order
1. in Persons Controller we receive string sortBy
2. Now we will populate the view
3. We added ascending and descending order in the view

//------------------------------05.5 Sort in List View 2
WE are trying to get ordered every value, so we are trying to find a easy way.
1. We are going to create a partial view in shared GridColumnHeader this is done because then we can invoke the same but passing different parameters trough the viewbag
2. then in index we call the partial view, we came in here to suipply a different value everytime we click in the hiperlink to dsort values
3. Now we are population Index 
4. Now we created the exact width
5. We started to use the convertperson to person this was used since we were having the country ID which belongs to another DTO so PersonToperson was not getting that value

//---------------------------06. Create View
We will create the create person view
1. In the persons controller we added another method called Create that will be called whenever we access the page create
2. after then we created the actual view filling up all the form to get the info from person
3. we added  <a href="~/persons/create">Create Person</a> in the index view
4. We are going to get the name of the countries in the dropdown by passong the values inside of the controller, so we will bring the list of countries in the copntroller

//---------------------------06. Create View part 2
1. in the radio buttons we added the css class called "ml" -> margin left
2. we are adding address and Receive newsletters
3. after submitting a dummy person in the form we encocunter a problem that was just getting the wrong method(get) and we wanted to make a post since it is a submision
4. We created then the http post in the controller
5. we checked the model state after the submission with model.state
6. if there are errors they are stored in viewbag and then exported into the view to be shown to the user.

//--------------------------07. Attribute Routing
We will use and understand how to create something like [Route("mycontroller")] //Acts as prefix
1. we added the route persons in controllers on top
2. so instead of writing index I can just use [action]