using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometricLayout.Models;

namespace GeometricLayoutTest.Models
{
    [TestClass]
    public class TriangleIndentifierTest
    {
        [TestMethod]
        public void ToString_Test()
        {
            // act
            var id = new TriangleIndentifier() { Row = 'F', Column = 1 };

            // assert
            Assert.AreEqual("F1", id.ToString());
        }
    }
}
