using System;
namespace Main.Dto
{
    public class NewOrderDto
    {
        public DateTime RentFrom { get; set; }
        public DateTime RentTo { get; set; }
        public Guid FilmId { get; set; }
        public Guid UserId { get; set; }
        public bool UseBonuses { get; set; }
    }
}
