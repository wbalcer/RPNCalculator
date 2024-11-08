using System.Reflection;
using RPN.Operations;

namespace RPN;

public class OperationDiscoverer
{
    public Dictionary<string, IOperation> DiscoverOperations()
    {
        var operations = new Dictionary<string, IOperation>();
        var operationTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IOperation).IsAssignableFrom(t) && t.GetCustomAttribute<OperationAttribute>() != null);

        foreach (var operationType in operationTypes)
        {
            var attribute = operationType.GetCustomAttribute<OperationAttribute>();
            if (attribute != null)
            {
                var operationInstance = (IOperation)Activator.CreateInstance(operationType);
                operations[attribute.Symbol] = operationInstance;
            }
        }

        return operations;
    }
}
