using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrmsWeb_API.Report_Services
{
   public interface IReportInterface
    {

        byte[] GenerateReportAsync(string reportName, string reportType);

    }
}
