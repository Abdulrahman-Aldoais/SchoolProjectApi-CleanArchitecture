﻿using System.Globalization;

namespace SchoolProject.Data.Commons
{
    public class GeneralLocalizableEntity
    {

        public string Localize(string textAr, string textEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;
            return textEn;
        }
    }
}
