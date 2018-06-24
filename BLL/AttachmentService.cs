using System;
using System.Collections.Generic;
using System.Text;
using DAL.Manage;
using Model.WaterService;

namespace BLL
{
    public class AttachmentService
    {
        private readonly AttachmentManager dal = new AttachmentManager();
        public bool Add(AttachmentInfo attachment)
        {
            return dal.Add(attachment);
        }

        public bool Update(AttachmentInfo attachment)
        {
            return dal.Update(attachment);
        }

        public bool AddOrUpdate(List<AttachmentInfo> list)
        {
            return dal.AddOrUpdate(list);
        }
    }
}
