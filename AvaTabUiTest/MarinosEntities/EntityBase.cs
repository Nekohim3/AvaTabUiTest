using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaTabUiTest.Utils.Base.Collection;
using AvaTabUiTest.Utils.Base.ViewModel;

namespace AvaTabUiTest.MarinosEntities
{
    public class EntityBase : ViewModelBase, ISelected
    {
        public int  Id         { get; set; }
        public bool IsSelected { get; set; }

        public EntityBase(int id)
        {
            Id = id;
        }

    }
}
