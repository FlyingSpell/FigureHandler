using FigureHandler.Figures;

namespace FigureHandler.FigureCreators
{
    public class TriangleCreator : IFigureCreator
    {
        public IFigure CreateFigure(double[] lengths)
        {
            if(lengths.Length != 3)
            {
                return null;
            }
            else
            {
                return new Triangle(lengths[0], lengths[1], lengths[2]);
            }
        }
    }
}
