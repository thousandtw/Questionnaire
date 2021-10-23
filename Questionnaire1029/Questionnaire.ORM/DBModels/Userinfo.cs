namespace Questionnaire.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Userinfo")]
    public partial class Userinfo
    {
        [Key]
        [Column(Order = 0)]
        public Guid User_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string User_name { get; set; }

        [StringLength(10)]
        public string User_phone { get; set; }

        [StringLength(100)]
        public string User_email { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string User_account { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string User_password { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_level { get; set; }
    }
}
