using CP.Final.Mincifra.Core.Entities;
using CP.Final.Mincifra.SharedKernel;

namespace CP.Final.Mincifra.Core.Events
{
    public class ToDoItemCompletedEvent : BaseDomainEvent
    {
        public ToDoItem CompletedItem { get; set; }

        public ToDoItemCompletedEvent(ToDoItem completedItem)
        {
            CompletedItem = completedItem;
        }
    }
}