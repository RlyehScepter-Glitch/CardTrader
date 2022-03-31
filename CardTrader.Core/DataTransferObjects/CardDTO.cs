namespace CardTrader.Core.DataTransferObjects
{
    public class CardDTO
    {
        public Data[] data { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public CardSet[] card_sets { get; set; }
        public CardImage[] card_images { get; set; }
    }

    public class CardSet
    {
        public string set_name { get; set; }
        public string set_code { get; set; }
        public string set_rarity { get; set; }
    }

    public class CardImage
    {
        public int id { get; set; }
        public string image_url { get; set; }
    }
}
