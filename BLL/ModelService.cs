using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ModelService
    {
        public List<Model.WaterService.ModelInfo> QueryList()
        {
            return new DAL.Manage.ModelManage().QueryList();
        }
    }
}
