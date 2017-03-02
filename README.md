# SignalRTest
Essence Of Argan Dev Test

Create a web application that will monitor changes on a SQL table using SignalR Requirements

1) The SQL table should have the following definition: CREATE TABLE DevTest( [ID] int IDENTITY(1, 1) NOT NULL, [CampaignName] varchar(255) NULL, [Date] datetime NULL, [Clicks} int NULL, [Conversions] int NULL, [Impressions] int NULL, [AffiliateName] varchar(255) NULL )

2) All data access should adhere to the repository and unit of work design patterns

3) There should be a view that implements SignalR and displays the changes to the SQL table in real time.

4) There should be a view that allows the user to make changes to the DevTest table (insert, update, delete) 


Project included:

1: SignalRTest.Data
- EF database backend
- Generic Repository
- Unit of Work

2: SignalRTest - ASPNET MVC Project
- Unity Container for DI
- SignalR for real time data push
- AutoMapper for Object mapping
- jQuery, jQuery UI, Bootstrap for UI
