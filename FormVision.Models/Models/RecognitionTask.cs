using FormVision.Enums;

namespace FormVision.Models.Models
{
    public class RecognitionTask : EntityModel
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public TaskGroupKind Group { get; set; }
    }
}