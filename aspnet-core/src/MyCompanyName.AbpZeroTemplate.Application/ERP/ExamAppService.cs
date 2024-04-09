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

namespace MyCompanyName.AbpZeroTemplate.ERP
{
    public class ExamAppService : AbpZeroTemplateAppServiceBase, IExamAppService
    {
        private readonly IRepository<Exam, int> _examRepository;

        public ExamAppService(IRepository<Exam> examRepository)
        {
            _examRepository = examRepository;
        }

        public ListResultDto<ExamListDto> GetExams(GetExamsInput input)
        {
            var exam = _examRepository
                .GetAll()
                .Include(p => p.Questions)
                .ToList();

            return new ListResultDto<ExamListDto>(ObjectMapper.Map<List<ExamListDto>>(exam));
        }

        public async Task<int> AddExam(CreateExamInput input)
        {
            var exam = ObjectMapper.Map<Exam>(input);
            await _examRepository.InsertAsync(exam);
            await CurrentUnitOfWork.SaveChangesAsync();


            var lastExam = await _examRepository.GetAll().OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            int lastExamId = lastExam?.Id ?? 0;

            return lastExamId;
        }

        public async Task DeleteExam(EntityDto input)
        {
            await _examRepository.DeleteAsync(input.Id);
        }

        /*public async Task<GetExamForEditOutput> GetExamForEdit(GetExamForEditInput input)
        {
            var exam = await _examRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetExamForEditOutput>(exam);
        }*/

        /*public async Task EditExam(EditExamInput input)
        {
            var exam = await _examRepository.GetAsync(input.Id);
            exam.Time_amount = input.Time_amount;
            exam.Join = input.Join;
            await _examRepository.UpdateAsync(exam);
        }*/

    }

}
