using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Core.Email
{
    /// <summary>
    /// 发送邮件请求
    /// </summary>
    public class MailRequest
    {
        #region PrivateFields

        /// <summary>
        /// 文件名
        /// </summary>
        private string _fromField;

        /// <summary>
        /// 返送到
        /// </summary>
        private string _toField;

        /// <summary>
        /// 抄送
        /// </summary>
        private string _copyField;

        /// <summary>
        /// 附件
        /// </summary>
        private string _bccField;

        /// <summary>
        /// 标题
        /// </summary>
        private string _subjectField;

        /// <summary>
        /// 发送人名
        /// </summary>
        private string _bodyField;

        /// <summary>
        /// 类容
        /// </summary>
        private MailRequestAttachments[] _attachmentsField;

        #endregion

        /// <summary>
        /// 发送人，多个人以分号;间隔
        /// </summary>
        public string From
        {
            get
            {
                return this._fromField;
            }

            set
            {
                this._fromField = value;
            }
        }

        /// <summary>
        /// 收件人，多个人以分号;间隔
        /// </summary>
        public string To
        {
            get
            {
                return this._toField;
            }

            set
            {
                this._toField = value;
            }
        }

        /// <summary>
        /// 抄送人，多个人以分号;间隔
        /// </summary>
        public string CC
        {
            get
            {
                return this._copyField;
            }

            set
            {
                this._copyField = value;
            }
        }

        /// <summary>
        /// 秘密抄送人，多个人以分号;间隔
        /// </summary>
        public string Bcc
        {
            get
            {
                return this._bccField;
            }

            set
            {
                this._bccField = value;
            }
        }

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject
        {
            get
            {
                return this._subjectField;
            }

            set
            {
                this._subjectField = value;
            }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Body
        {
            get
            {
                return this._bodyField;
            }

            set
            {
                this._bodyField = value;
            }
        }

        /// <summary>
        /// 附件列表
        /// </summary>
        public MailRequestAttachments[] Attachments
        {
            get
            {
                return this._attachmentsField;
            }

            set
            {
                this._attachmentsField = value;
            }
        }
    }
}
