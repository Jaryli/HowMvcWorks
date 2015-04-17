using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Quartz;

namespace HowMvcWorks.Models
{
    public class MyJob : IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            Debug.WriteLine("Hello! it's my Job:" + DateTime.Now.ToString());
        }
    }
}