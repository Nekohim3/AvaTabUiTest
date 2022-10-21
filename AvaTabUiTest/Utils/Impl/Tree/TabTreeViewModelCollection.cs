using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaTabUiTest.MarinosEntities;
using AvaTabUiTest.Utils.Base.Tree;
using AvaTabUiTest.Utils.Base.ViewModel;
using AvaTabUiTest.Utils.Impl.ViewModel;

namespace AvaTabUiTest.Utils.Impl.Tree
{
    public class TreeViewModelCollection<TVm> : TreeCollectionBase<ViewNodeBase<Ship>> where TVm : TabWindowViewModel
    {
        public TreeViewModelCollection(TabViewModel root) : base(root)
        {
            
        }

        public IEnumerable<TabViewModel> GetAllNodesByWindowViewModel(TVm        vm)            => ItemsCollection.OfType<TabViewModel>().Where(x => x.WndVm == vm);
        public IEnumerable<TabViewModel> GetAllNodesByShip(Ship                  ship)          => ItemsCollection.OfType<TabViewModel>().Where(x => Equals(x.Anchor, ship));
        public IEnumerable<TabViewModel> GetAllNodesByWindowViewModelANdShip(TVm vm, Ship ship) => ItemsCollection.OfType<TabViewModel>().Where(x => Equals(x.Anchor, ship) && x.WndVm == vm);

    }
}
