using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortUrl
{
    class Constants
    {
        //The redirect URL will live in the property bag of the web with this key
        //web.AllProperties[pbKey]
        public const string pbKey = "RedirectUrl";

        //These special characters cannot be used in short urls
        public const string illegalChars = "~`!@#$%^&*()=+{}[]|\\:;\"'<>,.?/";
    }
}
