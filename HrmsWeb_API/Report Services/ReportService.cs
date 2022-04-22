using AspNetCore.Reporting;
using AutoMapper;
using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using RdlcWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace HrmsWeb_API.Report_Services
{
    public class ReportService : IReportInterface
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public ReportService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        
        public byte[] GenerateReportAsync(string reportName, string reportType)
        {
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("HrmsWeb_API.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, reportName);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");

            LocalReport report = new LocalReport(rdlcFilePath);

            //var result1 = _employeerepository.getallemployees();
            //ilist<employeeviewmodel> result = new list<employeeviewmodel>();
            //employeeviewmodel emp;

            //foreach (employee item in result1)
            //{
            //    emp = new employeeviewmodel()
            //    {
            //        empid = item.empid,
            //        empname = item.empname,
            //        empsalary = item.empsalary,
            //        deptid = item.deptid
            //    };
            //    result.add(emp);

            //}
            // prepare data for report
            List<UserDto> userList = new List<UserDto>();
            //  EmployeeViewModel emp = new EmployeeViewModel();

            // emp.getAllEmployees();
          //  getAllEmployees();

            var user1 = new UserDto { FirstName = "jp", LastName = "jan", Email = "jp@gm.com", Phone = "+976666661111" };
            var user2 = new UserDto { FirstName = "jp2", LastName = "jan", Email = "jp2@gm.com", Phone = "+976666661111" };
            var user3 = new UserDto { FirstName = "முதல் பெயர்", LastName = "கடைசி பெயர்", Email = "jp3@gm.com", Phone = "+976666661111" };
            var user4 = new UserDto { FirstName = "पहला नाम", LastName = "अंतिम नाम", Email = "jp4@gm.com", Phone = "+976666661111" };
            var user5 = new UserDto { FirstName = "jp5", LastName = "jan", Email = "jp5@gm.com", Phone = "+976666661111" };

            userList.Add(user1);
            userList.Add(user2);
            userList.Add(user3);
            userList.Add(user4);
            userList.Add(user5);

            report.AddDataSource("dsUsers", userList);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var result = report.Execute(GetRenderType(reportType), 1, parameters);

            return result.MainStream;
        }
        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;

            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    renderType = RenderType.Pdf;
                    break;
                case "XLS":
                    renderType = RenderType.Excel;
                    break;
                case "WORD":
                    renderType = RenderType.Word;
                    break;
            }

            return renderType;
        }

        public void getAllEmployees()
        {
            var result = _employeeRepository.getAllEmployees();
            _mapper.Map<EmployeeViewModel>(result);
        }
    }
}
