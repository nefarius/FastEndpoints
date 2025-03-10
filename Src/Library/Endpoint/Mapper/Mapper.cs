﻿using Microsoft.Extensions.DependencyInjection;

// ReSharper disable UnusedParameter.Global

namespace FastEndpoints;

/// <summary>
/// use this base class to define domain entity mappers for your endpoints.
/// <para>HINT: entity mappers are used as singletons for performance reasons. do not maintain state in the mappers.</para>
/// </summary>
/// <typeparam name="TRequest">the type of request dto</typeparam>
/// <typeparam name="TResponse">the type of response dto</typeparam>
/// <typeparam name="TEntity">the type of domain entity to map to/from</typeparam>
public abstract class Mapper<TRequest, TResponse, TEntity> : IMapper, IServiceResolverBase where TRequest : notnull where TResponse : notnull
{
    /// <summary>
    /// override this method and place the logic for mapping the request dto to the desired domain entity
    /// </summary>
    /// <param name="r">the request dto</param>
    public virtual TEntity ToEntity(TRequest r)
        => throw new NotImplementedException($"Please override the {nameof(ToEntity)} method!");

    /// <summary>
    /// override this method and place the logic for mapping the request dto to the desired domain entity
    /// </summary>
    /// <param name="r">the request dto to map from</param>
    /// <param name="ct">a cancellation token</param>
    public virtual Task<TEntity> ToEntityAsync(TRequest r, CancellationToken ct = default)
        => throw new NotImplementedException($"Please override the {nameof(ToEntityAsync)} method!");

    /// <summary>
    /// override this method and place the logic for mapping a domain entity to a response dto
    /// </summary>
    /// <param name="e">the domain entity to map from</param>
    public virtual TResponse FromEntity(TEntity e)
        => throw new NotImplementedException($"Please override the {nameof(FromEntity)} method!");

    /// <summary>
    /// override this method and place the logic for mapping a domain entity to a response dto
    /// </summary>
    /// <param name="e">the domain entity to map from</param>
    /// <param name="ct">a cancellation token</param>
    public virtual Task<TResponse> FromEntityAsync(TEntity e, CancellationToken ct = default)
        => throw new NotImplementedException($"Please override the {nameof(FromEntityAsync)} method!");

    /// <summary>
    /// override this method and place the logic for mapping the updated request dto to the desired domain entity
    /// </summary>
    /// <param name="r">the request dto to update from</param>
    /// <param name="e">the domain entity to update</param>
    public virtual TEntity UpdateEntity(TRequest r, TEntity e)
        => throw new NotImplementedException($"Please override the {nameof(UpdateEntity)} method!");

    /// <summary>
    /// override this method and place the logic for mapping the updated request dto to the desired domain entity
    /// </summary>
    /// <param name="r">the request dto to update from</param>
    /// <param name="e">the domain entity to update</param>
    /// <param name="ct">a cancellation token</param>
    public virtual Task<TEntity> UpdateEntityAsync(TRequest r, TEntity e, CancellationToken ct = default)
        => throw new NotImplementedException($"Please override the {nameof(UpdateEntityAsync)} method!");    

    /// <inheritdoc />
    public TService? TryResolve<TService>() where TService : class
        => Cfg.ServiceResolver.TryResolve<TService>();

    /// <inheritdoc />
    public object? TryResolve(Type typeOfService)
        => Cfg.ServiceResolver.TryResolve(typeOfService);

    /// <inheritdoc />
    public TService Resolve<TService>() where TService : class
        => Cfg.ServiceResolver.Resolve<TService>();

    /// <inheritdoc />
    public object Resolve(Type typeOfService)
        => Cfg.ServiceResolver.Resolve(typeOfService);

    /// <inheritdoc />
    public IServiceScope CreateScope()
        => Cfg.ServiceResolver.CreateScope();

    /// <inheritdoc />
    public TService? TryResolve<TService>(string keyName) where TService : class
        => Cfg.ServiceResolver.TryResolve<TService>(keyName);

    /// <inheritdoc />
    public object? TryResolve(Type typeOfService, string keyName)
        => Cfg.ServiceResolver.TryResolve(typeOfService, keyName);

    /// <inheritdoc />
    public TService Resolve<TService>(string keyName) where TService : class
        => Cfg.ServiceResolver.Resolve<TService>(keyName);

    /// <inheritdoc />
    public object Resolve(Type typeOfService, string keyName)
        => Cfg.ServiceResolver.Resolve(typeOfService, keyName);
}

/// <summary>
/// use this base class to define a domain entity mapper for your endpoints that only has a request dto and no response dto.
/// <para>HINT: entity mappers are used as singletons for performance reasons. do not maintain state in the mappers.</para>
/// </summary>
/// <typeparam name="TRequest">the type of request dto</typeparam>
/// <typeparam name="TEntity">the type of domain entity to map to/from</typeparam>
public abstract class RequestMapper<TRequest, TEntity> : IRequestMapper, IServiceResolverBase where TRequest : notnull
{
    /// <summary>
    /// override this method and place the logic for mapping the request dto to the desired domain entity
    /// </summary>
    /// <param name="r">the request dto</param>
    public virtual TEntity ToEntity(TRequest r)
        => throw new NotImplementedException($"Please override the {nameof(ToEntity)} method!");

