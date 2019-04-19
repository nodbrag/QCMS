using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class Attachment : Qcms.Core.Entities.AggregateRoot
    {
        public int AttachmentId { get; set; }
        public string SourceType { get; set; }
        public string SourceId { get; set; }
        public string ServerPath { get; set; }
        public string ServerFileName { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string Md5digest { get; set; }
        public DateTime UploadDateTime { get; set; }
        public string Description { get; set; }
    }
}