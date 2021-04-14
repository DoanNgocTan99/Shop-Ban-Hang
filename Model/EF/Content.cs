namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        public long ID { get; set; }
        [Display(Name ="Tên doanh mục")]
        [StringLength(250)]
        public string Name { get; set; }
        [Display(Name = "Tên-doanh-mục")]

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả")]

        [StringLength(250)]
        public string Description { get; set; }

        [Display(Name = "Ảnh")]

        [StringLength(250)]
        public string Image { get; set; }

        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int? Warranty { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreatrBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [Display(Name ="Từ khoá")]
        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }
        [Display(Name = "Trạng thái")]

        public bool Status { get; set; }

        [Display(Name = "Thịnh hành")]

        public DateTime? TopHot { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }
    }
}
