using System;
using System.Collections.Generic;
using System.Text;

namespace STLNormalSwitcher {
    /// <summary>
    /// A list of Triangles with additional information
    /// about the type of changes made.
    /// </summary>
    public class Event : List<Triangle> {

        /// <summary>
        /// Enumeration for the different types of Events
        /// </summary>
        public enum EventType { SwitchAll, Edit, Add, Remove }

        #region Fields

        public EventType eventType;

        #endregion

        #region Constructors

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Event() { }

        /// <summary>
        /// Constructor that sets the EventType
        /// </summary>
        /// <param name="type">EventType</param>
        public Event(EventType type) { this.eventType = type; }

        /// <summary>
        /// Constructor that adds a single Triangle to the list
        /// and sets the EventType.
        /// </summary>
        /// <param name="triangle">Triangle to be added.</param>
        /// <param name="type">EventType</param>
        public Event(Triangle triangle, EventType type) {
            this.Add(triangle);
            this.eventType = type;
        }

        #endregion

        #region Methods

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

        #endregion
    }

}
