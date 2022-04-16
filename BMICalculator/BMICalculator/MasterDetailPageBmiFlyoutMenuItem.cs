using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculator
{
    public class MasterDetailPageBmiFlyoutMenuItem
    {
        public MasterDetailPageBmiFlyoutMenuItem()
        {
            TargetType = typeof(MasterDetailPageBmiFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}