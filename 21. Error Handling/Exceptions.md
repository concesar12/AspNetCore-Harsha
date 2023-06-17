//--------------------------Exception Middleware handler
Now in our development environment we just show error 500 without error message, so the idea is to handle it with exceptions middlewares, they should be in the begining of execution in order to catch any error in the applciation
1. First thing is to create a new folder called Middlewares
2. Then we create the actual class middleware (called middleware class)

/*Process to create a middleware*/
<p>
// Define the ExceptionHandlingMiddleware class.
// Declare private variables _next, _logger, and _diagnosticContext of types RequestDelegate, ILogger<ExceptionHandlingMiddleware>, and IDiagnosticContext respectively.
// Create the constructor for the ExceptionHandlingMiddleware class, which takes three parameters: next, logger, and diagnosticContext. Assign the parameter values to the respective private variables.
// Define the Invoke method with HttpContext as the parameter. This method is responsible for handling exceptions in the middleware pipeline.
// Inside the Invoke method, wrap the execution of the subsequent middleware (_next(httpContext)) in a try-catch block.
// If an exception occurs during the execution of the subsequent middleware, it will be caught in the catch block.
// Check if the caught exception has an inner exception. If it does, log the inner exception's type and message using the logger. Otherwise, log the caught exception's type and message.
// Set the HTTP response status code to 500 (Internal Server Error).
// Write the message "Error occurred" to the HTTP response.
// Define the ExceptionHandlingMiddlewareExtensions class, which provides an extension method for adding the ExceptionHandlingMiddleware to the HTTP request pipeline.
// Define the UseExceptionHandlingMiddleware extension method for the IApplicationBuilder interface.
// Inside the UseExceptionHandlingMiddleware method, use the UseMiddleware method of the IApplicationBuilder to add the ExceptionHandlingMiddleware to the pipeline.
// Return the modified IApplicationBuilder.
</p>

3. Then in program.cs we have added the exception middleware in the pipeline

//--------------------------02. Custom Exceptions
As a rule it is good to create domein specific exception classes to represent different errors, for example when throwing argument exception
1. First we have generated a new project for exceptions(class library) and created a new class exception
2. We added exceptions as project reference in services and our man app project
3. in person service we have modified person update to throw as an exception InvalidPersonIDException

//--------------------------03. UseExceptionHandler
Now everytime we run exceptions, it will be good to run a page that has an image or something nice for the final user
1. In program.cs we have added an exception handler to catch all errors
2. then we created a new controller to route the errors into a view
3. then we created the actual view and added the error imgae to show to the users
4. Now in the exception middleware we commented out the inmediate response to show the exception handler
5. Now in the error controller we will work on having a peronilized error message thanks to IExceptionHandlerPathFeature

Steps HAndling exceptions: 
Create a model error, Middl;eware, project exception, View in shared, Finnhubexception