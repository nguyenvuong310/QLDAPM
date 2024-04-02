using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    public interface IExamAppService : IApplicationService
    {
        ListResultDto<ExamListDto> GetExams(GetExamsInput input);
        Task AddExam (CreateExamInput input);
        Task DeleteExam(EntityDto input);
        /*Task<GetExamForEditOutput> GetExamForEdit(GetExamForEditInput input);*/
        /*Task EditExam(EditExamInput input);*/
    }

    public class GetExamsInput
    {
        public string Filter { get; set; }
    }

/*    public class EditExamInput
    {
        public int Id { get; set; }
        public int Time_amount { get; set; }

        public string Join { get; set; }
    }*/


/*    public class GetExamForEditOutput
    {
        public GetExamForEditOutput(string time_amount, string join)
        {
            Time_amount = time_amount;
            Join = join;
        }

        [Required]
        public string Time_amount { get; set; }

        [Required]
        public string Join { get; set; }
    }*/


    public class CreateExamInput
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Working_time { get; set; }

        [Required]
        public bool Mix_question { get; set; }

        [Required]
        public int Redo_num { get; set; }


        [Required]
        public string Point_is_cal { get; set; }


        [Required]
        public bool Review_wrong_ans { get; set; }

        [Required]
        public bool Review_right_ans { get; set; }

        [Required]
        public bool View_question_one { get; set; }

        public string Require_password { get; set; }

        [Required]
        public DateTime Start_date { get; set; }

        [Required]
        public DateTime End_date { get; set; }


        [Required]
        public string Exam_type { get; set; }


        [Required]
        public string Course { get; set; }
    }


    /*public class GetExamForEditInput
    {
        public int Id { get; set; }
    }*/


    public class ExamListDto : FullAuditedEntityDto
    {
        public int Working_time { get; set; }

        public bool Mix_question { get; set; }

        public int Redo_num { get; set; }

        public string Point_is_cal { get; set; }

        public bool Review_wrong_ans { get; set; }

        public bool Review_right_ans { get; set; }

        public bool View_question_one { get; set; }

        public string Require_password { get; set; }

        public DateTime Start_date { get; set; }

        public DateTime End_date { get; set; }

        public string Exam_type { get; set; }


        public string Course { get; set; }

        public Collection<QuestionInExamListDto> Questions { get; set; }
    }



    public class QuestionInExamListDto : CreationAuditedEntityDto<long>
    {
        public int Point { get; set; }

        public string Question_type { get; set; }


        public string Content { get; set; }

        public string Answer { get; set; }
    }
}
