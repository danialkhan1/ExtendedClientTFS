using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.TeamFoundation;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace TFS_ExtendedClient_Test
{
    class Program
    {
        static void Main(string[] args)
        {            // Connect to the server and the store, and get the WorkItemType object
            // for user stories from the team project where the user story will be created. 
            Uri collectionUri = (args.Length < 1) ?
                new Uri("http://localhost:8080/tfs/DefaultCollection") : new Uri(args[0]);
            TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(collectionUri);
            WorkItemStore workItemStore = tpc.GetService<WorkItemStore>();
            Project teamProject = workItemStore.Projects["SandboxProject"];
            
            //WorkItemType workItemType = teamProject.WorkItemTypes["User Story"];
            WorkItemType workItemType = teamProject.WorkItemTypes["Test Plan"];

            // Create the work item. 
            WorkItem userStory = new WorkItem(workItemType)
            {
                // The title is generally the only required field that doesn’t have a default value. 
                // You must set it, or you can’t save the work item. If you’re working with another
                // type of work item, there may be other fields that you’ll have to set.
                Title = "Recentlyorderedmenu",
                Description =
                    "New Test Plan"
            };

            // Save the new user story. 
            userStory.Save();
        }
    }
}

