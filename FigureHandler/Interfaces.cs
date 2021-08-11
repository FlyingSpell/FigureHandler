
namespace FigureHandler
{
    public interface IFigure
    {
        double Area { get; }
        bool IsValid { get; }
    }

    public interface IFigureCreator
    {
        public IFigure CreateFigure(double[] lengths);
    }
}
