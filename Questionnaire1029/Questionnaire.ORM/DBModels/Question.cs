namespace Questionnaire.ORM.DBModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [Key]
        public int Q_id { get; set; }

        public int T_id { get; set; }

        [Required]
        [StringLength(50)]
        public string ANSR_1 { get; set; }

        [Required]
        [StringLength(50)]
        public string ANSR_2 { get; set; }

        [StringLength(50)]
        public string ANSR_3 { get; set; }

        [StringLength(50)]
        public string ANSR_4 { get; set; }

        [StringLength(50)]
        public string ANSR_5 { get; set; }

        [StringLength(50)]
        public string ANSR_6 { get; set; }

        [StringLength(50)]
        public string ANSR_7 { get; set; }

        [StringLength(50)]
        public string ANSR_8 { get; set; }

        [StringLength(50)]
        public string ANSR_9 { get; set; }

        [StringLength(50)]
        public string ANSR_10 { get; set; }

        public int ANSR_sum { get; set; }
    }
}
