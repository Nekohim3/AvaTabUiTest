using System;
using Avalonia.Controls;
using AvaTabUiTest.MarinosEntities;
using AvaTabUiTest.Utils.Base.Collection;
using AvaTabUiTest.Utils.Base.Tree;
using AvaTabUiTest.Utils.Base.ViewModel;
using ReactiveUI;

namespace AvaTabUiTest.Utils.Impl.ViewModel
{
    public class TabWindowViewModel : ViewModelBase
    {
        private TabViewModelBase<Ship>? _content;

        public TabViewModelBase<Ship>? Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        private ObservableCollectionWithSelectedItem<ViewNodeBase<Ship>> _tabList = new();

        public ObservableCollectionWithSelectedItem<ViewNodeBase<Ship>> TabList
        {
            get => _tabList;
            set => this.RaiseAndSetIfChanged(ref _tabList, value);
        }

        private ObservableCollectionWithSelectedItem<Ship> _shipTabList = new();

        public ObservableCollectionWithSelectedItem<Ship> ShipTabList
        {
            get => _shipTabList;
            set => this.RaiseAndSetIfChanged(ref _shipTabList, value);
        }

        public Window Wnd { get; set; }

        public TabWindowViewModel(Window wnd)
        {
            this.WhenAnyValue(x => x.Content).Subscribe(_ => { RefreshTabList(); });
            Wnd = wnd;
        }

        public void RefreshTabList()
        {

        }
    }
}
