using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Products;

namespace HerbsStore.Libraries.HS.Core.Domain.Diseases
{
    public class ProductDisease : BaseEntity
    {
        public long ProductId { get; set; }
        public Product Product{ get; set; }
        public long DiseaseId { get; set; }
        public Disease Disease { get; set; }

    }
}