    /// <summary>
    /// override this method and place the logic for mapping the request dto to the desired domain entity
    /// </summary>
    /// <param name="r">the request dto to map from</param>
    /// <param name="ct">a cancellation token</param>
    public virtual Task<TEntity> ToEntityAsync(TRequest r, CancellationToken ct = default)
        => throw new NotImplementedException($"Please override the {nameof(ToEntityAsync)} method!");

    /// <summary>
    /// override this method and place the logic for mapping the updated request dto to the desired domain entity
    /// </summary>
    /// <param name="r">the request dto to update from</param>
    /// <param name="e">the domain entity to update</param>
    public virtual TEntity UpdateEntity(TRequest r, TEntity e)
        => throw new NotImplementedException($"Please override the {nameof(UpdateEntity)} method!");

    /// <summary>
    /// override this method and place the logic for mapping the updated request dto to the desired domain entity
    /// </summary>
    /// <param name="r">the request dto to update from</param>
    /// <param name="e">the domain entity to update</param>
    /// <param name="ct">a cancellation token</param>
    public virtual Task<TEntity> UpdateEntityAsync(TRequest r, TEntity e, CancellationToken ct = default)
        => throw new NotImplementedException($"Please override the {nameof(UpdateEntityAsync)} method!");  
        
    /// <inheritdoc />
    public TService? TryResolve<TService>() where TService : class
        => Cfg.ServiceResolver.TryResolve<TService>();

    /// <inheritdoc />
    public object? TryResolve(Type typeOfService)
        => Cfg.ServiceResolver.TryResolve(typeOfService);

    /// <inheritdoc />
    public TService Resolve<TService>() where TService : class
        => Cfg.ServiceResolver.Resolve<TService>();

    /// <inheritdoc />
    public object Resolve(Type typeOfService)
        => Cfg.ServiceResolver.Resolve(typeOfService);

    /// <inheritdoc />
    public IServiceScope CreateScope()
        => Cfg.ServiceResolver.CreateScope();

    /// <inheritdoc />
    public TService? TryResolve<TService>(string keyName) where TService : class
        => Cfg.ServiceResolver.TryResolve<TService>(keyName);

    /// <inheritdoc />
    public object? TryResolve(Type typeOfService, string keyName)
        => Cfg.ServiceResolver.TryResolve(typeOfService, keyName);

    /// <inheritdoc />
    public TService Resolve<TService>(string keyName) where TService : class
        => Cfg.ServiceResolver.Resolve<TService>(keyName);

    /// <inheritdoc />
    public object Resolve(Type typeOfService, string keyName)
        => Cfg.ServiceResolver.Resolve(typeOfService, keyName);
}

/// <summary>
/// use this base class to define a domain entity mapper for your endpoints that only has a response dto and no request dto.
/// <para>HINT: entity mappers are used as singletons for performance reasons. do not maintain state in the mappers.</para>
/// </summary>
/// <typeparam name="TResponse">the type of response dto</typeparam>
/// <typeparam name="TEntity">the type of domain entity to map to/from</typeparam>
public abstract class ResponseMapper<TResponse, TEntity> : IResponseMapper, IServiceResolverBase where TResponse : notnull
{
    /// <summary>
    /// override this method and place the logic for mapping a domain entity to a response dto
    /// </summary>
    /// <param name="e">the domain entity to map from</param>
    public virtual TResponse FromEntity(TEntity e)
        => throw new NotImplementedException($"Please override the {nameof(FromEntity)} method!");

    /// <summary>
    /// override this method and place the logic for mapping a domain entity to a response dto
    /// </summary>
    /// <param name="e">the domain entity to map from</param>
    /// <param name="ct">a cancellation token</param>
    public virtual Task<TResponse> FromEntityAsync(TEntity e, CancellationToken ct = default)
        => throw new NotImplementedException($"Please override the {nameof(FromEntityAsync)} method!");

    /// <inheritdoc />
    public TService? TryResolve<TService>() where TService : class
        => Cfg.ServiceResolver.TryResolve<TService>();

    /// <inheritdoc />
    public object? TryResolve(Type typeOfService)
        => Cfg.ServiceResolver.TryResolve(typeOfService);

    /// <inheritdoc />
    public TService Resolve<TService>() where TService : class
        => Cfg.ServiceResolver.Resolve<TService>();

    /// <inheritdoc />
    public object Resolve(Type typeOfService)
        => Cfg.ServiceResolver.Resolve(typeOfService);

    /// <inheritdoc />
    public IServiceScope CreateScope()
        => Cfg.ServiceResolver.CreateScope();

    /// <inheritdoc />
    public TService? TryResolve<TService>(string keyName) where TService : class
        => Cfg.ServiceResolver.TryResolve<TService>(keyName);

    /// <inheritdoc />
    public object? TryResolve(Type typeOfService, string keyName)
        => Cfg.ServiceResolver.TryResolve(typeOfService, keyName);

    /// <inheritdoc />
    public TService Resolve<TService>(string keyName) where TService : class
        => Cfg.ServiceResolver.Resolve<TService>(keyName);

    /// <inheritdoc />
    public object Resolve(Type typeOfService, string keyName)
        => Cfg.ServiceResolver.Resolve(typeOfService, keyName);
}
