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

        public List<MaintenanceInfo> GetList(string where)
        {
            return new DAL.Manage.MaintenanceManager().GetList(where);
        }
        public MaintenanceInfo GetList(int id)
        {
            return new DAL.Manage.MaintenanceManager().GetModel(id);
        }
    }
}
