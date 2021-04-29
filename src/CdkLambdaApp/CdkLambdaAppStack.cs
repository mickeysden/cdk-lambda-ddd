using System.Collections.Generic;
using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;

namespace CdkLambdaApp
{
    public class CdkLambdaAppStack : Stack
    {
        internal CdkLambdaAppStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var functionOne = new Function(this, "FunctionOne", new FunctionProps
            {
                Code = Code.FromAsset("lambdas/CdkLambdaApp.FunctionOne/src/CdkLambdaApp.FunctionOne/bin/Release/netcoreapp3.1/"),
                Runtime = Runtime.DOTNET_CORE_3_1,
                Handler = "CdkLambdaApp.FunctionOne::CdkLambdaApp.FunctionOne.Function::FunctionHandler"
            });
        }
    }
}
