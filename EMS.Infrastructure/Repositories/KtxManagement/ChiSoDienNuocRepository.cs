using System.Linq.Expressions;
using EMS.Domain.Entities.KtxManagement;
using EMS.Domain.Interfaces.Repositories.KtxManagement;
using EMS.Domain.Models;
using EMS.Infrastructure.DataAccess;
using EMS.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;


public class ChiSoDienNuocRepository(DbFactory dbFactory)
    : AuditRepository<KtxChiSoDienNuoc>(dbFactory), IChiSoDienNuocRepository
{
}