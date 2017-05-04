<<<<<<< HEAD
<<<<<<< Upstream, based on bcd2e0840fe77e5d937ae67c9fa959ce0f727b04
This README.md file is displayed on your project page. You should edit this 
file to describe your project, including instructions for building and 
running the project, pointers to the license under which you are making the 
project available, and anything else you think would be useful for others to
know.

We have created an empty license.txt file for you. Well, actually, it says,
"<Replace this text with the license you've chosen for your project.>" We 
recommend you edit this and include text for license terms under which you're
making your code available. A good resource for open source licenses is the 
[Open Source Initiative](http://opensource.org/).

Be sure to update your project's profile with a short description and 
eye-catching graphic.

Finally, consider defining some sprints and work items in Track & Plan to give 
interested developers a sense of your cadence and upcoming enhancements.
=======
# ASP.NET Core ToDo Sample using PostgreSQL and Entity Framework Core

This application demonstrates how to use the ElephantSQL PostgreSQL Database Service in an ASP.NET Core application running on Bluemix.

[![Deploy to Bluemix](https://bluemix.net/deploy/button.png)](https://bluemix.net/deploy)

## Running the app on Bluemix

1. Create a Bluemix Account

  [Sign up][sign_up] in Bluemix, or use an existing account.

1. Download and install the [Cloud-foundry CLI][cloud_foundry] tool

1. Connect to Bluemix in the command line tool and follow the prompts to log in.

  ```sh
  cf login -a https://api.ng.bluemix.net
  ```

1. Create the ElephantSQL service instance in Bluemix
  ```sh
  cf create-service elephantsql turtle elephant-sql-service
  ```

1. Push the app to Bluemix
  ```sh
  cf push
  ```

## Run the app locally

1. If you do not already have a Bluemix account, [sign up here][sign_up]
1. If you have not already, install ASP.NET Core and the Dotnet CLI by following the [Getting Started][] instructions
1. Clone the app to your local environment from your terminal using the following command:

  ```sh
  git clone https://github.com/IBM-Bluemix/aspnet-core-todo.git
  ```

1. `cd` into the newly created directory
1. Create an ElephantSQL service instance using the Bluemix UI or the following command:

  ```sh
  cf create-service elephantsql turtle elephant-sql-service
  ```

1. Copy the value for the service credentials from your ElephantSQL service instance in Bluemix and paste it in the `src/EFCoreToDo/vcap-local.json` file
1. Restore required Nuget packages

  ```sh
  dotnet restore
  ```

1. Run the application

  ```sh
  dotnet run -p src/EFCoreToDo
  ```

1. Access the running app in a browser at [http://localhost:5000](http://localhost:5000)

## Decomposition Instructions

The primary purpose of this demo is to provide a sample application which uses Entity Framework to connect to the ElephantSQL service in Bluemix.
Most of the relevant code for this integration is located within the `src/EFCoreToDo/Startup.cs` file.

## Troubleshooting

The primary source of debugging information for your Bluemix app is the logs.  To see them, run the following command using the [Cloud Foundry CLI][cloud_foundry]:

```sh
cf logs aspnet-core-todo --recent
```

Replace `aspnet-core-todo` with the actual name of your application in Bluemix.

## Contribute

We are more than happy to accept external contributions to this project, be it in the form of issues or pull requests.  If you find a bug, please report it via the [issues section][repo_issues] or, even better, fork the project and submit a pull request with your fix!  Pull requests will be evaluated on an individual basis based on value add to the sample application.

[Getting Started]: https://www.microsoft.com/net/core
[sign_up]: http://bluemix.net/
[cloud_foundry]: https://github.com/cloudfoundry/cli
[repo_issues]: https://github.com/IBM-Bluemix/aspnet-core-todo/issues
>>>>>>> 4a6edc1 Add project files.
=======
# ASP.NET Core ToDo Sample using PostgreSQL and Entity Framework Core

This application demonstrates how to use the ElephantSQL PostgreSQL Database Service in an ASP.NET Core application running on Bluemix.

[![Deploy to Bluemix](https://bluemix.net/deploy/button.png)](https://bluemix.net/deploy)

## Running the app on Bluemix

1. Create a Bluemix Account

  [Sign up][sign_up] in Bluemix, or use an existing account.

1. Download and install the [Cloud-foundry CLI][cloud_foundry] tool

1. Connect to Bluemix in the command line tool and follow the prompts to log in.

  ```sh
  cf login -a https://api.ng.bluemix.net
  ```

1. Create the ElephantSQL service instance in Bluemix
  ```sh
  cf create-service elephantsql turtle elephant-sql-service
  ```

1. Push the app to Bluemix
  ```sh
  cf push
  ```

## Run the app locally

1. If you do not already have a Bluemix account, [sign up here][sign_up]
1. If you have not already, install ASP.NET Core and the Dotnet CLI by following the [Getting Started][] instructions
1. Clone the app to your local environment from your terminal using the following command:

  ```sh
  git clone https://github.com/IBM-Bluemix/aspnet-core-todo.git
  ```

1. `cd` into the newly created directory
1. Create an ElephantSQL service instance using the Bluemix UI or the following command:

  ```sh
  cf create-service elephantsql turtle elephant-sql-service
  ```

1. Copy the value for the service credentials from your ElephantSQL service instance in Bluemix and paste it in the `src/EFCoreToDo/vcap-local.json` file
1. Restore required Nuget packages

  ```sh
  dotnet restore
  ```

1. Run the application

  ```sh
  dotnet run -p src/EFCoreToDo
  ```

1. Access the running app in a browser at [http://localhost:5000](http://localhost:5000)

## Decomposition Instructions

The primary purpose of this demo is to provide a sample application which uses Entity Framework to connect to the ElephantSQL service in Bluemix.
Most of the relevant code for this integration is located within the `src/EFCoreToDo/Startup.cs` file.

## Troubleshooting

The primary source of debugging information for your Bluemix app is the logs.  To see them, run the following command using the [Cloud Foundry CLI][cloud_foundry]:

```sh
cf logs aspnet-core-todo --recent
```

Replace `aspnet-core-todo` with the actual name of your application in Bluemix.

## Contribute

We are more than happy to accept external contributions to this project, be it in the form of issues or pull requests.  If you find a bug, please report it via the [issues section][repo_issues] or, even better, fork the project and submit a pull request with your fix!  Pull requests will be evaluated on an individual basis based on value add to the sample application.

[Getting Started]: https://www.microsoft.com/net/core
[sign_up]: http://bluemix.net/
[cloud_foundry]: https://github.com/cloudfoundry/cli
[repo_issues]: https://github.com/IBM-Bluemix/aspnet-core-todo/issues
>>>>>>> c6052c99afcf6d2c3fa2c9f6f2436ca4f979a2da
