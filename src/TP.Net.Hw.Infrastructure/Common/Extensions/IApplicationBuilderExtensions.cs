using Hangfire;
using Microsoft.AspNetCore.Builder;
using TP.Net.Hw.Application.Interfaces.Services;

namespace TP.Net.Hw.Infrastructure.Common.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseHangfireJobs(this IApplicationBuilder _)
        {
            RecurringJob.AddOrUpdate<IEmailService>("send-daily-mail", s => s.SendEmailReport(), "35 7 * * 1-5", TimeZoneInfo.Local);
            //RecurringJob.AddOrUpdate<IReportService>("export-daily-excel", s => s.GetUsersExcelReport(), "34 7 * * 1-5", TimeZoneInfo.Local);
        }
    }
}