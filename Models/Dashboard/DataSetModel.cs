using System.Collections.Generic;

namespace champi.Models.Dashboard
{
    public class DataSetModel
    {
        public string Label { get; set; }
        public List<int> Data { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public int BorderWidth { get; set; }
    }
}