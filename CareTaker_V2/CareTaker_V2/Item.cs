using System;

namespace CareTaker_V2
{
    [Serializable]
    public class Item
    {   // Template für Produkte.
        public string NAME { get; set; }
        public string[] TAGS { get; set; }
        public string CATEGORY { get; set; }
        public string PLACE { get; set; }
    }
}
