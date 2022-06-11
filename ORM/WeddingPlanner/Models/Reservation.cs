using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId {get;set;}
        public int UserId {get;set;}
        public User UserThatRSVPed {get;set;}
        public int WeddingId {get;set;}
        public Wedding WeddingRSVPed {get;set;}

        public Reservation(int userid, int weddingid)
        {
            UserId = userid;
            WeddingId =weddingid;
        }

        public Reservation()
        {}
    }
}