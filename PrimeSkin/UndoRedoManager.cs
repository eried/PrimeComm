using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace PrimeSkin
{
    internal class UndoRedoManager<T> where T : class
    {
        private readonly LinkedList<T> _undoLinkedList;
        private readonly Stack<T> _redoStack;
        private readonly CloneManager _cloneManager;

        public int Capacity { get; private set; }

        public UndoRedoManager(int capacity)
        {
            Capacity = capacity;

            _cloneManager = new CloneManager();
            _undoLinkedList = new LinkedList<T>();
            _redoStack = new Stack<T>();
        }

        public void SaveState(T state)
        {
            while (_undoLinkedList.Count() > Capacity)
                _undoLinkedList.RemoveFirst();

            _undoLinkedList.AddLast(_cloneManager.Clone(state));
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (CanUndo)
            {
                _redoStack.Push(_undoLinkedList.Last.Value);
                _undoLinkedList.RemoveLast();
            }

            OnStateChanged();
        }

        public bool CanUndo
        {
            get { return _undoLinkedList.Count > 1; }
        }

        public void Redo()
        {
            if (CanRedo)
                _undoLinkedList.AddLast(_redoStack.Pop());

            OnStateChanged();
        }

        public bool CanRedo
        {
            get { return _redoStack.Count > 0; }
        }

        public T GetLast()
        {
            return _undoLinkedList.Last.Value;
        }

        public event EventHandler<EventArgs> StateChanged;

        protected virtual void OnStateChanged()
        {
            var handler = StateChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Generics cloner based on serialization
    /// http://www.codeproject.com/Articles/25418/Object-Cloning-Using-Generic-in-C
    /// </summary>
    public class CloneManager : IClone
    {
        public T Clone<T>(T instance) where T : class
        {
            var serializer = new XmlSerializer(typeof (T));
            var stream = new MemoryStream();
            serializer.Serialize(stream, instance);
            stream.Seek(0, SeekOrigin.Begin);
            return serializer.Deserialize(stream) as T;
        }
    }

    public interface IClone
    {
        T Clone<T>(T instance) where T : class;
    }
}
