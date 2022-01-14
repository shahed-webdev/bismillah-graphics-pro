using System;
using System.Collections.Generic;

namespace BismillahGraphicsPro.Data
{
    public partial class SmsSendRecord
    {
        public int SmsSendId { get; set; }
        public int BranchId { get; set; }
        public int? VendorId { get; set; }
        public string? SmsProviderSendId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string TextSms { get; set; } = null!;
        public int TextCount { get; set; }
        public int Smscount { get; set; }
        public DateTime? SendDate { get; set; }
        public DateTime InsertDateBdTime { get; set; }

        public virtual Branch Branch { get; set; } = null!;
    }
}
