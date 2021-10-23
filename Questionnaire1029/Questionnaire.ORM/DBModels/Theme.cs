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
        [Key]
        public int T_id { get; set; }

        [Required]
        [StringLength(150)]
        public string T_title { get; set; }

        public int T_state { get; set; }

        public DateTime? T_start { get; set; }

        public DateTime? T_end { get; set; }

        [StringLength(250)]
        public string T_memo { get; set; }

        [Required]
        [StringLength(2)]
        public string T_type { get; set; }

        [Required]
        [StringLength(1)]
        public string T_mustKeyin { get; set; }
    }
}
