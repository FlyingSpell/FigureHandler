using FigureHandler.Figures;

namespace FigureHandler.FigureCreators
{
    public class CircleCreator : IFigureCreator
    {
        public IFigure CreateFigure(double[] lengths)
        {
            if(lengths.Length != 1)
            {
                return null;
            }
            else
            {
                return new Circle(lengths[0]);
            }
        }
    }
}
