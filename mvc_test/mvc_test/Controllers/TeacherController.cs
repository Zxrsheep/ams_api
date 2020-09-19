using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_test.Models;
using mvc_test.Data;
using Microsoft.EntityFrameworkCore;

namespace mvc_test.Controllers
{
    public class TeacherController : Controller
    {
        private readonly mvc_testContext _context;

        public TeacherController(mvc_testContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ClassSituation()
        {
            var register = from m in _context.register
                           select m;
            return View(await register.ToListAsync());
        }
        public async Task<IActionResult> ApprovalLeave()
        {
            var leave_application = from m in _context.leave_application
                           select m;
            return View(await leave_application.ToListAsync());
        }
        public async Task<IActionResult> ApprovalSupply()
        {
            var supplementary_signature = from m in _context.supplementary_signature
                                    select m;
            return View(await supplementary_signature.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
