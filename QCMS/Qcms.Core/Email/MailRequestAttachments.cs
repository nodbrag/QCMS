using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Core.Email
{
    /// <summary>
    /// 发送邮件请求附件
    /// </summary>
    public class MailRequestAttachments
    {
        #region PrivateFields

        /// <summary>
        /// 文件名
        /// </summary>
        private string _fileNameField;

        /// <summary>
        /// 文件内容
        /// </summary>
        private byte[] _fileDataField;

        #endregion

        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get
            {
                return this._fileNameField;
            }

            set
            {
                this._fileNameField = value;
            }
        }

        /// <summary>
        /// 文件内容
        /// </summary>
        public byte[] FileData
        {
            get
            {
                return this._fileDataField;
            }

            set
            {
                this._fileDataField = value;
            }
        }
    }
}
