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
    [Table("PbExams")]
    public class Exam : FullAuditedEntity<int>
    {
        public const int MaxPasswordLength = 255;
        public const int MaxTypeLength = 255;
        public const int MaxCourseLength = 255;
        public const int MaxPointCalLength = 255;

        [Required]
        public virtual int Working_time { get; set; }

        [Required]
        public virtual bool Mix_question { get; set; }

        [Required]
        public virtual int Redo_num { get; set; }


        [Required]
        [MaxLength(MaxPointCalLength)]
        public virtual string Point_is_cal { get; set; }


        [Required]
        public virtual bool Review_wrong_ans { get; set; }

        [Required]
        public virtual bool Review_right_ans { get; set; }

        [Required]
        public virtual bool View_question_one { get; set; }

        [MaxLength(MaxPasswordLength)]
        public virtual string Require_password { get; set; }

        [Required]
        public virtual DateTime Start_date { get; set; }

        [Required]
        public virtual DateTime End_date { get; set; }


        [Required]
        [MaxLength(MaxTypeLength)]
        public virtual string Exam_type { get; set; }


        [Required]
        [MaxLength(MaxCourseLength)]
        public virtual string Course { get; set; }



        public virtual ICollection<Question> Questions { get; set; }

    }

}
