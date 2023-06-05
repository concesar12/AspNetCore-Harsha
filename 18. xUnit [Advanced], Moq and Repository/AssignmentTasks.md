//-----View
1. Create new View Stock/Explore X
2. Generate icon and information of the stock when selected X
3. Create Hyperlink show all stocks X
3. Add View Components
3. Add in Layout the views
3. Add imports
3. Add selected stock
3. Change index trade
//-----Architecture
4. Use a repository to access DB X
5. Add to app settings the new stocks "Top25PopularStocks" X
6. add Top25PopularStocks to trading options in order to use it X   
6. Add Get stocks and SearchStocks in IFinhubb X
7. implement the methods for Stock repository X
8. implement the methods for Finnhub repository X
8. Add repository scope to the program.cs X
8. Create a new view model class Stocke for explore X
9. create new action method for stock controller explorer X
9. Create Stock controller X
10. Added repository contracts for finmhubrepository X
11. Added repository contracts for StockService X
12. Add changes in Interface for finnhub service (Get stocks, search stocks) X
12. Add changes in Interface for Stock service X
12. Add implementation FOR Interface for finnhub service X
12. Add implementation FOR Interface for Stock service X

//----Testing
10. use autofixture X
11. Use moq X
12. Fix tests to use repository instead X
13. Create controller test cases
14. Create integration test case
15. We had to add as well the key value in config webhost


For finhhub create http client
//Create http client
//Create http request
//Send request To Finnhub API
//read response body
//Convert response body (from JSON into dictionary)
//Validation of data (error or null)
//return response dictionary back to the caller