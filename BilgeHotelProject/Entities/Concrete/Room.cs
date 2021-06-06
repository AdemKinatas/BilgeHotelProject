using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Room:IEntity
    {
        public Room()
        {
            if (RoomTypeId == 1)
            {
                RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet";
            }
            else if(FloorNumber == 3 || FloorNumber ==4)
            {
                RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar,Balkon";
            }
            else
            {
                RoomFeatures = "Klima,Tv,Saç Kurutma Makinası,Kablosuz İnternet,Mini Bar";
            }
        }
        public int ID { get; set; }
        public short RoomNumber { get; set; }
        public short FloorNumber { get; set; }
        public short SingleBadCount { get; set; }
        public short? DoubleBadCount { get; set; } = 0;
        public short Capacity { get { return (short)((SingleBadCount * 1) + (DoubleBadCount * 2)); } }
        public string RoomDescription { get; set; }
        public string RoomFeatures { get; set; } 
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
        public int RoomStatusId { get; set; }
        public virtual RoomStatus RoomStatus { get; set; }
        public virtual List<RoomImage> RoomImages { get; set; }
        public virtual List<Booking> Bookings { get; set; }
        public List<Guest> Guests { get; set; }
    }
}
