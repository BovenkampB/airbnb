using Airbnb_v3.Models;
using Airbnb_v3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb_v3.ViewModels
{
    public class ListingsViewModel
    {
        public ListingsFilters filters;
        public IEnumerable<Neighbourhoods> neighbourhoods;

        public ListingsViewModel(ListingsFilters filters, IEnumerable<Neighbourhoods> neighbourhoods)
        {
            this.filters = filters;
            this.neighbourhoods = neighbourhoods;
        }
    }
}
