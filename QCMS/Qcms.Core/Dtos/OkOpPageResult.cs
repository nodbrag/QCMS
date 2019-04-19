using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Core.Dtos
{
    public class OkOpPageResult:OpPageResult
    {
        public OkOpPageResult(IReadOnlyList<object> data):base(data)
        {

        }
        
    }
    public class OkOpPageResult<TData> : OpPageResult<TData>
    {
        public OkOpPageResult(IReadOnlyList<TData> data) : base(data)
        {

        }
        public OkOpPageResult(IReadOnlyList<TData> data,int totalCount) : base(data,totalCount)
        {

        }
    }
}
