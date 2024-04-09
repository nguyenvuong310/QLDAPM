using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    [Table("PbExamFiles")]
    public class ExamFile : CreationAuditedEntity<int>
    {
        public const int MaxDescritiptionLength = 255;
        public const int MaxFilePathLength = 255;

        [Required]
        [MaxLength(MaxDescritiptionLength)]
        public virtual string Description { get; set; }

        [Required]
        [MaxLength(MaxFilePathLength)]
        public virtual string FilePath { get; set; }


        

        [ForeignKey("QuestionId")]
        public virtual int QuestionId { get; set; }

        [ForeignKey("ExamId")]
        public virtual int ExamId { get; set; }

        public virtual Question Question { get; set; }

    }
}
