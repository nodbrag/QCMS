
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qcms.IRepository.Uow;
using Qcms.Model.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Qcms.Repository.Uow
{
    //表示EF的工作单元接口，因为DbContext是EF的对象
    public interface IEFUnitOfWork : IUnitOfWorkRepositoryContext
    {
        DbContext context { get; }
    }
}
