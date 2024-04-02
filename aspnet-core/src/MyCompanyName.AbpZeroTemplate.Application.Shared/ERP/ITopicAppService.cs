/*using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    public interface ITopicAppService : IApplicationService
    {
        ListResultDto<TopicListDto> GetTopics(GetTopicsInput input);
        Task CreateTopic(CreateTopicInput input);
        Task DeleteTopic(EntityDto input);
        Task<GetTopicForEditOutput> GetTopicForEdit(GetTopicForEditInput input);
        Task EditTopic(EditTopicInput input);
    }

    public class GetTopicsInput
    {
        public string Filter { get; set; }
    }

    public class EditTopicInput
    {
        public int Id { get; set; }
        public string Question_link { get; set; }

        public string Answer_link { get; set; }

        public int Max_question { get; set; }

        public TopicType Type { get; set; }

    }


    public class GetTopicForEditOutput
    {
        public GetTopicForEditOutput(string question_Link, string answer_link, int max_question, TopicType type)
        {
            Question_link = question_Link;
            Answer_link = answer_link;
            Max_question = max_question;
            Type = type;
        }

        [Required]
        [MaxLength(TopicConsts.MaxQuestion_linkLength)]
        public string Question_link { get; set; }

        [Required]
        [MaxLength(TopicConsts.MaxAnswer_linkLength)]
        public string Answer_link { get; set; }

        public int Max_question { get; set; }

        public TopicType Type { get; set; }

    }


    public class CreateTopicInput
    {
        [Required]
        [MaxLength(TopicConsts.MaxQuestion_linkLength)]
        public string Question_link { get; set; }

        [Required]
        [MaxLength(TopicConsts.MaxAnswer_linkLength)]
        public string Answer_link { get; set; }

        public int Max_question { get; set; }

        public TopicType Type { get; set; }
    }


    public class GetTopicForEditInput
    {
        public int Id { get; set; }
    }


    public class TopicListDto : FullAuditedEntityDto
    {
        public string Question_link { get; set; }

        public string Answer_link { get; set; }
        public int Max_question { get; set; }
        public TopicType Type { get; set; }

        public Collection<ExamInTopicListDto> Exams { get; set; }
    }

    public class ExamInTopicListDto : CreationAuditedEntityDto<int>
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
    }

    public enum TopicType : byte
    {
        Essay, MultiChoice, Mix, Group
    }

}
*/