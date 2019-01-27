using System;
using Microsoft.AspNetCore.Mvc;
using GeometricLayout.Interfaces;
using GeometricLayout.Models;

#region GeometricLayoutController
namespace GeometricLayout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayoutController : ControllerBase
    {
        private readonly ILayoutService _layoutService;
        #endregion

        public LayoutController(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }

        #region snippet_GetByRowColumn
        [HttpGet("row/{row}/column/{column}")]
        public ActionResult<RightTriangle> GetByRowColumn(char row, int column)
        {
            try
            {
                return _layoutService.GetByRowColumn(Char.ToUpper(row), column);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return UnprocessableEntity(e.ParamName);
            }
        }
        #endregion

        #region snippet_GetByCoordinates
        [HttpGet("x1/{x1}/y1/{y1}/x2/{x2}/y2/{y2}/x3/{x3}/y3/{y3}")]
        public ActionResult<TriangleLocation> GetByCoordinates(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            try
            {
                return _layoutService.GetByCoordinates(x1, y1, x2, y2, x3, y3);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return UnprocessableEntity(e.ParamName);
            }
        }
        #endregion
    }
}