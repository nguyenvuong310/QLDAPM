/*using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Authorization;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.ERP;
using Microsoft.EntityFrameworkCore;

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    public class TopicAppService : AbpZeroTemplateAppServiceBase, ITopicAppService
    {
        private readonly IRepository<Topic> _topicRepository;

        public TopicAppService(IRepository<Topic> topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public ListResultDto<TopicListDto> GetTopics(GetTopicsInput input)
        {
            var topic = _topicRepository
                .GetAll()
                .Include(t=>t.Exams)
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Question_link.Contains(input.Filter) ||
                         p.Answer_link.Contains(input.Filter)
                )
                .OrderBy(p => p.Question_link)
                .ThenBy(p => p.Answer_link)
                .ToList();

            return new ListResultDto<TopicListDto>(ObjectMapper.Map<List<TopicListDto>>(topic));
        }

        public async Task CreateTopic(CreateTopicInput input)
        {
            var topic = ObjectMapper.Map<Topic>(input);
            await _topicRepository.InsertAsync(topic);
        }

        public async Task DeleteTopic(EntityDto input)
        {
            await _topicRepository.DeleteAsync(input.Id);
        }

        public async Task<GetTopicForEditOutput> GetTopicForEdit(GetTopicForEditInput input)
        {
            var topic = await _topicRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetTopicForEditOutput>(topic);
        }

        public async Task EditTopic(EditTopicInput input)
        {
            var topic = await _topicRepository.GetAsync(input.Id);
            topic.Question_link = input.Question_link;
            topic.Answer_link = input.Answer_link;
            topic.Max_question = input.Max_question;
            await _topicRepository.UpdateAsync(topic);
        }

    }

}
*/