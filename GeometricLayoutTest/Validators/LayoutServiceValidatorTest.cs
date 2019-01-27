using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLayout.Validators;

namespace GeometricLayoutTest.Validators
{
    [TestClass]
    public class LayoutServiceValidatorTest
    {
        private LayoutServiceValidator _layoutServiceValidator;

        [TestInitialize]
        public void Setup()
        {
            _layoutServiceValidator = new LayoutServiceValidator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateByRowColumn_InvalidRow_Failed()
        {
            // act
            _layoutServiceValidator.ValidateByRowColumn('G', 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateByRowColumn_InvalidColumn_Failed()
        {
            // act
            _layoutServiceValidator.ValidateByRowColumn('A', 13);
        }

        [TestMethod]
        public void ValidateByRowColumn_Successful()
        {
            // act
            _layoutServiceValidator.ValidateByRowColumn('A', 2);
        }
    }
}
