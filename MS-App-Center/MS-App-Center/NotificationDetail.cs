using System;
using System.Collections.Generic;

namespace MSAppCenter
{
    public class CustomData
    {
    }

    public class NotificationContent
    {
        public string name { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public CustomData custom_data { get; set; }
    }

    public class NotificationDetail
    {
        public NotificationContent notification_content { get; set; }
        public IList<object> failure_outcomes { get; set; }
        public string notification_id { get; set; }
        public DateTime send_time { get; set; }
        public int pns_send_failure { get; set; }
        public int pns_send_success { get; set; }
        public string state { get; set; }
    }
}
