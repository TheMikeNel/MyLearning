namespace Mod8_Collections
{
    public struct Note
    {
        public string FIO { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }

        public Note(string fio, string street, string houseNum, string flatNum, string mobilePhone, string homePhone)
        {
            FIO = fio;
            Street = street;
            HouseNumber = houseNum;
            FlatNumber = flatNum;
            MobilePhone = mobilePhone;
            HomePhone = homePhone;
        }
    }
}
