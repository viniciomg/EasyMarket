using EasyMarket.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyMarket.Service.Api.Controllers.Base
{
  public class BaseController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public BaseController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
  }


}
