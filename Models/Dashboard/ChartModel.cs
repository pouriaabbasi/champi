using System.Collections.Generic;

namespace champi.Models.Dashboard
{
    public class ChartModel
    {
        public List<string> Labels { get; set; }
        public List<DataSetModel> Datasets { get; set; }
    }
}