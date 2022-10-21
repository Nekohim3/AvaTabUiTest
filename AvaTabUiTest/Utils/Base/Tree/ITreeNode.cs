using AvaTabUiTest.Utils.Base.Collection;

namespace AvaTabUiTest.Utils.Base.Tree
{
    public interface ITreeNode<T> where T : class, ISelected
    {
        public bool                                    IsRoot { get; }
        public int                                     Depth  { get; }
        public T?                                      Parent { get; set; }
        public ObservableCollectionWithSelectedItem<T> Childs { get; set; }

        public void AddChild(T    child);
        public void RemoveChild(T child);
        public T    GetFirst(T    item);
        public T    GetNext(T     item);
        public T    GetPrev(T     item);
        public T    GetLast(T     item);
    }
}
