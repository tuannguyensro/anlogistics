﻿using System;

namespace TNS.Model.Abstracts
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdatedBy { get; set; }

        string MetaKeyword { get; set; }

        string MetaDescription { get; set; }

        bool Status { get; set; }
    }
}
