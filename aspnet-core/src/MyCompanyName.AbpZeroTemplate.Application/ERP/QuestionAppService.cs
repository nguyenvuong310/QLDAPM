using Abp.Application.Services.Dto;
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
using NUglify.Helpers;

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    public class QuestionAppService : AbpZeroTemplateAppServiceBase, IQuestionAppService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<Exam> _examRepository;

        public QuestionAppService(IRepository<Question> questionRepository, IRepository<Exam> examRepository)
        {
            _questionRepository = questionRepository;
            _examRepository = examRepository;
        }

        public ListResultDto<QuestionListDto> GetQuestions(GetQuestionsInput input)
        {
            var question = _questionRepository
                .GetAll()
                .Include(q=>q.ExamFile)
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.ExamId.ToString() == input.Filter
                )
                .OrderBy(p => p.Content)
                .ThenBy(p => p.Answer)
                .ToList();

            return new ListResultDto<QuestionListDto>(ObjectMapper.Map<List<QuestionListDto>>(question));
        }

        public async Task<QuestionInExamListDto> CreateQuestion(CreateQuestionInput input)
        {
            var exam = _examRepository.Get(input.ExamId);
            await _examRepository.EnsureCollectionLoadedAsync(exam, p => p.Questions);

            if(exam.Questions.Any())
            {
                input.Id = exam.Questions.LastOrDefault().Id + 1;
            }
            else
            {
                input.Id = 1;
            }

            

            var question = ObjectMapper.Map<Question>(input);
            exam.Questions.Add(question);

            //Get auto increment Id of the new Phone by saving to database
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<QuestionInExamListDto>(question);
        }

        public async Task DeleteQuestion(EntityDto input)
        {
            await _questionRepository.DeleteAsync(input.Id);
        }

        public async Task UpdateQuestionById(UpdateQuestionInputById input)
        {
            var question = await _questionRepository.FirstOrDefaultAsync(q => q.Id == input.Id && q.ExamId == input.ExamId);

            if (!string.IsNullOrEmpty(input.Answer))
            {
                // Update the Answer only if it is not null or empty
                question.Answer = input.Answer;
            }
            if (!string.IsNullOrEmpty(input.Content))
            {
                // Update the Answer only if it is not null or empty
                question.Answer = input.Content;
            }
          
            if (!string.IsNullOrEmpty(input.Question_type))
            {
                // Update the Answer only if it is not null or empty
                question.Question_type = input.Question_type;
            }

            if (input.Point.HasValue)
            {
                // Update the Answer only if it is not null or empty
                question.Point = input.Point.Value;
            }

            await _questionRepository.UpdateAsync(question);
        }
    }

}
