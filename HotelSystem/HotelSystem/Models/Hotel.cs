﻿namespace HotelSystem.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        //Navigation Properties
        public List<HotelRoom> HotelRoom { get; set; }



    }
}
