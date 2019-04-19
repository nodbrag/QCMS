using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Core.Dtos
{
    public class OkOpResult:OpResult
    {
        public OkOpResult() : base(null) { }
        public OkOpResult(object data):base(data) { }
    }
    public class OkOpResult<TData> : OpResult<TData>
    {
        public OkOpResult(TData data) : base(data) { }
    }
}
