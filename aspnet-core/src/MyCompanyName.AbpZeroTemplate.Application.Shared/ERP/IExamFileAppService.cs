using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    public interface IExamFileAppService : IApplicationService
    {
        ListResultDto<ExamFileListDto> GetExamFiles(GetExamFilesInput input);
        Task<ExamFileInQuestionListDto> CreateExamFile(CreateExamFileInput input);
        Task DeleteExamFile(EntityDto input);
        Task<GetExamFileForEditOutput> GetExamFileForEdit(GetExamFileForEditInput input);
        Task EditExamFile(EditExamFileInput input);
    }

    public class GetExamFilesInput
    {
        public string Filter { get; set; }
    }

    public class EditExamFileInput
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string FilePath { get; set; }
    }


    public class GetExamFileForEditOutput
    {
        public GetExamFileForEditOutput(string description, string filepath)
        {
            Description = description;
            FilePath = filepath;
        }

        [Required]
        [MaxLength(ExamFileConsts.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ExamFileConsts.MaxFilePathLength)]
        public string FilePath { get; set; }
    }


    public class CreateExamFileInput
    {
        public CreateExamFileInput(int questionId,string  description,string filePath)
        {
            QuestionId = questionId;
            Description = description;
            FilePath = filePath;
        }

        [Range(1, int.MaxValue)]
        public int QuestionId { get; set; }

        [Required]
        [MaxLength(ExamFileConsts.MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(ExamFileConsts.MaxFilePathLength)]
        public string FilePath { get; set; }
    }


    public class GetExamFileForEditInput
    {
        public int Id { get; set; }
    }


    public class ExamFileListDto : FullAuditedEntityDto
    {
        public string Description { get; set; }

        public string FilePath { get; set; }

        public int QuestionId { get; set; }
    }

}
