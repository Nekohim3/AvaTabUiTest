using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaTabUiTest.Utils.Base.Tree;
using AvaTabUiTest.Utils.Impl.Tree;
using AvaTabUiTest.Utils.Impl.ViewModel;

namespace AvaTabUiTest
{
    public static class TabViewControl
    {
        public static TreeViewModelCollection<TabWindowViewModel> Tree { get; set; }

        public static void Init()
        {
            
        }

        public static bool AddAndSwitchView<T>(TabViewModel parent, Func<T> child) where T : TabViewModel
        {
            var type  = typeof(T);
            var insts = Tree.ItemsCollection.Where(x => x.GetType().Name == type.Name).OfType<TabViewModel>().ToList();
            if (!insts.Any())
            {
                return SwitchView(AddView(parent, child));
            }

            switch (insts.First().AllowMultipleInstances)
            {
                case AllowMultipleInstancesEnum.None: break;
                case AllowMultipleInstancesEnum.OneForAnchor:
                {
                    return insts.Select(x => x.Anchor).Contains(parent.Anchor) ? SwitchView(insts.First(x => Equals(x.Anchor, parent.Anchor))) : SwitchView(AddView(parent, child));
                }
                case AllowMultipleInstancesEnum.NotLimited:
                    return SwitchView(AddView(parent, child));
                default: return false;
            }

            return false;
        }

        public static T AddView<T>(TabViewModel parent, Func<T> child) where T : TabViewModel
        {
            var parentNode = parent;
            var ch         = child.Invoke();
            ch.WndVm = parent.WndVm;
            Tree.AddChild(parentNode, ch);
            return ch;
        }

        public static void RemoveView()
        {

        }

        public static bool SwitchView(TabViewModel node)
        {
            node.WndVm.Content = node;
            if (!node.WndVm.Wnd.IsActive)
                node.WndVm.Wnd.Activate();
            return true;
        }

        //public static bool SwitchView(TabViewModel vm) => SwitchView(vm);
    }
}
