using System.Collections.ObjectModel;
using System.Linq;

namespace MealPlanner.Workers.IngredientTable
{
    public class IngredientTableRow : IIngredientTableRow
    {
        private readonly IIngredientTable _container;

        
        public int RowIndex { get; protected set; }
        public bool IsFilled { get; protected set; }
        public ObservableCollection<IngredientTableCell> Cells { get; set; }



        public IngredientTableRow(int rowIndex, IIngredientTable container)
        {
            _container = container;
            RowIndex = rowIndex;
            IsFilled = false;
            Cells = new ObservableCollection<IngredientTableCell>()
            {
                new IngredientTableCell(0, this)
            };
        }



        /// <summary>
        /// Notify this row's container when every cell is valid (filled)
        /// </summary>
        /// <param name="cell"><see cref="IngredientTableCell"/> which became valid
        /// (filled) and invoced this method</param>
        public void Synchronize(IIngredientTableCell cell)
        {
            if (IsCellsFilled())
            {
                Cells.Add(new IngredientTableCell(Cells.Count, this));

                if (cell.ColumnIndex == Cells.Count - 2)
                    _container.Synchronize();
            }
        }

        /// <summary>
        /// Determinate if the cells inside the row is filled
        /// </summary>
        /// <returns><c>TRUE</c> if every required property inside the
        /// <see cref="IngredientTableCell"/> is filled,
        /// <c>FALSE</c> otherwise</returns>
        private bool IsCellsFilled()
        {
            foreach (IngredientTableCell cell in Cells)
            {
                if (!cell.IsValid())
                    return IsFilled = false;
            }

            return IsFilled = true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var anotherTableRow = (IngredientTableRow)obj;

            if (!Enumerable.SequenceEqual(Cells, anotherTableRow.Cells))
                return false;

            return true;
        }
    }
}
