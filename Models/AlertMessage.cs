using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaloriesCount.Models
{
    // Class used to pass bootstrap class name and alert message to view through tempdata.
    public class AlertMessage
    {
        public string CssClassName;
        public string Title;
        public string Message;
    }
}