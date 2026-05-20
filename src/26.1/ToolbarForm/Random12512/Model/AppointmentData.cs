using System;

namespace Random12512.Model {
    public class AppointmentData(int id,
            DateTime startTime,
            DateTime endTime,
            string subject,
            string notes,
            int resourceId,
            int labelId,
            int statusId,
            string recurrenceInfo) {
        public int Id { get; set; } = id;
        public DateTime StartTime { get; set; } = startTime;
        public DateTime EndTime { get; set; } = endTime;
        public string Subject { get; set; } = subject;
        public string Notes { get; set; } = notes;
        public int ResourceId { get; set; } = resourceId;
        public int LabelId { get; set; } = labelId;
        public int StatusId { get; set; } = statusId;
        public string RecurrenceInfo { get; set; } = recurrenceInfo;
    }

    public class CalendarResource(int id, string name, Color color, int parentId, bool isVisible) {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public int ParentId { get; set; } = parentId;
        public bool IsVisible { get; set; } = isVisible;
        public Color Color { get; set; } = color;
    }
}