using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    /// <summary>
    /// 主要DB存取上下文介面
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// 租戶
        /// </summary>
        DbSet<Tenant> Tenants { get; }

        /// <summary>
        /// 使用者
        /// </summary>
        DbSet<User> Users { get; }

        /// <summary>
        /// 儲存變更
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// 使用SQL查詢指定清單
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<T>> SqlQueryListAsync<T>(string sql, object[]? parameters = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 使用SQL查詢單筆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T?> SqlQueryFirstOrDefaultAsync<T>(string sql, object[]? parameters = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 單純執行SQL語法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ExecuteSqlAsync(string sql, object[]? parameters = null, CancellationToken cancellationToken = default);
    }
}
