using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Data;
using MvcCoreEFDepartamentos.Models;

namespace MvcCoreEFDepartamentos.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentoContext context;

        public RepositoryDepartamentos(DepartamentoContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            var consulta = from datos in this.context.Departamentos select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int deptNo)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.deptNo == deptNo
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }
        
        public async Task InsertDepartamentoAsync(int deptNo, string dnombre, string loc)
        {
            Departamento dept = new Departamento();
            dept.deptNo = deptNo;
            dept.dNombre = dnombre;
            dept.localidad = loc;
            this.context.Departamentos.Add(dept);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDepartamentoAsync(int deptNo, string dnombre, string loc)
        {
            Departamento dept = await this.FindDepartamentoAsync(deptNo);
            if (dept != null)
            {
                dept.dNombre = dnombre;
                dept.localidad = loc;
                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeleteDepartamentoAsync(int deptNo)
        {
            Departamento dept = await this.FindDepartamentoAsync(deptNo);
            if (dept != null)
            {
                this.context.Departamentos.Remove(dept);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
