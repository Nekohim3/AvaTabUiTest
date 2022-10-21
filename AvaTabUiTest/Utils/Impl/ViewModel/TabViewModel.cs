using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaTabUiTest.MarinosEntities;
using AvaTabUiTest.Utils.Base.Tree;
using AvaTabUiTest.Utils.Base.ViewModel;
using ReactiveUI;

namespace AvaTabUiTest.Utils.Impl.ViewModel
{
    public abstract class TabViewModel : TabViewModelBase<Ship>
    {
        private TabWindowViewModel _wndVm;

        public TabWindowViewModel WndVm
        {
            get => _wndVm;
            set => this.RaiseAndSetIfChanged(ref _wndVm, value);
        }

        protected TabViewModel(Ship? anchor, ViewNodeBase<Ship>? parent = null) : base(anchor, parent)
        {

        }

        protected TabViewModel(ViewNodeBase<Ship>? parent = null) : base(g.CurrentShip, parent)
        {

        }
    }

    public static class TabViewModelExtension
    {
        public static bool AddAndSwitchView<T>(this TabViewModel parent, Func<T> child) where T : TabViewModel => TabViewControl.AddAndSwitchView(parent, child);
        public static T    AddView<T>(this          TabViewModel parent, Func<T> child) where T : TabViewModel => TabViewControl.AddView(parent, child);
        public static bool SwitchView(this          TabViewModel view) => TabViewControl.SwitchView(view);
        //public static bool SwitchView(this          ViewNodeBase     node) => TabViewControl.SwitchView(node);
    }

}
