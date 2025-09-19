using Rs.Application.Features.Provinces.CommandHandlers;
using Rs.Application.Features.Provinces.CommandHandlers.ImportCityFromExcel;
using Rs.Application.Features.Provinces.CommandHandlers.ImportDistrictFromExcel;
using Rs.Application.Features.Provinces.CommandHandlers.ImportNeighborhoodFromExcel;
using Rs.Application.Features.Provinces.CommandHandlers.ImportProvinceFromExcel;

namespace Rs.Api.Controllers;

public class ProvinceController : BaseController
{
    [HttpPost]
    [Route("import-provinces")]
    public async Task<ActionResult<bool>> ImportProvinceData(
        [FromForm] ImportProvinceFromExcelCommand request,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return response.ToActionResult();
    }    
    
    [HttpPost]
    [Route("import-cities")]
    public async Task<ActionResult<bool>> ImportCityData(
        [FromForm] ImportCityFromExcelCommand request,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return response.ToActionResult();
    }  
    
    [HttpPost]
    [Route("import-district")]
    public async Task<ActionResult<bool>> ImportDistrictData(
        [FromForm] ImportDistrictFromExcelCommand request,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return response.ToActionResult();
    }   
    
    [HttpPost]
    [Route("import-neighborhood")]
    public async Task<ActionResult<bool>> ImportNeighborhoodData(
        [FromForm] ImportNeighborhoodFromExcelCommand request,
        CancellationToken cancellationToken)
    {
        var response = await Mediator.Send(request, cancellationToken);

        return response.ToActionResult();
    }   
}