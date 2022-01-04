using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Entities.Contacts
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeEnum
    {
        EMAIL = 1,
        LANDLINE_PHONE = 2,
        PERSONAL_PHONE = 3,
        WHATSAPP_PHONE = 4,
        TELEGRAM_PHONE = 5,
        OTHER_PHONE = 6,
        FACEBOOK_PAGE = 7,
        LINKEDIN_PAGE = 8,
        INSTAGRAM_PAGE = 9,
        YOUTUBE_CHANNEL = 10,
        OTHER = 11
    }
}
