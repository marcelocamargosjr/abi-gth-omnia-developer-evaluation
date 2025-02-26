using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
///     Repository interface for Sale entity operations.
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    ///     Retrieves a paginated list of sales with optional ordering.
    /// </summary>
    /// <param name="page">Page number for pagination.</param>
    /// <param name="size">Number of items per page.</param>
    /// <param name="order">Ordering of results (e.g., "saleDate desc, totalAmount asc").</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paginated list of sales.</returns>
    Task<IEnumerable<Sale>> GetPagedAsync(int page, int size, string? order, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a sale by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the sale.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The sale if found, null otherwise.</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new sale in the repository.
    /// </summary>
    /// <param name="sale">The sale to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created sale.</returns>
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing sale in the repository.
    /// </summary>
    /// <param name="sale">The sale to update.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated sale.</returns>
    Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a sale from the repository.
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the sale was deleted, false if not found.</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}