using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaloriesCount.HtmlHelpers
{
    /* Html helper used to get the current controller and action name from the routeData. This is then 
     * used to add a css active class to the current link (controller/ action) on the sidebar. */
    public static class HtmlHelpers
    {
        public static string IsSelected(this HtmlHelper html, string controllers = "", string actions = "", string cssClass = "active")
        {
            // Get the viewContext from the current view.
            ViewContext viewContext = html.ViewContext;
            bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

            if (isChildAction)
                viewContext = html.ViewContext.ParentActionViewContext;
            
            // Access the URL route data from the viewContext object.
            RouteValueDictionary routeValues = viewContext.RouteData.Values;

            // convert the current action and current controller to strings
            string currentAction = routeValues["action"].ToString();
            string currentController = routeValues["controller"].ToString();

            // Check if string is empty or not
            if (String.IsNullOrEmpty(actions))
                actions = currentAction;

            if (String.IsNullOrEmpty(controllers))
                controllers = currentController;
            
            // Create a string array that holds all the valid actions in the parameter.
            string[] acceptedActions = actions.Trim().Split(',').Distinct().ToArray();

            // Create a strin garray that holds all the valid controllers in the parameter.
            string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

            // Return the 'active' class if the current action is an accepted action from the parameter and the current
            // controller is an accepted controller from the parameter.
            return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ?
                cssClass : String.Empty;
        }
    }
}