using System;
using GeometricLayout.Interfaces;
using GeometricLayout.Configs;

namespace GeometricLayout.Validators
{
    public class LayoutServiceValidator : ILayoutServiceValidator
    {
        public void ValidateByRowColumn(char row, int column)
        {
            if (row < LayoutConstants.MinRow || row > LayoutConstants.MaxRow)
            {
                throw new ArgumentOutOfRangeException("The row of the Id referenced is invalid.");
            }

            if (column < LayoutConstants.MinColumn || column > LayoutConstants.MaxColumn)
            {
                throw new ArgumentOutOfRangeException("The column of the Id referenced is invalid.");
            }
        }
    }
}
