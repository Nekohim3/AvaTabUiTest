using AvaTabUiTest.Utils.Base.Tree;
using AvaTabUiTest.Utils.Impl.ViewModel;
using System;
using System.Reactive;
using AvaTabUiTest.MarinosEntities;
using AvaTabUiTest.Utils.Base.Collection;
using ReactiveUI;

namespace AvaTabUiTest.Utils.Base.ViewModel
{
    public abstract class TabViewModelBase<TAnchor> : ViewNodeBase<TAnchor> where TAnchor : class
    {
        public          string        Title { get; set; }
        //public ViewNodeBase       Node  { get; set; }
        //public abstract bool   IsEditable             { get; }
        //public abstract bool   AllowMultipleInstances { get; }

        //protected TabViewModelBase()
        //{
        //    //WndVm                  = wnd;
        //    Title = GetType().Name;
        //}

        public ReactiveCommand<Unit, Unit> SwitchCmd { get; }
        public ReactiveCommand<Unit, Unit> CloseCmd  { get; }
        public ReactiveCommand<Unit, Unit> EscapeCmd { get; }

        protected TabViewModelBase(TAnchor? anchor, ViewNodeBase<TAnchor>? parent = null) : base(anchor, parent)
        {
            Title     = GetType().Name;
            SwitchCmd = ReactiveCommand.Create(OnSwitch);
            CloseCmd  = ReactiveCommand.Create(OnClose);
            EscapeCmd = ReactiveCommand.Create(OnEscape);
        }

        public virtual void OnSwitch()
        {
            throw new NotImplementedException();
        }

        public virtual void OnClose()
        {
            throw new NotImplementedException();
        }

        public virtual void OnEscape()
        {
            throw new NotImplementedException();
        }
    }
}
