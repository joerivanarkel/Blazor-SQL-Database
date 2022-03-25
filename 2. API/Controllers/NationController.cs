using Business;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;

namespace API.Controllers
{
    public class NationController : BaseController<Nation>
    {
        public NationController(INationService nationService) : base(nationService) { }
    }
}