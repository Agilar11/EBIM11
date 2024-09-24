using System.ComponentModel.DataAnnotations;

namespace EBIM.Models
{
	public class Apartment
	{
		public int Id { get; set; }

		[Required]
		public int UserId { get; set; }  // Foreign Key

		[Required]
		[StringLength(100, ErrorMessage = "MTK must be less than 100 characters.")]
		public string MTK { get; set; }  // Required field for MTK

		[Required]
		[StringLength(50, ErrorMessage = "Building name must be less than 50 characters.")]
		public string Building { get; set; }  // Required field for building

		[Required]
		[StringLength(10, ErrorMessage = "Block number must be less than 10 characters.")]
		public string BlockNumber { get; set; }  // Required field for block number

		[Range(1, int.MaxValue, ErrorMessage = "Floor must be greater than 0.")]
		public int Floor { get; set; }  // Floor must be a positive number

		[Required]
		[StringLength(10, ErrorMessage = "Apartment number must be less than 10 characters.")]
		public string ApartmentNumber { get; set; }  // Required field for apartment number

		[Range(1, int.MaxValue, ErrorMessage = "Number of home users must be greater than 0.")]
		public int HomeUserNumber { get; set; }  // Must be a positive integer

		public User User { get; set; }  // Navigation property to User

		// Override Equals to compare apartments based on Id, ApartmentNumber, and UserId
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
				return false;

			Apartment other = (Apartment)obj;
			return Id == other.Id && ApartmentNumber == other.ApartmentNumber && UserId == other.UserId;
		}

		// Override GetHashCode to return a hash based on Id, ApartmentNumber, and UserId
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, ApartmentNumber, UserId);
		}
	}
}