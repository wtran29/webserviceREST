# webserviceREST
Testing REST API development with C#, WCF web services, .NET and Visual Studios 2019

- Created svc file to implement the code
- Configured the Web.config file to change behavior to WebHttp to make it RESTful
- Created endpoints GET, POST, DELETE using WebGet and WebInvoke functions with RequestFormat/ResponseFormat in json.
- Tested endpoints using Fiddler and running localhost on Google Chrome

### How it works

On Visual Studios, open the project then right click and set as Startup Project. Run the project.
On Fiddler, Set the host, content-type: application/json.

Test on Fiddler:

GET http://localhost:65067/TutorialService.svc/Tutorial - Shows list of strings

GET http://localhost:65067/TutorialService.svc/Tutorial/{pid} - Shows the particular string assigned to that pid

POST http://localhost:65067/TutorialService.svc/Tutorial, Request Body: {'str': '[your string here]'} - Adds your string into the list

DELETE http://localhost:65067/TutorialService.svc/Tutorial/{pid} - Delete the string assigned to that pid from the list
