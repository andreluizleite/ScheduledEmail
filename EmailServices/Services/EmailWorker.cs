using EmailServices.Infrastructure;
using EmailServices.Models;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServices.Services
{
    public class EmailWorker
    {
        private readonly IServiceProvider _serviceProvider;

        public EmailWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SendScheduledEmails()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                //var dbContext = scope.ServiceProvider.GetRequiredService<UserContext>();
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                var mockUsers = new List<User>
                {
                     new User { Id = 1, Email = "user1@example.com" },
                     new User { Id = 2, Email = "user2@example.com" }
                };

                foreach (var user in mockUsers)
                {
                    // Send email to the user
                    emailService.SendEmail(user.Email, "SubjectTest", "Email BodyTest");
                }
            }
        }
    }
}
