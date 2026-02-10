using Microsoft.AspNetCore.Mvc;
using MvcCoreEFDepartamentos.Models;
using MvcCoreEFDepartamentos.Repositories;
using System.Threading.Tasks;

namespace MvcCoreEFDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int deptNo)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(deptNo);
            return View(dept);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.repo.InsertDepartamentoAsync(dept.deptNo, dept.dNombre, dept.localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int deptNo)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(deptNo);
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento dept)
        {
            await this.repo.UpdateDepartamentoAsync(dept.deptNo, dept.dNombre, dept.localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int deptNo)
        {
            await this.repo.DeleteDepartamentoAsync(deptNo);
            return RedirectToAction("Index");
        }

    }
}
