using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace PrimeSkin
{
    internal class UndoRedoManager<T> where T : class
    {
        private readonly LinkedList<T> _undoLinkedList;
        private readonly Stack<T> _redoStack;

        public int Capacity { get; private set; }

        public UndoRedoManager(int capacity)
        {
            Capacity = capacity;

            _undoLinkedList = new LinkedList<T>();
            _redoStack = new Stack<T>();
        }

        public void SaveState(T state)
        {
            Debug.WriteLine("Saving!");

            while (_undoLinkedList.Count() > Capacity)
                _undoLinkedList.RemoveFirst();

            _undoLinkedList.AddLast((T) ((ICloneable)state).Clone());
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

        public T GetState()
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
}
