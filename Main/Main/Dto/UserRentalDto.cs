using Common.DataTypes.Dto;

namespace Main.Dto
{
    public class UserRentalDto : Rent
    {
        public new bool IsRented { get; set; }
        public new bool IsDue { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
