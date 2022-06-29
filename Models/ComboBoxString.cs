using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardsWPF.Models
{
    public class ComboBoxString
    {
        public string ValueString { get; set; }

        public ComboBoxString(string ValueString)
        {
            this.ValueString = ValueString;
        }
    }
}