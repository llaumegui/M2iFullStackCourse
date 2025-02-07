using Exos.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestExos.Classes;

[TestClass]
public class TestGradingCalculator
{
    [TestMethod]
    [DataRow(95,90,'A')]
    [DataRow(85,90,'B')]
    [DataRow(65,90,'C')]
    [DataRow(95,65,'B')]
    [DataRow(95,55,'F')]
    [DataRow(65,55,'F')]
    [DataRow(50,90,'F')]
    [DataRow(50,90,'A')]
    public void CalculateGrade(int score,int attendancePercentage, char expectedGrade)
    {
        var calculator = new GradingCalculator();
        calculator.Score = score;
        calculator.AttendancePercentage = attendancePercentage;
        Assert.AreEqual(expectedGrade, calculator.GetGrade());
    }
}