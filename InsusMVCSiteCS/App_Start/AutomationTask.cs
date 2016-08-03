using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using Insus.NET.Entities;
using System.Data;

namespace Insus.NET
{
    public class AutomationTask
    {
        private static readonly AutomationTask _AutomationTask = null;

        private Timer time = null;

        private int dueTime = 1 * 1000;
        private int period = 60 * 1000;
        private int _IsRunning;

        static AutomationTask()
        {
            _AutomationTask = new AutomationTask();
        }

        public static AutomationTask Task
        {
            get
            {
                return _AutomationTask;
            }
        }

        public void Start()
        {
            if (time == null)
            {
                time = new Timer(new TimerCallback(ExecuteTimerCallback), null, dueTime, period);
            }
        }

        private void ExecuteTimerCallback(object sender)
        {
            if (Interlocked.Exchange(ref _IsRunning, 1) == 0)
            {
                try
                {
                    DistributeEmail();
                }
                finally
                {
                    Interlocked.Exchange(ref _IsRunning, 0);
                }
            }
        }

        public void Stop()
        {
            if (time != null)
            {
                time.Dispose();
                time = null;
            }
        }

        private void DistributeEmail()
        {
            MailingListEntity objmle = new MailingListEntity();
            InsusMailUtility objInsusMailUtility = new InsusMailUtility();
            DataTable dataTable = objmle.GetDistributeMailList();

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    objInsusMailUtility.SendHtmlEmail(
                                                        dataRow["FromEmail"].ToString(),
                                                        dataRow["FromEmailAlias"].ToString(),
                                                        dataRow["Email"].ToString(),
                                                        dataRow["Subject"].ToString(),
                                                        dataRow["ContentPagePath"].ToString(),
                                                        dataRow["SmtpName"].ToString(),
                                                        Convert.ToInt32(dataRow["Port"]),
                                                        dataRow["Account"].ToString(),
                                                        dataRow["Password"].ToString()
                                                    );
                }
            }
        }
    }
}