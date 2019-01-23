using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GeometricLayout.Services;
using GeometricLayout.Interfaces;

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

        #region snippet_GetAll
        [HttpGet]
        public ActionResult<List<ITriangle>> GetAll()
        {
            return _layoutService.GetAll();
        }
        #endregion

        #region snippet_GetByRowColumn
        [HttpGet("{id}")]
        public ActionResult<ITriangle> GetById(string id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region snippet_GetByVertexCoordinates
        [HttpGet("?coordinates={corodinates}")]
        public ActionResult<IGeometricItem> GetByCoordinates(string coordinates)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}