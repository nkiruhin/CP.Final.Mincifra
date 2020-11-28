using CP.Final.Mincifra.Core.Events;
using CP.Final.Mincifra.SharedKernel;
using System;
using System.Collections.Generic;

namespace CP.Final.Mincifra.Core.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public bool IsDone { get; private set; }

        public void MarkComplete()
        {
            IsDone = true;

            Events.Add(new ToDoItemCompletedEvent(this));
        }

        public override string ToString()
        {
            string status = IsDone ? "Done!" : "Not done.";
            return $"{Id}: Status: {status} - {Title} - {Description}";
        }
    }
    public class Entity : BaseEntity
    {
        public new Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<MetaData> MetaDatas { get; set; }
    }
    public enum LinkType
    {
        Unknown,
        Resides,
        MayHave,
        LocatedOnTheTerritory,
        MayLiveIn,
        MayUse,
        MayRegister,
        MayOwn,
        May,
        RegistersIn,
        Manages,
        CanBeACitizen,
        WorksIn,
        MayContact,
        CalculatedBy,
        Receives,
        MayWork,
        MayBe,
        Has,
        CarriedOutBy,
        MayVisit,
        Provides,
        Includes,
        TerritorialUnit,
        ConsistsOf,
        IsAn
    }
    public class Link : BaseEntity
    {
        public new Guid Id { get; set; }
        public Guid FromEntityId { get; set; }
        public Guid ToEntityId { get; set; }
        public LinkType Type { get; set; }
    }
    public class MetaData : BaseEntity
    {
        public new Guid Id { get; set; }
        public Guid EntityId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
