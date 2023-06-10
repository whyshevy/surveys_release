namespace Surveys.Backend.Foundation.Common.ErrorProviders.Interfaces;

public interface IErrorProvider<TSourceError, TDestinationError>
{
    TSourceError SourceError { get; }

    TDestinationError GetConvertedError();
}
