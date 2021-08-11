using NUnit.Framework;
using FigureHandler;
using FigureHandler.Figures;
using FigureHandler.FigureCreators;

namespace UnitTests
{
    public class TriangleCreatorTests
    {
        [TestCase(3, 4, 5)]
        public void TriangleCreator_WasInitializedWithCorrectValues_ReturnCorrectFigure(double a, double b, double c)
        {
            IFigureCreator figureCreator = new TriangleCreator();

            IFigure figure = figureCreator.CreateFigure(new double[] { a, b, c });

            Assert.IsNotNull(figure);
            Assert.AreEqual(typeof(Triangle), figure.GetType());
            Assert.AreEqual(true, figure.IsValid);
        }

        [TestCase(10, 12)]
        public void TriangleCreator_WasInitializedWithWrongValues_ReturnNull(double a, double b)
        {
            IFigureCreator figureCreator = new TriangleCreator();

            IFigure figure = figureCreator.CreateFigure(new double[] { a, b });

            Assert.IsNull(figure);
        }
    }
}