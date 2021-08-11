using System;
using System.Collections.Generic;
using FigureHandler.Exceptions;

namespace FigureHandler
{
    public class FigureHandler
    {
        private List<IFigureCreator> figureCreatorList = new List<IFigureCreator>();

        public void AddFigureCreator(IFigureCreator figureCreator)
        {
            figureCreatorList.Add(figureCreator);
        }

        public bool TryCreateFigure(double[] lengths, out IFigure figure)
        {
            if(lengths == null)
            {
                figure = null;
                return false;
            }

            figure = CreateFigureInternal(lengths);

            return figure != null;
        }

        public IFigure CreateFigure(double[] lengths)
        {
            if(lengths == null)
            {
                throw new ArgumentNullException(nameof(lengths));
            }

            IFigure figure = CreateFigureInternal(lengths);

            if(figure == null)
            {
                string msg = $"There is no acceptable figure creator for parameters [{String.Join(", ", lengths)}]";

                throw new CouldNotCreateFigureException(msg);
            }

            return figure;
        }

        private IFigure CreateFigureInternal(double[] lengths)
        {
            foreach(IFigureCreator figureCreator in figureCreatorList)
            {
                IFigure result = figureCreator.CreateFigure(lengths);

                if(result != null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}
