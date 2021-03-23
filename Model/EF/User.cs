namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }
        [Display(Name="Tài khoản")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(32)]
        public string Password { get; set; }

        [Display(Name = "Họ và Tên")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Sđt")]
        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string CreatrBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
