using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BanVe.Models
{
    [Table("TblAdminLogin")]
    public class AdminLogic
    {
        
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập không được trống")]
        [Display(Name = "Tên đăng nhập")]
        [MinLength(5, ErrorMessage = "Trên 5 kí tự"), MaxLength(15, ErrorMessage = "Dưới 15 kí tự")]
        public string AdName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được trống")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Trên 7 kí tự"), MaxLength(20, ErrorMessage = "Dưới 20 kí tự")]
        public string Password { get; set; }
        
    }
    [Table("TblUserAccount")]
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Họ không được trống")]
        [MinLength(1, ErrorMessage = "Trên 1 kí tự"), MaxLength(20, ErrorMessage = "Dưới 20 kí tự")]
        public string FistName { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Tên không được trống")]
        [MinLength(1, ErrorMessage = "Trên 1 kí tự"), MaxLength(20, ErrorMessage = "Dưới 20 kí tự")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được trống")]
        [MinLength(5, ErrorMessage = "Trên 5 kí tự"), MaxLength(20, ErrorMessage = "Dưới 20 kí tự")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được trống")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Trên 5 kí tự"), MaxLength(20, ErrorMessage = "Dưới 20 kí tự")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Không được trống")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Trên 5 kí tự"), MaxLength(20, ErrorMessage = "Dưới 20 kí tự")]
        public string CPassword { get; set; }

        [Display(Name = "Tuổi")]
        [Required(ErrorMessage = "Tuổi không được trống")]
        [Range(18, 100, ErrorMessage = "Phải 18 tuổi mới được đặt vé máy bay")]
        public string Age { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Điện thoại không được trống"), RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(11)]
        public string Phone { get; set; }

        [Display(Name = "Số NIC")]
        [Required(ErrorMessage = "Số NIC không được trống"), RegularExpression(@"^([0-9]{13})$", ErrorMessage = "Số NIC không hợp lệ")]
        [StringLength(13)]
        public string NIC { get; set; }
    }
    public class AeroPlaneInfo
    {
        [Key]
        public int Planeid { get; set; }
        [Display(Name = "Tên máy bay")]
        [Required(ErrorMessage = "Tên máy bay không được trống")]
        [MinLength(5, ErrorMessage = "Trên 5 kí tự"), MaxLength(20, ErrorMessage = "Dưới 20 kí tự")]
        public string APlaneName { get; set; }

        [Display(Name = "Số ghế ngồi")]
        [Required(ErrorMessage = "Số ghế ngồi không được trống")]
        public int SeatingCapacity { get; set; }

        [Display(Name = "Giá")]
        [Required(ErrorMessage = "Giá không được trống")]
        public float price { get; set; }
    }
    [Table("TblFlightBook")]
    public class FlightBooking
    {
        [Key]
        public int bid { get; set; }

        [Display(Name = "Điểm đi")]
        [Required(ErrorMessage = "Điểm đi không được trống")]
        [MaxLength(40, ErrorMessage = "Dưới 40 kí tự")]
        public string From { get; set; }

        [Display(Name = "Điểm đến")]
        [Required(ErrorMessage = "Điểm đến không được trống")]
        [MaxLength(40, ErrorMessage = "Dưới 40 kí tự")]
        public string To { get; set; }

        [Display(Name = "Ngày đi")]
        [DataType(DataType.Date)]
        public DateTime DDate { get; set; }

        [Display(Name = "Giờ khởi hành")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public int Planeid { get; set; }
        public virtual AeroPlaneInfo PlaneInfo { get; set; }

        [Display(Name = "Loại ghế")]
        [StringLength(25)]
        public string SeatType { get; set; }
    }
}