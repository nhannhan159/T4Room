using System.Collections.Generic;

namespace RoomM.WebApp.Models.RoomM
{
    public class RegisterChangeSelectViewModel
    {
        public List<ItemList> StartList { get; set; }
        public List<ItemList> LengthList { get; set; }
    }

    public class ItemList
    {
        public string ID { get; set; }
        public string Value { get; set; }
        /*public int MaxFree { get; set; }
        public List<ChildItem> GenerateNumFree {
            get {
                List<ChildItem> lst = new List<ChildItem>();
                for (int i = 1; i <= MaxFree; ++i)
                    lst.Add(new ChildItem {
                        ID = i,
                        Value = i + " x 50 mins"
                    });
                return lst;
            }
        }*/
    }

    public class ChildItem
    {
        public int ID { get; set; }
        public string Value { get; set; }
    }
}