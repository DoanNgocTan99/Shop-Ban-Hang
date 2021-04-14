namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public long ID { get; set; }
        [Display(Name = "Tên doanh mục")]
        [StringLength(250)]
        public string Name { get; set; }

        [Display(Name = "Tên-doanh-mục")]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        public long? ParentID { get; set; }

        [Display(Name = "Hiển thị")]
        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreatrBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }


        public bool ShowOnHome { get; set; }
    }
}
