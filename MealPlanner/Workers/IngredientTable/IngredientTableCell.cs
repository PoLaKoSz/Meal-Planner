using MealPlanner.Models;

namespace MealPlanner.Workers.IngredientTable
{
    public class IngredientTableCell : FoodIngredient, IIngredientTableCell
    {
        private readonly IIngredientTableRow _container;


        public int ColumnIndex { get; protected set; }
        public new string Name
        {
            get => base.Name;
            set
            {
                base.Name = value;
                NotifyPropertyChanged();
                SignalToContainer();
            }
        }
        public new int Quantity
        {
            get => base.Quantity;
            set
            {
                base.Quantity = value;
                NotifyPropertyChanged();
                SignalToContainer();
            }
        }
        public new string QuantityName
        {
            get => base.QuantityName;
            set
            {
                base.QuantityName = value;
                NotifyPropertyChanged();
                SignalToContainer();
            }
        }



        public IngredientTableCell(int columnIndex, IIngredientTableRow container)
            : base(0, "", "")
        {
            ColumnIndex = columnIndex;
            _container = container;
        }



        /// <summary>
        /// Notify the container about the value changes in this cell when
        /// the cell became valid (filled)
        /// </summary>
        public void SignalToContainer()
        {
            if (IsValid())
                _container.Synchronize(this);
        }

        /// <summary>
        /// Perform a validation on the current cell
        /// </summary>
        /// <returns><c>true</c> if the cell holds valid data</returns>
        public bool IsValid()
        {
            return base.Name.Length != 0 &&
                QuantityName.Length != 0 &&
                Quantity != default(double);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            IngredientTableCell anotherCell = (IngredientTableCell)obj;

            if (ColumnIndex != anotherCell.ColumnIndex)
                return false;

            return base.Equals(obj);
        }
    }
}
