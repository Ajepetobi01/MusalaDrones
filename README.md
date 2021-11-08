# MusalaDrones


#Project Details

The Drone Project is a .net 5 project. 

#Run Project

To run this project download the source code from the master branch and restore all nuget packages if required. 

EntityFramework Core in memory was used for the project database. Just run as it is. Data seeded and can be confirmed on launch. Please check SeedData.cs for the seeded data.

For our periodic Task, Hangfire was used and this runs every 5 minutes. kindly check on address/hangfire to view scheduled tasks.

Project Structure:

MusalaDrones.API - This contains the api project where we have the controllers, startup files and hangfire configuration.
MusalaDrones.Core - This is the implementation folder and this contains our interfaces and Concrete classes implementing this interfaces
MusalaDrones.Data - This is our data project. This contains our EntityFramework Model classes
MusalaDrones.Common - This contains all common classes,enums used across all projects.

Issue Request: Kindly send an email to ajepetobi@gmail.com for any requests and information.
