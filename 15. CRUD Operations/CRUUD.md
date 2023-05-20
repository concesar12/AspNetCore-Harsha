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