using System.ComponentModel.DataAnnotations;

namespace Project_mobile_app.Models
{
    public class DisplayObjectStopDisplayAfterDisplay
    {
#nullable disable
        public Stop Stop { get; set; }

        public int StopId { get; set; }

        public DisplayObject DisplayObject { get; set; }

        public int DisplayObjectId { get; set; }

        public short Position { get; set; }
    }
}
