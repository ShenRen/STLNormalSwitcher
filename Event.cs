using System;
using System.Collections.Generic;
using System.Text;

namespace STLNormalSwitcher {
    public class Event : List<Triangle> {

        public enum EventType { Switch, Edit, Add }
        public EventType eventType;

        /// <summary>
        /// Returns a copy of this Event.
        /// </summary>
        /// <returns>Copy of this Event</returns>
        public Event Copy() {
            Event ev = new Event();
            for (int i = 0; i < this.Count; i++) {
                ev.Add(this[i].Copy());
            }
            ev.eventType = this.eventType;
            return ev;
        }
    }

}
