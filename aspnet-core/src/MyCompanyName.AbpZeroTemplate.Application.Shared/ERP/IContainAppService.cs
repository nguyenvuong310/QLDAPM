/*using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    public interface IContainAppService : IApplicationService
    {
        ListResultDto<ContainListDto> GetContains(GetContainsInput input);
        Task<ContainListDto> AddContain(CreateContainInput input);
        Task DeleteContain(EntityDto input);
    }



    public class GetContainsInput
    {
        public string Filter { get; set; }
    }







    public class CreateContainInput
    {
        [Range(1, int.MaxValue)]
        public int QuestionId { get; set; }

        [Range(1, int.MaxValue)]
        public int TopicId { get; set; }
    }



    public class ContainListDto : FullAuditedEntityDto
    {
        
        public int QuestionId { get; set; }

        public int TopicId { get; set; }
    }

}
*/