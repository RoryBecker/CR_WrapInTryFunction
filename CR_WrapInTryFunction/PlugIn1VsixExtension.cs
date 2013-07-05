using System.ComponentModel.Composition;
using DevExpress.CodeRush.Common;

namespace CR_WrapInTryFunction
{
    [Export(typeof(IVsixPluginExtension))]
    public class CR_WrapInTryFunctionExtension : IVsixPluginExtension { }
}