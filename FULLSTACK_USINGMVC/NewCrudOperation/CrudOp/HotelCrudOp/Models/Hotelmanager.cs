using BOL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class Hotelmanger{
    public static List<Hotel> GetallHotels(){
        List<Hotel> allHotels=new List<Hotel>();
        string conString=@"server=localhost;port=3306;user=root;password=Rupesh@123$;database=hotel";
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{
            con.Open();
            MySqlCommand cmd=new MySqlCommand();
            string query="Select * from hotels";
            cmd.Connection=con;
            cmd.CommandText=query;
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read())
            {
              int id=int.Parse(reader["HotelID"].ToString());
              string name=reader["Hotelname"].ToString();
              string city=reader["HotelCity"].ToString();

              Hotel newH1=new Hotel(id,name,city);
              allHotels.Add(newH1);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return allHotels;
    }

    public static void InsertHotel(Hotel hotel)
    {
        string conString=@"server=localhost;port=3306;user=root;password=Rupesh@123$;database=hotel";
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{
            con.Open();
            MySqlCommand cmd=new MySqlCommand();
            string query="insert into hotels values("+hotel.HotelID+",'"+hotel.Hotelname+"','"+hotel.HotelCity+"');";
            cmd.Connection=con;
            cmd.CommandText=query;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Added Successfully");
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }
    }
    public static void DeleteHotel(int id)
    {
        string conString=@"server=localhost;port=3306;user=root;password=Rupesh@123$;database=hotel";
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=conString;
        try{
            con.Open();
            MySqlCommand cmd=new MySqlCommand();
              cmd.Connection=con;
            string query="Delete from hotels where HotelID="+id;
          
            cmd.CommandText=query;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Deleted Successfully");
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }finally{
            con.Close();
        }
    }
}