using System;
using System.Collections.Generic;
using System.Text;

namespace STLNormalSwitcher {
    public class Event : List<Triangle> {

        public enum EventType { SwitchAll, Edit, Add, Remove }
        public EventType eventType;

        public Event() { }

        public Event(EventType type) {
            this.eventType = type;
        }

        public Event(Triangle triangle, EventType type) {
            this.Add(triangle);
            this.eventType = type;
        }

        public Event(IEnumerable<Triangle> triangles, EventType type){
            this.AddRange(triangles);
            this.eventType = type;
        }

        /// <summary>
        /// Returns a copy of this Event.
        /// </summary>
        /// <returns>Copy of this Event</returns>
        public Event Copy() {
            Event ev = new Event(this.eventType);
            for (int i = 0; i < this.Count; i++) {
                ev.Add(this[i].Copy());
            }
            return ev;
        }
    }

}
