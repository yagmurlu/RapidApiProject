namespace RapidApiProject.Models
{
    public class HotelListViewModel
    {

       public Result[] results { get; set; }
        public class Result
        {
            public int id { get; set; }         
            public string name { get; set; }
            public float reviewScore { get; set; }
        }
    }
}
