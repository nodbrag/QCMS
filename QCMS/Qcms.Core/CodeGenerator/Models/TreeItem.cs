
using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Core.CodeGenerator.Models
{
    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }
}
