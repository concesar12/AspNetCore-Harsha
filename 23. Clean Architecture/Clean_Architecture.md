//----------------------------------Core
we will focus on the core layer to create clean architecture
1. We have migrated into the core and installed into the core projects nuget packages       
Domain
DTO
Enums
Exceptions
Helpers
obj
ServiceContracts
Services

//---------------------------------02. Infrastructure -ui 
List of packages added:
ui
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.18" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="6.0.18" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="6.0.18">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Rotativa.AspNetCore" Version="1.2.0" />
    <PackageReference Include="Serilog" Version="3.0.0" />
    <PackageReference Include="Serilog.AspNetCore" Version="7.0.0" />
    <PackageReference Include="Serilog.Sinks.MSSqlServer" Version="6.3.0" />
    <PackageReference Include="Serilog.Sinks.Seq" Version="5.2.2" />
    and we added both projects as a reference(core and infrastructure)
3. we have changes the database name too
4. so we will use the code first approach to create the database
5. in package consolo we wioll go to infrastructure and then we will use the next comands:
Add-Migration Initial
Update-Database

//-------------------------------04. Tests
1. We have created a new project and added as a new test -> xunit test project

When organizing this folder we can't forget to use the Item group in the p[roject for the integration tests

