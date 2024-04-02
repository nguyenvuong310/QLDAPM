using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    public interface IQuestionAppService : IApplicationService
    {
        ListResultDto<QuestionListDto> GetQuestions(GetQuestionsInput input);
        Task<QuestionInExamListDto> CreateQuestion(CreateQuestionInput input);
        Task DeleteQuestion(EntityDto input);
        Task UpdateQuestionById(UpdateQuestionInputById input);
    }

    public class GetQuestionsInput
    {
        public string Filter { get; set; }
    }

    public class UpdateQuestionInputById
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        public int? Point { get; set; }


        [MaxLength(QuestionConsts.MaxTypeLength)]
        public string Question_type { get; set; }


        [MaxLength(QuestionConsts.MaxContentLength)]
        public string Content { get; set; }

        [MaxLength(QuestionConsts.MaxAnswerLength)]
        public string Answer { get; set; }

    }




    public class CreateQuestionInput
    {

        [Required]
        public int Point { get; set; }


        [Required]
        [MaxLength(QuestionConsts.MaxTypeLength)]
        public string Question_type { get; set; }


        [Required]
        [MaxLength(QuestionConsts.MaxContentLength)]
        public string Content { get; set; }

        [MaxLength(QuestionConsts.MaxAnswerLength)]
        public string Answer { get; set; }


        [Range(1, int.MaxValue)]
        public int ExamId { get; set; }
    }


    /*public class GetQuestionForEditInput
    {
        public int Id { get; set; }
    }*/


    public class QuestionListDto : FullAuditedEntityDto
    {
        public int Point { get; set; }


        public string Question_type { get; set; }

        public string Content { get; set; }

        public string Answer { get; set; }

        public virtual int ExamId { get; set; }

        public ExamFileInQuestionListDto ExamFile { get; set; }
    }

    public class ExamFileInQuestionListDto : CreationAuditedEntityDto<int>
    {
        public string Description { get; set; }

        public string FilePath { get; set; }
    }

}
