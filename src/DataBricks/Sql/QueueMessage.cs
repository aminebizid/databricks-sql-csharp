using System.Collections.Generic;

namespace DataBricks.Sql
{
    public class QueueMessage
    {
        public object[] Row { get; set; }
        public bool Stop { get; set; }
    }
}