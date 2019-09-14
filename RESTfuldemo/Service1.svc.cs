using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace RESTfuldemo
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        private static List<String> First = new List<String>
        (new String[] { "Arrays", "Queues", "Stacks" });

        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        [WebGet(UriTemplate = "/Tutorial")]

        public String GetAllTutorial()
        {
            int count = First.Count;
            String TutorialList = "";
            for (int i = 0; i < count; i++)
                TutorialList = TutorialList + First[i] + ",";
            return TutorialList;
        }

        [WebGet(UriTemplate = "/Tutorial/{Tutorialid}")]

        public String GetTutorialbyID(String Tutorialid)
        {
            int pid;
            Int32.TryParse(Tutorialid, out pid);
            return First[pid];
        }

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, UriTemplate = "/Tutorial", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void AddTutorial(String str)
        {
            First.Add(str);
        }

        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, UriTemplate = "/Tutorial/{Tutorialid}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void DeleteTutorial(String Tutorialid)
        {
            int pid;
            Int32.TryParse(Tutorialid, out pid);
            First.RemoveAt(pid);
        }

        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // Add your operation implementation here
            return;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
