using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactWebApp.Models
{
    public class ContactsViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string HomePhone { get; set; }

        public string ImageBase64Encoded { get; set; }
    }
}