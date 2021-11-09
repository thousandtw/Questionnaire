namespace Questionnaire.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Question_Common
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QC_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string QC_title { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string ANSR_1 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string QC_type { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string QC_mustKeyin { get; set; }
    }
}
