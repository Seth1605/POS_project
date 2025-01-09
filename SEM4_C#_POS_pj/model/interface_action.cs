using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM4_C__POS_pj.model
{
    public interface interface_action
    {
        void create();
        void update(DataGridView dg);
        void delete(DataGridView dg);
        void search(DataGridView dg);
        void loading_data(DataGridView dg);

 


    }
}
