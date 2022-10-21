using System.Collections.Generic;
using System.Linq;
using AvaTabUiTest.Utils.Base.Collection;
using ReactiveUI;

namespace AvaTabUiTest.Utils.Base.Tree
{
    public abstract class TreeCollectionBase<T> : ReactiveObject where T : class, ITreeNode<T>, ISelected
    {
        private T _root;

        public T Root
        {
            get => _root;
            set => this.RaiseAndSetIfChanged(ref _root, value);
        }

        private ObservableCollectionWithSelectedItem<T> _itemsCollection = new();

        public ObservableCollectionWithSelectedItem<T> ItemsCollection
        {
            get => _itemsCollection;
            set => this.RaiseAndSetIfChanged(ref _itemsCollection, value);
        }

        protected TreeCollectionBase(T root)
        {
            _root = root;
            ItemsCollection.Add(_root);
        }

        //public IEnumerable<T> GetAllNodesByVm(TVm vm) => ItemsCollection.Where(x => x.ViewModel.WndVm == vm);

        //public IEnumerable<TVm> GetAllVms()
        //{
        //    return ItemsCollection.Select(x => x.ViewModel.WndVm).Distinct().Cast<TVm>();
        //}

        //public IEnumerable<T> GetAllNodesByVmAndShip(TVm vm, Ship ship) => GetAllNodesByVm(vm).Where(x => Equals(x.Ship, ship));

        public IEnumerable<T> GetAllChildNodes(T item, bool includeSelf = true)
        {
            var items = new List<T>();
            if(includeSelf)
                items.Add(item);
            GetAllChildNodes(item, ref items);
            return OrderLikeItemsCollection(items);
        }

        internal void GetAllChildNodes(T item, ref List<T> items)
        {
            foreach (var x in item.Childs)
                GetAllChildNodes(x, ref items);
        }

        internal bool AddChild(T? parent, T? child)
        {
            if (parent == null || child == null) return false;
            parent.AddChild(child);
            ItemsCollection.Add(child);
            return true;
        }

        internal void RemoveChild(T parent, T child)
        {
            ItemsCollection.Remove(child);
            parent.RemoveChild(child);
        }

        private IEnumerable<T> OrderLikeItemsCollection(IEnumerable<T> items) => _itemsCollection.Join(items, x => x, c => c, (_, c) => c);
    }
}
