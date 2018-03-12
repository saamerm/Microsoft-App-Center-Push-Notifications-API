using System;
using System.Collections.Generic;

namespace MSAppCenter
{
    public class Notification
    {
        public string notification_id { get; set; }
        public string name { get; set; }
        public DateTime send_time { get; set; }
        public int pns_send_failure { get; set; }
        public int pns_send_success { get; set; }
        public string state { get; set; }
    }

    public class Notifications
    {
        public IList<Notification> values { get; set; }
    }
}
