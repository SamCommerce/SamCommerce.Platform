﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Settings
{
    public enum SettingValueType
    {
        ShortText,
        LongText,
        Integer,
        Decimal,
        DateTime,
        Boolean,
        SecureString,
        Json,

        /// <summary>
        /// A000027 - Natural numbers
        /// </summary>
        PositiveInteger,
    }
}
