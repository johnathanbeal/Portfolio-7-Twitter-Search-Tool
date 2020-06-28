using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Ikkyo.Model
{
    public class SearchViewModel
    {
        public string q { get; set; }

        public string geocode { get; set; }

        public string lang { get; set; }
        //https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.twoletterisolanguagename?view=netcore-3.1

        public string locale { get; set; }

        public ResultType result_type {get; set; }

        private string _until;
        public DateTime until 
        { 
            get
            {
                IFormatProvider culture = new CultureInfo("en-US", true);
                return DateTime.ParseExact(this._until, "YYYY-MM-DD", culture);
            }
                           
            set
            {
                this._until = value.ToString();
            }
        }

        public int since_id { get; set; }

        public int max_id { get; set; }

        public bool include_entities { get; set; }

        public SearchViewModel()
        {
            lang = "English";
            locale = "ja";
            result_type = ResultType.mixed;
        }
    }
}
