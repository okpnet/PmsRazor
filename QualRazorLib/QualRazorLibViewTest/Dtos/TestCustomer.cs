using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLibViewTest.Dtos
{
    public class TestCustomer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool? IsSupplier { get; set; }
        [Range(-1.0,1.0)]
        public decimal CostRate { get; set; }

        public int TestStateId { get; set; }

        public TestState? TestState { get; set; }
    }
}
