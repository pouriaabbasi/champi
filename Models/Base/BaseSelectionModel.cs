namespace champi.Models.Base
{
    public class BaseSelectionModel
    {
        public long Key { get; set; }
        public string Caption { get; set; }
        public long? ParentKey { get; set; }
        public string ParentCaption { get; set; }
    }
}