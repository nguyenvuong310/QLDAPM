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

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    public class ExamFileAppService : AbpZeroTemplateAppServiceBase, IExamFileAppService
    {
        private readonly IRepository<ExamFile,int> _examFileRepository;
        private readonly IRepository<Question> _questionRepository;

        public ExamFileAppService(IRepository<ExamFile> examFileRepository, IRepository<Question> questionRepository)
        {
            _examFileRepository = examFileRepository;
            _questionRepository = questionRepository;
        }

        public ListResultDto<ExamFileListDto> GetExamFiles(GetExamFilesInput input)
        {
            var examFile = _examFileRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Description.Contains(input.Filter) ||
                         p.FilePath.Contains(input.Filter)
                )
                .OrderBy(p => p.Description)
                .ThenBy(p => p.FilePath)
                .ToList();

            return new ListResultDto<ExamFileListDto>(ObjectMapper.Map<List<ExamFileListDto>>(examFile));
        }

        public async Task<ExamFileInQuestionListDto> CreateExamFile(CreateExamFileInput input)
        {



            var question = _questionRepository.Get(input.QuestionId);
            await _questionRepository.EnsurePropertyLoadedAsync(question, p => p.ExamFile);

            var examFile = ObjectMapper.Map<ExamFile>(input);
            question.ExamFile = examFile;

            //Get auto increment Id of the new Phone by saving to database
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<ExamFileInQuestionListDto>(examFile);
        }

        public async Task DeleteExamFile(EntityDto input)
        {
            await _examFileRepository.DeleteAsync(input.Id);
        }

        public async Task<GetExamFileForEditOutput> GetExamFileForEdit(GetExamFileForEditInput input)
        {
            var person = await _examFileRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetExamFileForEditOutput>(person);
        }

        public async Task EditExamFile(EditExamFileInput input)
        {
            var person = await _examFileRepository.GetAsync(input.Id);
            person.Description = input.Description;
            person.FilePath = input.FilePath;
            await _examFileRepository.UpdateAsync(person);
        }

    }

}
