using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.Rest.Infrastructure.CrossCutting.Helpers
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset, DateTimeOffset? dateOfDeath)
        {
            var dateToCalulateTo = DateTime.UtcNow;
            if(dateOfDeath != null)
            {
                dateToCalulateTo = dateOfDeath.Value.UtcDateTime;
            }

            int age = dateToCalulateTo.Year - dateTimeOffset.Year;

            if(dateToCalulateTo < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
