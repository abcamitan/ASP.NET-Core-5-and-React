# ASP.NET-Core-5-and-React

My very first ASP.Net Core 5.0 with ReactJS called Ticketing System.

This project is created using a decoupled `ASP.NET Core 5` (Backend) and `ReactJS` (Frontend).

For frontend, is using Typescript language and for the UI/UX design is using Material-UI (<https://material-ui.com/>).

For backend, is using CosmosDb to store the data.

## Frontend

1. Created using `create-react-app` with Typescript

    ```shell
    npx create-react-app my-app --template typescript
    ```

2. For Material-UI set-up, need to follow the instructions in <https://material-ui.com/guides/minimizing-bundle-size/#option-2>.

## Backend

1. Need to create CosmosDb under Azure account and you can use [Free Tier](https://aka.ms/cosmos-free-tier). Once created, copy the URI and Primary from your Cosmos Db `Keys` page.
2. Copy `appsettings.json` and save as `appsettings.Development.json` file at the same location. Then, update the `Url` and `Key` copied from previous step.
3. The controllers and services are created based from [Microsoft Docs - CosmosDb sample](https://docs.microsoft.com/en-us/azure/cosmos-db/sql-api-dotnet-application)
4. To run locally, use `dotnet run` from command line to run the backend services.
5. To initialize the CosmosDb with sample data you can run the `https://localhost:5001/api/user/initialize` and `https://localhost:5001/api/ticket/initialize` via browser or postman.
