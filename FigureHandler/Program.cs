using System;
using FigureHandler.FigureCreators;
using FigureHandler.Exceptions;

namespace FigureHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            FigureHandler figureHandler = new FigureHandler();

            figureHandler.AddFigureCreator(new CircleCreator());
            figureHandler.AddFigureCreator(new TriangleCreator());

            try
            {
                CreateFigureAndPrintTypeAndArea(figureHandler, new double[] { 10 }, "maybeCircle");
                CreateFigureAndPrintTypeAndArea(figureHandler, new double[] { 3, 4, 5 }, "maybeTriangle");
                CreateFigureAndPrintTypeAndArea(figureHandler, new double[] { 10, 10 }, "maybeSquare");
            }
            catch(CouldNotCreateFigureException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CreateFigureAndPrintTypeAndArea(FigureHandler figureHandler, double[] lengts, string figureName)
        {
            IFigure figure = figureHandler.CreateFigure(lengts);
            Console.WriteLine($"{figureName} type is '{figure.GetType().Name}', and area = {figure.Area.ToString("0.####")}");
        }
    }
}
