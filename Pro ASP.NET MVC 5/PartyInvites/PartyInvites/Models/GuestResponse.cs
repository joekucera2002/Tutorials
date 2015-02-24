using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public Boolean? WillAttend { get; set; }
    }
}