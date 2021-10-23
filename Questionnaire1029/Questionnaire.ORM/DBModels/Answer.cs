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
        [Column(Order = 0)]
        public int A_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int T_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string A_name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string A_phone { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string A_email { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(3)]
        public string A_age { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string QC_ansrd1 { get; set; }

        [StringLength(50)]
        public string QC_ansrd2 { get; set; }

        [StringLength(50)]
        public string QC_ansrd3 { get; set; }

        [StringLength(50)]
        public string QC_ansrd4 { get; set; }

        [StringLength(50)]
        public string QC_ansrd5 { get; set; }

        [StringLength(50)]
        public string QC_ansrd6 { get; set; }

        [StringLength(50)]
        public string QC_ansrd7 { get; set; }

        [StringLength(50)]
        public string QC_ansrd8 { get; set; }

        [StringLength(50)]
        public string QC_ansrd9 { get; set; }

        [StringLength(50)]
        public string QC_ansrd10 { get; set; }
    }
}
