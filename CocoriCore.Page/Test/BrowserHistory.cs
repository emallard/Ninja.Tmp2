using System.Collections.Generic;
using System.Text;

namespace CocoriCore.LeBonCoin
{

    public enum HistoryEventType
    {
        Follow,
        Display,
        Submit,
        FormRedirect
    }

    public class HistoryEvent
    {
        public string Id;
        public object Message;
        public HistoryEventType EventType;
    }

    public class BrowserHistory
    {
        public List<HistoryEvent> Events = new List<HistoryEvent>();

        public void Event(string id, HistoryEventType eventType, object message)
        {
            this.Events.Add(new HistoryEvent() { Id = id, EventType = eventType, Message = message });
        }

        public string Summary()
        {
            var sb = new StringBuilder();
            var previousId = "";
            foreach (var e in Events)
            {
                if (e.Id != previousId)
                {
                    sb.AppendLine(e.Id + ":");
                    previousId = e.Id;
                }

                sb.AppendLine($"  - {e.Message.GetType().Name} [{e.EventType}]");
            }

            return sb.ToString();
        }
    }
}
