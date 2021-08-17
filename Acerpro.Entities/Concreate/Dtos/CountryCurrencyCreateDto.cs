﻿using Acerpro.Entities.Abstruct;

namespace Acerpro.Entities.Concreate.Dtos
{
    public class CountryCurrencyCreateDto : IDto
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CapitalCityName { get; set; }
        public string CurrencyName { get; set; }
    }
}