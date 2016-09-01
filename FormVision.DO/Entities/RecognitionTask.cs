using System;
using FormVision.Enums;
using Realms;

namespace FormVision.DO.Entities
{
    public class RecognitionTask : RealmObject, IEntity
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        private int GroupRaw { get; set; }


        [ObjectId]
        private string IdRaw { get; set; }

        [Ignored]
        public TaskGroupKind Group
        {
            get { return (TaskGroupKind) GroupRaw; }
            set { GroupRaw = (int) value; }
        }

        [Ignored]
        public Guid Id
        {
            get { return Guid.Parse(IdRaw); }
            set { IdRaw = value.ToString("N"); }
        }
    }
}