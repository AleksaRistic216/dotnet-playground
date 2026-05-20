using System;
using System.Collections.Generic;

namespace Random12513.Model {
    public class GanttTaskItem(int id, int? parentId, DateTime startDate, TimeSpan duration, string name, float progress, IEnumerable<int> predecessors) {
        public int Id { get; set; } = id;
        public int? ParentId { get; set; } = parentId;
        public DateTime StartDate { get; set; } = startDate;
        public DateTime FinishDate => StartDate + Duration;
        public TimeSpan Duration { get; set; } = duration;
        public string Name { get; set; } = name;
        public float Progress { get; set; } = progress;
        public IEnumerable<int> Predecessors { get; set; } = predecessors;
    }
}
