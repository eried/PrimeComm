using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeSkin
{
    /// <summary>
    /// Generic Undo Redo manager
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
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

        /// <summary>
        /// Pushes the state to the undo list, clearing the redo
        /// </summary>
        /// <param name="state">State to save</param>
        public void SaveState(T state)
        {
            while (_undoLinkedList.Count() > Capacity)
                _undoLinkedList.RemoveFirst();

            _undoLinkedList.AddLast((T) ((ICloneable)state).Clone());
            _redoStack.Clear();

            OnUndoRedoStateChanged();
        }

        public void Undo()
        {
            if (CanUndo)
            {
                _redoStack.Push(_undoLinkedList.Last.Value);
                _undoLinkedList.RemoveLast();
            }
            OnUndoRedoStateChanged();
        }

        public bool CanUndo
        {
            get { return _undoLinkedList.Count > 1; }
        }

        public void Redo()
        {
            if (CanRedo)
                _undoLinkedList.AddLast(_redoStack.Pop());

            OnUndoRedoStateChanged();
        }

        public bool CanRedo
        {
            get { return _redoStack.Count > 0; }
        }

        /// <summary>
        /// Returns a cloned copy of the current state
        /// </summary>
        /// <returns>Last saved state</returns>
        public T GetState()
        {
            return (T) ((ICloneable) _undoLinkedList.Last.Value).Clone();
        }

        /// <summary>
        /// Occurs when the current state has changed
        /// </summary>
        public event EventHandler<EventArgs> UndoRedoStateChanged;

        protected virtual void OnUndoRedoStateChanged()
        {
            var handler = UndoRedoStateChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
