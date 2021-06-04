using System;
using System.Collections.Generic;
using tournaments_api.Enums;

namespace tournaments_api.Services
{
    static public class Utils
    {
        static public KeyValuePair<DateTime, DateTime> GetDateTime(Period period)
        {

            KeyValuePair<DateTime, DateTime> dateTime = new();

            switch (period)
            {
                case Period.Today:
                    dateTime = new(DateTime.Today, DateTime.Today.AddHours(24));
                    break;
                case Period.TwoWeeks:
                    dateTime = new(DateTime.Today, DateTime.Today.AddDays(14));
                    break;
                case Period.OneMonth:
                    dateTime = new(DateTime.Today, DateTime.Today.AddMonths(2));
                    break;
                case Period.SixMonths:
                    dateTime = new(DateTime.Today, DateTime.Today.AddMonths(6));
                    break;
                case Period.OneYear:
                    dateTime = new(DateTime.Today, new DateTime(DateTime.Today.Year, 12, 31));
                    break;
            }

            return dateTime;
        }
    }
}
