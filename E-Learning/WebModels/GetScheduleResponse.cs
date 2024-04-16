using E_Learning.Models;

namespace E_Learning.WebModels
{
    public class GetScheduleResponse
    {
        public List<ScheduleResponse> Schedule { get; set; } = new List<ScheduleResponse>();
    }

    public class ScheduleResponse
    {
        public string CouresTitle { get; set; }
        public string Day { get; set; }
        public string Section { get; set; }
        public string TypeClass { get; set; }
    }
}