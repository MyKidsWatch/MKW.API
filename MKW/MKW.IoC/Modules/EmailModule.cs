﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MKW.Domain.Dto.DTO.EmailDTO;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Services.BaseServices;

namespace MKW.IoC.Modules
{
    public static class EmailModule
    {
        public static void AddEmailConfiguration(this IServiceCollection builder, IConfiguration configuration)
        {
            var EmailOptionsSettings = configuration.GetSection(nameof(EmailOptions));

            builder.Configure<EmailOptions>(options =>
            {
                options.SmtpServer = EmailOptionsSettings[nameof(EmailOptions.SmtpServer)];
                options.Port = int.Parse(EmailOptionsSettings[nameof(EmailOptions.Port)]);
                options.From = EmailOptionsSettings[nameof(EmailOptions.From)];
                options.Password = EmailOptionsSettings[nameof(EmailOptions.Password)];
            });

            builder.AddTransient<IEmailService, EmailService>();
        }
    }
}
