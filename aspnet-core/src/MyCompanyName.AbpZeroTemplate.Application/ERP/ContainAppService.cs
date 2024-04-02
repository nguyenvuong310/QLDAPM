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

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    public class ContainAppService : AbpZeroTemplateAppServiceBase, IContainAppService
    {
        private readonly IRepository<Contain, int> _containRepository;
        private readonly IRepository<Topic> _topicRepository;
        private readonly IRepository<Question> _questionRepository;

        public ContainAppService(IRepository<Contain,int> containRepository, IRepository<Topic> topicRepository, IRepository<Question> questionRepository)
        {
            _containRepository = containRepository;
            _topicRepository = topicRepository;
            _questionRepository = questionRepository;
        }

        public ListResultDto<ContainListDto> GetContains(GetContainsInput input)
        {
            var contain = _containRepository
                .GetAll()
                .OrderBy(p => p.QuestionId)
                .ThenBy(p => p.TopicId)
                .ToList();

            return new ListResultDto<ContainListDto>(ObjectMapper.Map<List<ContainListDto>>(contain));
        }

        public async Task<ContainListDto> AddContain(CreateContainInput input)
        {
            var topic = _topicRepository.Get(input.TopicId);
            var question = _questionRepository.Get(input.QuestionId);
            await _questionRepository.EnsureCollectionLoadedAsync(question, p => p.Contains);
            await _topicRepository.EnsureCollectionLoadedAsync(topic, p => p.Contains);

            var contain = ObjectMapper.Map<Contain>(input);
            topic.Contains.Add(contain);
            question.Contains.Add(contain);

            //Get auto increment Id of the new Phone by saving to database
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<ContainListDto>(contain);
        }

        public async Task DeleteContain(EntityDto input)
        {
            await _containRepository.DeleteAsync(input.Id);
        }



    }

}
*/