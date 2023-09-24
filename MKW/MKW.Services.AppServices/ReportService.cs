﻿using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReportsDTO;
using MKW.Domain.Interface.Repository.ReportAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Services.AppServices
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportReasonRepository _reportReasonRepository;

        public ReportService(IReportRepository reportRepository, IReportReasonRepository reportReasonRepository)
        {
            _reportRepository = reportRepository;
            _reportReasonRepository = reportReasonRepository;
        }

        public async Task<BaseResponseDTO<ReportReasonDto>> GetReasons()
        {
            var reasons = await _reportReasonRepository.GetActive() ?? throw new NotFoundException("Report Reasons not found.");
            
            return new BaseResponseDTO<ReportReasonDto>().AddContent(reasons.Select(x => new ReportReasonDto(x)));
        }
    }
}
