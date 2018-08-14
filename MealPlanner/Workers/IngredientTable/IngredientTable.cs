using System.Collections.ObjectModel;

namespace MealPlanner.Workers.IngredientTable
{
    public class IngredientTable : IIngredientTable
    {
        public ObservableCollection<IngredientTableRow> IngredientRows { get; set; }



        public IngredientTable()
        {
            IngredientRows = new ObservableCollection<IngredientTableRow>()
            {
                new IngredientTableRow(0, this)
            };
        }



        /// <summary>
        /// Receive and process the changes in the table
        /// </summary>
        /// <param name="tablerow">A <see cref="IngredientTableRow"/> which called
        /// this method</param>
        public void Synchronize()
        {
            if (NeedNewRow())
            {
                IngredientRows.Add(new IngredientTableRow(IngredientRows.Count, this));
            }
        }

        private bool NeedNewRow()
        {
            foreach (var row in IngredientRows)
            {
                if (!row.IsFilled)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
