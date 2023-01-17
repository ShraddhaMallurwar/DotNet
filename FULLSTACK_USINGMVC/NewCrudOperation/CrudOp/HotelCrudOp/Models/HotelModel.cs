namespace BOL;

public class Hotel{
    public int HotelID{get;set;}
    public string? Hotelname{get;set;}
    public string? HotelCity{get;set;}

    public Hotel()
    {

    }
    public Hotel(int id,string nm,string city)
    {
        this.HotelID=id;
        this.Hotelname=nm;
        this.HotelCity=city;
    }
}