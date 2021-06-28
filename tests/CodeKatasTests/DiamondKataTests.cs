using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CodeKatas.Tests
{
    [TestClass]
    [TestCategory("Unit")]
    public class DiamondKataTests
    {
        [TestMethod]
        public void CreateDiamondTest_OnInputA_Should_OnlyDisplay_A()
        {
            //Arange, Act
            var result = DiamondKata.CreateDiamond('A');
            var result2 = DiamondKata.CreateDiamond('a');

            //Assert
            Assert.AreEqual("A", result);
            Assert.AreEqual("A", result2);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void CreateDiamondTest_OnValidInput_Should_Display_Diamond(char input, string expected)
        {
            //Arange, Act
            var result = DiamondKata.CreateDiamond(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow('`')]
        [DataRow('!')]
        [DataRow('"')]
        [DataRow('£')]
        [DataRow('$')]
        [DataRow('%')]
        [DataRow('^')]
        [DataRow('&')]
        [DataRow('*')]
        [DataRow('(')]
        [DataRow(')')]
        [DataRow('_')]
        [DataRow('-')]
        [DataRow('+')]
        [DataRow('=')]
        [DataRow('1')]
        [DataRow('@')]
        [DataRow('~')]
        [DataRow('/')]
        [DataRow('|')]
        [DataRow('\\')]
        [DataRow('>')]
        [DataRow('<')]
        [DataRow('?')]
        [DataRow(',')]
        [DataRow('.')]
        public void CreateDiamondTest_OnInvalidInput_Should_Throw_ArgumentOutOfRangeException(char invalidChar)
        {
            //Arange, Act
            Action result = () => DiamondKata.CreateDiamond(invalidChar);

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(result);
        }

        private static IEnumerable<object[]> GetData()
        {
            yield return new object[] { 'B',
                        " A "
                + Environment.NewLine + "B B"
                + Environment.NewLine + " A "};

            yield return new object[] { 'D',
                                        "   A   "
                + Environment.NewLine + "  B B  "
                + Environment.NewLine + " C   C "
                + Environment.NewLine + "D     D"
                + Environment.NewLine + " C   C "
                + Environment.NewLine + "  B B  "
                + Environment.NewLine + "   A   "};
        }
    }
}