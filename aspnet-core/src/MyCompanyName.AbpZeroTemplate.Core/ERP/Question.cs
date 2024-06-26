﻿using Abp.Domain.Entities.Auditing;
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
    [Table("PbQuestions")]
    public class Question : CreationAuditedEntity<int>
    {
        public const int MaxContentLength = 65535;
        public const int MaxAnswerLength = 65535;
        public const int MaxTypeLength = 255;


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }

        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }
        public virtual int ExamId { get; set; }




        [Required]
        public virtual int Point { get; set; }


        [Required]
        [MaxLength(MaxTypeLength)]
        public virtual string Question_type { get; set; }


        [Required]
        [MaxLength(MaxContentLength)]
        public virtual string Content { get; set; }

        [MaxLength(MaxAnswerLength)]
        public virtual string Answer { get; set; }

        [MaxLength(MaxAnswerLength)]
        public virtual string OtherAnswer { get; set; }

        [MaxLength(MaxAnswerLength)]
        public virtual string OtherAnswer1 { get; set; }

        [MaxLength(MaxAnswerLength)]
        public virtual string OtherAnswer2 { get; set; }

        public virtual ExamFile ExamFile { get; set; }


    }
}
