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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateByCoordinates_InvalidCoordinate_TooLarge()
        {
            // act
            _layoutServiceValidator.ValidateByCoordinates(0, 10, 20, 30, 40, 70);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateByCoordinates_InvalidCoordinate_TooSmall()
        {
            // act
            _layoutServiceValidator.ValidateByCoordinates(0, 10, 20, 30, 40, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateByCoordinates_InvalidCoordinate_IllegalPosition()
        {
            // act
            _layoutServiceValidator.ValidateByCoordinates(0, 10, 20, 30, 40, 11);
        }

        [TestMethod]
        public void ValidateByCoordinates_Successful()
        {
            // act
            _layoutServiceValidator.ValidateByCoordinates(0, 10, 20, 30, 40, 60);
        }
    }
}
