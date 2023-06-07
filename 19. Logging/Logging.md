//---------------------------------ILogger
We will use all most common types of log
1. in program.cs we created different logs messages
2. we saw it in the kestrel console, we could't see the debug log

//---------------------------------02. Logging Configuration
Problem in this lesson is that we are not getting log information from debug so we will set up the project to have it
1. so in appsettings.Development we have changed the configuration since it is specific for the development environment, we changed to debug

//---------------------------------03. Logging Providers
We will see where all these console logs are displayed from .net application in three places: Console, Debug, EventLog
1. In windows we went to event viewwer and select custom views-> administrative events
2. Now we will create a custom view because we want to show our predefined logs
3. in the right panel we clicked in custom view, then we selected logs of last 24 hours and limited only to .net runtime logs
4. so back in the application we go again to appsettings development and added this "EventLog": {
      "LogLevel": {
        "Default": "Debug"
      }
    }
5. So now in the progrtam.cs we will add all configuration logs that we want and where do we want to show them

//---------------------------------04. ILogger in Controller
So the way to write actual logs in services, controller etc.. we have to inject a service of log type
1. First we go to persons controller and in the private fields we have to add the Ilogger persons controller
2. then we injected in the controller the Ilogger
3. Then we adedd some logs to the first action method
4. so now in persons Service we have to inject the logger to get logs of getfilteredpersons
5. Then We went to repository since it has been used too

//---------------------------------05. HTTP Logging
Here we will trach http resposes, and httprequests 
1. To add it in the application we have to go to program.cs and add it as app.UseHttpLogging
2. We set the logs .net core as Inforation

//---------------------------------06. HTTP Logging Option
by default everything is logged, but we can configure to only log specific stuff
1. So in the program.cs we can add http logging with any option we want to log

//---------------------------------07. Serilog Basics
Serilog is a log framework-> it offers loging to files and databases "sinks" is the logging destination
1. install serilog package
2. we have to enable serilog in the program.cs
3. then we have to install another package serilog.asp.netcore
4. then insettings json we added the serilog
5. like this we have added serilog

//---------------------------------08. Serilog File Sink
So now we will add serilog sink
1. in settings json we have to add the sinks
2. the idea of this is to strore logs separately from console

//---------------------------------09. Serilog Database Sink
We will log into a database with serilog
1. We have to install a package serilog mssqlserver
2. We have to add another sink for the ms sqlserver
3. And then create into the write to
4. then we will add manually a new database by going to database object click on the msslocaldb
5. then we will right click on database and we will create it there

//----------------------------------10. Serilog Seq
Seq is used to monitor the loggs of the application in real time, we will install and use this app
1. first go to google to download SEQ
2. we have to create an account and then we will be able to use the software: admin c6
3. now in the application we have to install a package for serilog seq
4. then in appsettings we have to add the serilog and call it with the port number

//----------------------------------11. Serilog RequestId
it is the individual number for each request, usefull to track requests and responses

//-----------------------------------12. Serilog Enrichers
enriches are the extra description of every log
1. we have to add the enrich in appsettings.json

//----------------------------------13. Serilog IDiagnosticContext
Diagnostic will addd extra values in the logs
1. in the services project we have to install a package: Serilog.Extensions.Hosting
2. then in persons service we added the propperty and inhected in the constructor
3. then we added: _diagnosticContext.Set("Persons", persons); in get filtered persons
4. then in program.cs we addeed the serilog logging
5. but in order to print the actual value we have to gop to entities and override the toString method to show what we want

//----------------------------------14. Serilog Timings
This takes the timing of the execution of the code and print it
1. first we have to install the package in the service project: serilog timings
2. now in get filtered persons in person service we will add the timing
3. we have to mock diagnostic context as well in tests
