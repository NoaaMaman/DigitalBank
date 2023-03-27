using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace AuthenticationAndAuthorization.Authorization
{
    public class ConsultantManagerProbationRequiremet : IAuthorizationRequirement
    {
        public int ProbationMonths { get;}
        public ConsultantManagerProbationRequiremet(int probationMonths)
        {
            ProbationMonths = probationMonths;
        }
    }
    public class ConsultantManagerProbationRequiremetHandler : AuthorizationHandler<ConsultantManagerProbationRequiremet>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ConsultantManagerProbationRequiremet requirement)
        {
            if(!context.User.HasClaim(x => x.Type == "EmploymentDate"))
                return Task.CompletedTask;
            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentDate").Value);

            var period = DateTime.Now - empDate;
            if (period.Days > 30 * requirement.ProbationMonths)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
