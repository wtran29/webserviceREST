using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Webservice.REST
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TutorialService
    {
        private static List<String> first = new List<String>
                    (new String[] { "Arrays", "Queues", "Stacks" });
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

        // Used to define how we can call this method via URL
        [WebGet(UriTemplate = "/Tutorial")]

        // This section of code will go through the list of strings in the "first" variable and return all of them
        public String GetAllTutorial()
        {
            int count = first.Count;
            String TutorialList = "";
            for (int i = 0; i < count; i++)
                TutorialList = TutorialList + first[i] + ",";
                return TutorialList;
        }

        // Getting the web service by ID
        [WebGet(UriTemplate = "/Tutorial/{Tutorialid}")]

        public String GetTutorialbyID(String Tutorialid)
        {
            int pid;
            // int32 function is used to convert the string variable of Tutorialid to an integer
            Int32.TryParse(Tutorialid, out pid);
            return first[pid];

        }

        // Invoke method and specifying the POST method
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/Tutorial", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void AddTutorial(String str)
        {
            first.Add(str);
        }

        // Invoke POST method and specifying the Delete parameter
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/Tutorial/{Tutorialid}", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void DeleteTutorial(String Tutorialid)
        {
            int pid;
            // int32 function is used to convert the string variable of Tutorialid to an integer
            Int32.TryParse(Tutorialid, out pid);
            first.RemoveAt(pid);
        }


    }
        
}
