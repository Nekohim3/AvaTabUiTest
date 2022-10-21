using System;
using System.Reactive;
using AvaTabUiTest.Utils.Base.Collection;
using AvaTabUiTest.Utils.Base.ViewModel;
using ReactiveUI;

namespace AvaTabUiTest.Utils.Base.Tree
{
    public enum AllowMultipleInstancesEnum
    {
        None = 0,
        OneForAnchor = 1,
        NotLimited = 2,
    }

    public abstract class ViewNodeBase<TAnchor> : ViewModelBase, ITreeNode<ViewNodeBase<TAnchor>>, ISelected where TAnchor : class
    {
        public AllowMultipleInstancesEnum AllowMultipleInstances;
        public bool                       IsClosable;

        private TAnchor _anchor;

        public TAnchor Anchor
        {
            get => _anchor;
            set => this.RaiseAndSetIfChanged(ref _anchor, value);
        }

        //private TabViewModelBase _viewModel;

        //public TabViewModelBase ViewModel
        //{
        //    get => _viewModel;
        //    set => this.RaiseAndSetIfChanged(ref _viewModel, value);
        //}

        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set => this.RaiseAndSetIfChanged(ref _isSelected, value);
        }

        private ViewNodeBase<TAnchor>? _parent;

        public ViewNodeBase<TAnchor>? Parent
        {
            get => _parent;
            set => this.RaiseAndSetIfChanged(ref _parent, value);
        }

        private ObservableCollectionWithSelectedItem<ViewNodeBase<TAnchor>> _childs = new();

        public ObservableCollectionWithSelectedItem<ViewNodeBase<TAnchor>> Childs
        {
            get => _childs;
            set => this.RaiseAndSetIfChanged(ref _childs, value);
        }

        public bool IsRoot => Parent == null;
        public int  Depth  => Parent == null ? 0 : Parent.Depth + 1;

        //public ViewNodeBase(TabViewModelBase vm, Ship ship, ViewNodeBase? parent = null)
        //{
        //    //AllowMultipleInstances = AllowMultiInstancesEnum.None;
        //    IsClosable      = true;
        //    _viewModel      = vm;
        //    _viewModel.Node = this;
        //    _ship           = ship;
        //    _parent         = parent;
        //    SwitchCmd       = ReactiveCommand.Create(OnSwitch);
        //    CloseCmd        = ReactiveCommand.Create(OnClose);
        //    EscapeCmd       = ReactiveCommand.Create(OnEscape);
        //}

        protected ViewNodeBase(TAnchor anchor, ViewNodeBase<TAnchor>? parent = null)
        {
            AllowMultipleInstances = AllowMultipleInstancesEnum.None;
            IsClosable      = true;
            _anchor = anchor;
            _parent = parent;
        }

        public virtual void AddChild(ViewNodeBase<TAnchor> child)
        {
            Childs.Add(child);
            child.Parent = this;
        }

        public virtual void RemoveChild(ViewNodeBase<TAnchor> child)
        {
            child.Parent = null;
            Childs.Remove(child);
        }

        public ViewNodeBase<TAnchor> GetFirst(ViewNodeBase<TAnchor> item)
        {
            throw new NotImplementedException();
        }

        public ViewNodeBase<TAnchor> GetNext(ViewNodeBase<TAnchor> item)
        {
            throw new NotImplementedException();
        }

        public ViewNodeBase<TAnchor> GetPrev(ViewNodeBase<TAnchor> item)
        {
            throw new NotImplementedException();
        }

        public ViewNodeBase<TAnchor> GetLast(ViewNodeBase<TAnchor> item)
        {
            throw new NotImplementedException();
        }
    }
}
