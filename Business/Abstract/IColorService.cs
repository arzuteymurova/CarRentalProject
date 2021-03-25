using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);

        IResult Update(Color color);

        IResult Delete(Color color);
        IDataResult<List<Color>> GetAll();
    }
}
