using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors
{
	public class ValidationBehavior<TRequest, TRespons>(IEnumerable<IValidator<TRequest>> validators)
		: IPipelineBehavior<TRequest, TRespons>
		where TRequest : ICommand<TRespons>
	{
		public async Task<TRespons> Handle(TRequest request, RequestHandlerDelegate<TRespons> next, CancellationToken cancellationToken)
		{
			var context = new ValidationContext<TRequest>(request);

			var validationResults = await Task.WhenAll(validators.Select(x => x.ValidateAsync(context, cancellationToken)));

			var failures = validationResults
				.Where(r => r.Errors.Any())
				.SelectMany(r => r.Errors)
				.ToList();

			if (failures.Any())
			{
				throw new ValidationException(failures);
			}

			return await next();
		}
	}
}
