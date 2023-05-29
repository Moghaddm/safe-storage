# Safe Storage in <b>.Net Core</b>

Maybe You are Working On a Project 🚀

Which Had <b>Sesitive Datas</b> 💢
Like Connection Strings , Api Keys , Tokens(CSRF,JWT), Passwords , etc.


...


<ul>
	<li>First Thing That is Important is Protection of These Datas on Every Existed Environment (Production,Staging,Development)</li>	
	<li>Second Thing That is How to Send/Receive it In Process of Deploy , Build , Run</li>	
	<li>Third and Most Important Thing is <h3>No Must Sensitive Data Particular ConnectionString in Source Code of Your Project 😠</h3></li>	
</ul>



...


in .Net Core Exist Ways For Store Sensitive Datas in 

DEVELOPMENT Environment :

1. User Secrets
2. Environment Variables
3. Jwt Secret Manager

PRODUCTION Environment :
1. CI/CD Principles
2. Azure Key Vault
3. Providers
4. Docker , Kubertenes

STAGING Environment : 
is Used Only For Being Ready our App for Deploy on Production and Real World Processes

...


I Just Prevent Development Env


USER SECRETS

User Secret are Store Data in 

	%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json

File System Path and On Linux (Like Kali or Ubuntu)
	
	~/.microsoft/usersecrets/<user_secrets_id>/secrets.json



...

1.Create Simple WebApi Project (Create) :

	dotnet new webapi --name SafeStorage -output <Path>
	
2.Enable User Secrets in Project (Initialize) :
	
	dotnet user-secrets init
	
	
After That The UserSecretId Added To Yout csproj File 

	<UserSecretsId>2b61f88d-e83d-46f7-91da-faa5581c9d07</UserSecretsId>



3.Set Yout Secret (Set) :

	dotnet user-secrets set "ConnectionString:MSSQL" "Data Source = localhost ...."
	
...



STORE AND SECRET DATA FROM JSON FILE LIKE appsettings.json

1. Create and Enable Secrets Like Pervious Steps
2. Store Data From appsettings.json : 


		type ./appsettings.json | dotnet user-secrets set
		
		Successfully saved 3 secrets to the secret store.
	
...


HOW TO DELETE SETS ?

1. Remove All :

		dotnet user-secrets clear


2. Remove One : 

		dotnet user-secrets remove "ConnectionStrings:MSSQL"
		
...



HOW TO USE THAT ?

1.In Program.cs :

	var builder = WebApplication.CreateBuilder(args);
	var movieApiKey = builder.Configuration["ConnectionStrings:MSSQL"];

	var app = builder.Build();

	app.MapGet("/", () => movieApiKey);

	app.Run();
	
Configuration Automaticaly Read and Stores Datas From secrets.json and Return it

2. Map to A Simple C# Class :

		public class ConfigurationSettings
		{
    	public string MSSQLConnectionString { get; set; }
		}
		
	
	Now Bind Data To Class 
	
		ConfigurationSettings mapClass = builder.Configuration.GetSection("ConnectionStrings:MSSQL").Get<ConfigurationSettings>()!;

Return it :

	app.MapGet("/",()=> {
    return ConnectionString;	
	});
	app.MapGet("/class",() => {
    return mapClass;
	});
	
	
Run Project : 

	dotnet run






<br>
<br>
<br>
<br>
<br>
<br>
	
<b>Thank You </b> 🚀



