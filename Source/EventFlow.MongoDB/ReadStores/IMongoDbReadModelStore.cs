﻿using EventFlow.ReadStores;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Logs;
using MongoDB.Driver;

namespace EventFlow.MongoDB.ReadStores
{
	public interface IMongoDbReadModelStore<TReadModel> : IReadModelStore<TReadModel>
		where TReadModel : class, IReadModel, new()
	{
		ILog Log { get; }
		IMongoDatabase MongoDatabase { get; }
		IReadModelDescriptionProvider ReadModelDescriptionProvider { get; }

		Task<IAsyncCursor<TReadModel>> FindAsync(
			Expression<Func<TReadModel, bool>> filter,
			FindOptions<TReadModel, TReadModel> options = null,
			CancellationToken cancellationToken = default(CancellationToken));
	}
}
