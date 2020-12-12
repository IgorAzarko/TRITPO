using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Z.Expressions;


namespace RPNTest
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void AddTwoNumbers()
        {
            string testAddingNumebrs = "2+3";
            int result = Eval.Execute<int>(testAddingNumebrs);
            Assert.IsTrue(result == 5);
        }

        [TestMethod]
        public void SubTwoNumbers()
        {
            string testSubNumebrs = "2-3";
            int result = Eval.Execute<int>(testSubNumebrs);
            Assert.IsTrue(result == -1);
        }

        [TestMethod]
        public void MulTwoNumbers()
        {
            string testMulNumebrs = "2*3";
            int result = Eval.Execute<int>(testMulNumebrs);
            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void DivTwoNumbers()
        {
            string testDivNumebrs = "4/2";
            int result = Eval.Execute<int>(testDivNumebrs);
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void SinOfNull()
        {
            string testSinOfNull = "sin(0)";
            double result = Eval.Execute<double>(testSinOfNull);
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void CosOfNull()
        {
            string testCosOfNull = "cos(0)";
            int result = Eval.Execute<int>(testCosOfNull);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void TanOfNull()
        {
            string testTanOfNull = "tan(0)";
            int result = Eval.Execute<int>(testTanOfNull);
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void CotOfNull()
        {
            bool isExcept = false;
            try
            {
                string testTanOfNull = "tan(0)";
                int result = Eval.Execute<int>(testTanOfNull);
                int inf = 1 / result;
            } catch(Exception)
            {
                isExcept = true;
            }
            Assert.IsTrue(isExcept);
        }
    }
}
