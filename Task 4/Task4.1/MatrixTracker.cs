namespace Task4._1
{
    public class MatrixTracker<T>
    {
        private GenericDiagonalMatrix<T> _diagonalMatrix;
        private Stack<GenericMatrixElementChangedEventArgs<T>> _changes = new Stack<GenericMatrixElementChangedEventArgs<T>>();
        public MatrixTracker(GenericDiagonalMatrix<T> matrix)
        {
            _diagonalMatrix = matrix;
            Subscribe();
        }

        private void Subscribe()
        {
            _diagonalMatrix.ElementChanged += HandleElementChanged;
        }
        public void Unsubscribe()
        {
            _diagonalMatrix.ElementChanged -= HandleElementChanged;
        }

        private void HandleElementChanged(object? sender, GenericMatrixElementChangedEventArgs<T> elementChanged)
        {
            _changes.Push(elementChanged);
        }

        public void Undo()
        {
            if (_changes.Count > 0)
            {
                var lastChange = _changes.Pop();
                _diagonalMatrix[lastChange.I, lastChange.J] = lastChange.OldValue;
            }
        }
    }
}
