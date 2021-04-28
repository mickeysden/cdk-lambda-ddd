using System.Collections.Generic;
using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;

namespace CdkLambdaApp
{
    public class CdkLambdaAppStack : Stack
    {
        internal CdkLambdaAppStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var layerRuntimes = new Runtime[1];
            layerRuntimes[0] = Runtime.DOTNET_CORE_3_1;

            var orderDomain = new LayerVersion(this, "OrderDomain", new LayerVersionProps()
            {
                Code = Code.FromAsset("domain/CdkLambdaApp.Domain.Orders/bin/Release/netcoreapp3.1/"),
                CompatibleRuntimes = layerRuntimes
            });

            var functionOneLayers = new LayerVersion[1];
            functionOneLayers[0] = orderDomain;

            var functionOne = new Function(this, "FunctionOne", new FunctionProps
            {
                Code = Code.FromAsset("lambdas/CdkLambdaApp.FunctionOne/src/CdkLambdaApp.FunctionOne/bin/Release/netcoreapp3.1/"),
                Runtime = Runtime.DOTNET_CORE_3_1,
                Handler = "CdkLambdaApp.FunctionOne::CdkLambdaApp.FunctionOne.Function::FunctionHandler",
                Layers = functionOneLayers
            });
        }
    }
}
