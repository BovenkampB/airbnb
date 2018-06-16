using Airbnb_gcp.Models;
using Airbnb_gcp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb_gcp.ViewModels
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
