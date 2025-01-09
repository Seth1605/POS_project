using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM4_C__POS_pj.model
{
    public abstract class Action : interface_action
    {
        public virtual void create()
        {
            throw new NotImplementedException();
        }

        public virtual void delete(DataGridView dg)
        {
            throw new NotImplementedException();
        }

        public virtual void loading_data(DataGridView dg)
        {
            throw new NotImplementedException();
        }

        public virtual void search(DataGridView dg)
        {
            throw new NotImplementedException();
        }

        public virtual void update(DataGridView dg)
        {
            throw new NotImplementedException();
        }
    }
}
