using DependencyInjectionDemo.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets;

namespace DependencyInjectionDemo.Controllers;


[ApiController]
[Route("[controller]")]
public class LifeTimeController : ControllerBase
{
    private readonly ITransientService _transientServcie;
    private readonly IScopedService _scopedService;
    private readonly ISingletonService _singletonService;
    
    public LifeTimeController(ITransientService transientService,
                              IScopedService scopedService,
                              ISingletonService singletonService)
    {
        _transientServcie = transientService;
        _scopedService = scopedService;
        _singletonService = singletonService;
    }


    [HttpGet]
    public ActionResult Get()
    {
        var transientServiceMessage = _transientServcie.SayHello();
        var scopedServiceMessage = _scopedService.SayHello();
        var singletonServiceMessage = _singletonService.SayHello();

        return Content($"{transientServiceMessage} {Environment.NewLine} {scopedServiceMessage} {Environment.NewLine} {singletonServiceMessage}");
    }

    [HttpGet("sql")]
    public ActionResult GetSql([FromKeyedServices("SqlDatabaseService")] IDataService dataService)
    {
        return Content(dataService.GetData());

    }

     [HttpGet("mongo")]
    public ActionResult GetMongo([FromKeyedServices("MongoDatabaseService")] IDataService dataService)
    {
        return Content(dataService.GetData());

    }


}