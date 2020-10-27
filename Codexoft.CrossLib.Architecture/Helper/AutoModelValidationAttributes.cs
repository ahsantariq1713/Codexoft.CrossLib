using PostSharp.Aspects;
using PostSharp.Serialization;
using Codexoft.CrossLib.Architecture.Data.Entities;
using Codexoft.CrossLib.Architecture.Services.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codexoft.CrossLib.Architecture.Helper
{
    [PSerializable]
    public class AutoValidateModelIfClient : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (AuthenticatedUserProvider.NotClaimBasedAuthentication)
            {
                foreach (var arg in args.Arguments)
                {
                    if (arg is BaseValidation)
                    {
                        ((BaseValidation)arg).TryValidate();
                        break;
                    }
                }
            }
        }
    }



}
