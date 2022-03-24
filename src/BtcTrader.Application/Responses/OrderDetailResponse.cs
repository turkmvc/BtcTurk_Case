namespace BtcTrader.Application.Responses
{
    public class OrderDetailResponse
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public byte CityId { get; set; }
        public string CityName { get; set; }
        public short TownId { get; set; }
        public string TownName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public short Year { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Km { get; set; }
        public string Color { get; set; }
        public string Gear { get; set; }
        public string Fuel { get; set; }
        public string FirstPhoto { get; set; }
        public string SecondPhoto { get; set; }
        public string UserInfo { get; set; }
        public long UserPhone { get; set; }
        public string Text { get; set; }
    }
}
