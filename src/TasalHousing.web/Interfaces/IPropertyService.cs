using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasalHousing.web.Models;

namespace TasalHousing.web.Interfaces
{
    public interface IPropertyService
    {
        Task AddProperty(PropertyModel model);
    }
}
