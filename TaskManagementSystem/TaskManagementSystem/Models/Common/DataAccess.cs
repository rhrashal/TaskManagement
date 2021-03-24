using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public class DataAccess
    {       
        private static DataAccess _DataAccess;

        public CommonServices CommonServices = new CommonServices();

        #region TaskManagement
        //public IssueService IssueService = new IssueService();
        //public ClientService ClientService = new ClientService();
        //public CommentsService CommentsService = new CommentsService();
        //public EmpBasicInfoService EmpBasicInfoService = new EmpBasicInfoService();
        //public IssueTypeService IssueTypeService = new IssueTypeService();
        //public IssueWebLinkService IssueWebLinkService = new IssueWebLinkService();
        //public ProjectService ProjectService = new ProjectService();
        //public SprintService SprintService = new SprintService();


        #endregion





        #region instance
        private static object _sync = new object();
        public static DataAccess Instance
        {
            get 
            { 
                if(_DataAccess == null)
                {
                    lock (_sync)
                    {
                        if(_DataAccess == null)
                        {
                            _DataAccess = new DataAccess();
                        }
                    }
                }
                return _DataAccess;
            }
        }
        #endregion
    }
}
