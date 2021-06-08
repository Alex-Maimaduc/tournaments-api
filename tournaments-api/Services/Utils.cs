using System;
using System.Collections.Generic;
using tournaments_api.Enums;

namespace tournaments_api.Services
{
    static public class Utils
    {
        static public KeyValuePair<DateTime, DateTime> GetDateTime(Period period, Status status)
        {

            KeyValuePair<DateTime, DateTime> dateTime = new();

            if (status != Status.Finished)
            {
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
                        dateTime = new(DateTime.Today, DateTime.Today.AddYears(1));
                        break;
                }
            }
            else
            {
                switch (period)
                {
                    case Period.Today:
                        dateTime = new(DateTime.Now.AddHours(-24), DateTime.Now);
                        break;
                    case Period.TwoWeeks:
                        dateTime = new(DateTime.Now.AddDays(-14), DateTime.Now);
                        break;
                    case Period.OneMonth:
                        dateTime = new(DateTime.Now.AddMonths(-2), DateTime.Now);
                        break;
                    case Period.SixMonths:
                        dateTime = new(DateTime.Now.AddMonths(-6), DateTime.Now);
                        break;
                    case Period.OneYear:
                        dateTime = new(DateTime.Now.AddYears(-1), DateTime.Now);
                        break;
                }
            }


            return dateTime;
        }
    }
}
