using System;
using System.Collections.Generic;
using System.Text;
using Model.ViewModel;
using Model.WaterService;

namespace BLL
{
    public class MaintenanceService
    {
        public bool Add(MaintenanceInfo maintenance)
        {
            return new DAL.Manage.MaintenanceManager().Add(maintenance);
        }

        public List<MaintenanceInfo> GetList(QueryModel query)
        {
            string where = "";
            return new DAL.Manage.MaintenanceManager().GetList(where);
        }
    }
}
