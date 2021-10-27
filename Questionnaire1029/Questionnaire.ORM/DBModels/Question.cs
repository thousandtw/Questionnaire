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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Q_id { get; set; }

        public int T_id { get; set; }

        [Required]
        [StringLength(1000)]
        public string ANSR { get; set; }

        public int ANSR_sum { get; set; }
    }
}
