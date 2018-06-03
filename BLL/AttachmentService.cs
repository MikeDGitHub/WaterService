using System;
using System.Collections.Generic;
using System.Text;
using Model.WaterService;

namespace BLL
{
    public class AttachmentService
    {
        public bool Add(AttachmentInfo attachment)
        {
            return new DAL.Manage.AttachmentManager().Add(attachment);
        }

        public bool Update(AttachmentInfo attachment)
        {
            return new DAL.Manage.AttachmentManager().Update(attachment);
        }

        public bool AddOrUpdate(List<AttachmentInfo> list)
        {
            return new DAL.Manage.AttachmentManager().AddOrUpdate(list);
        }
    }
}
