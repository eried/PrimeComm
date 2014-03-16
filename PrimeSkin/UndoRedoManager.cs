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
            Debug.WriteLine("Saving! undo: " + _undoLinkedList.Count + ", redo: "+ _redoStack.Count);

            while (_undoLinkedList.Count() > Capacity)
                _undoLinkedList.RemoveFirst();

            _undoLinkedList.AddLast((T) ((ICloneable)state).Clone());
            _redoStack.Clear();
            Debug.WriteLine("Done. undo: " + _undoLinkedList.Count + ", redo: " + _redoStack.Count);
            OnStateChanged();
        }

        public void Undo()
        {
            Debug.WriteLine("Undoing: " + _undoLinkedList.Count + ", redo: " + _redoStack.Count);
            if (CanUndo)
            {
                _redoStack.Push(_undoLinkedList.Last.Value);
                _undoLinkedList.RemoveLast();
            }
            Debug.WriteLine("Done. undo: " + _undoLinkedList.Count + ", redo: " + _redoStack.Count);
            OnStateChanged();
        }

        public bool CanUndo
        {
            get { return _undoLinkedList.Count > 1; }
        }

        public void Redo()
        {
            Debug.WriteLine("Redoing: " + _undoLinkedList.Count + ", redo: " + _redoStack.Count);
            if (CanRedo)
                _undoLinkedList.AddLast(_redoStack.Pop());
            Debug.WriteLine("Done. undo: " + _undoLinkedList.Count + ", redo: " + _redoStack.Count);
            OnStateChanged();
        }

        public bool CanRedo
        {
            get { return _redoStack.Count > 0; }
        }

        public T GetState()
        {
            return (T) ((ICloneable) _undoLinkedList.Last.Value).Clone();
        }

        public event EventHandler<EventArgs> StateChanged;

        protected virtual void OnStateChanged()
        {
            var handler = StateChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
