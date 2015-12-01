using System.Collections.Generic;

namespace RoomM.WebApp.Models.RoomM
{
    public class JsonRegisterViewModel
    {
        public List<List<int>> TimeTableList { get; set; }
        public List<ItemList> StartList { get; set; }
        public bool TimeTableChange { get; set; }
        public string StartDay { get; set; }
        public string EndDay { get; set; }
    }
}