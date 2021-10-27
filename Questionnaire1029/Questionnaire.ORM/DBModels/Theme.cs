namespace Questionnaire.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Theme")]
    public partial class Theme
    {
        public int? T_id { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(150)]
        public string T_title { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int T_state { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime T_start { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime T_end { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(250)]
        public string T_memo { get; set; }
    }
}
