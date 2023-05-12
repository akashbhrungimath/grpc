using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using GrpcClientCertificateServer;

namespace GrpcClientCertificateServer.Services
{
    [Authorize]
    public class StudentService : Student.StudentBase
    {
        private readonly ILogger<StudentService> _logger;
        public StudentService(ILogger<StudentService> logger)
        {
            _logger = logger;
        }
        public override Task<MarksOutput> calculate(MarksInput request, ServerCallContext context)
        {
            //Console.WriteLine(context.GetHttpContext().User.Identity.Name);
            MarksOutput student = new MarksOutput();
            student.Percentage = Convert.ToDouble(Math.Abs(request.Sci) + Math.Abs(request.Socsci) + Math.Abs(request.Eng) + Math.Abs(request.Kan) + Math.Abs(request.Hin) + Math.Abs(request.Maths)) / 6;
            return Task.FromResult(student);
        }

    }
}