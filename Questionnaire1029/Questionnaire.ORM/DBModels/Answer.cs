namespace Questionnaire.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int A_id { get; set; }

        public int T_id { get; set; }

        [Required]
        [StringLength(50)]
        public string A_name { get; set; }

        [Required]
        [StringLength(10)]
        public string A_phone { get; set; }

        [Required]
        [StringLength(50)]
        public string A_email { get; set; }

        [Required]
        [StringLength(3)]
        public string A_age { get; set; }

        [Required]
        [StringLength(50)]
        public string QC_ansrd1 { get; set; }
    }
}
