using DomainModel.Models;
using ExamTracker.Common;
using log4net;
using System.Text;
using System.Text.RegularExpressions;

namespace DomainModel.Helpers;

public class FluentErrors
{
    private string _parameter;
    private StringBuilder _errorList;
    private int _counter = 1;
	private bool _ignoreOtherValidations = false;
    private int _errorCount = 0;

    public bool HasErrors => _errorCount > 0;

    public FluentErrors(string headerErrorMessage)
    {
        _errorList = new StringBuilder(headerErrorMessage);
    }

    public FluentErrors Parameter(string parameter)
    {
        _ignoreOtherValidations = false;
        _parameter = parameter;
        return this;
    }

    public FluentErrors SatysfiesCondition(Func<bool> condition, string errorMessage)
    {
		if (_ignoreOtherValidations) return this;

		if (!condition())
        {
            _errorList.AppendLine($"{_counter++}. {errorMessage}");
            _ignoreOtherValidations = true;
            _errorCount++;
        }

        return this;
    }

	public FluentErrors SatisfyRegex(string pattern, string errorMessage)
	{
        ArgumentNullException.ThrowIfNull(_parameter);

        if (_ignoreOtherValidations) return this;

        return SatysfiesCondition(() => Regex.IsMatch(_parameter, pattern), errorMessage);
	}

    public FluentErrors IsNullOrEmptyString(string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(_parameter);

		if (_ignoreOtherValidations) return this;

		return SatysfiesCondition(() => !string.IsNullOrEmpty(_parameter), errorMessage);
    }

    public StringBuilder GetErrors() => _errorList;

	public override string ToString()
	{
		return _errorList.ToString();
	}
}
