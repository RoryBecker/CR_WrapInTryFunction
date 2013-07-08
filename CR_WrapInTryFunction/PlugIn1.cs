using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CR_WrapInTryFunction
{
    public partial class PlugIn1 : StandardPlugIn
    {
        // DXCore-generated code...
        #region InitializePlugIn
        public override void InitializePlugIn()
        {
            base.InitializePlugIn();
            registerWrapInTryFunction();
        }
        #endregion
        #region FinalizePlugIn
        public override void FinalizePlugIn()
        {
            //
            // TODO: Add your finalization code here.
            //

            base.FinalizePlugIn();
        }
        #endregion
        public void registerWrapInTryFunction()
        {
            DevExpress.CodeRush.Core.CodeProvider WrapInTryFunction = new DevExpress.CodeRush.Core.CodeProvider(components);
            ((System.ComponentModel.ISupportInitialize)(WrapInTryFunction)).BeginInit();
            WrapInTryFunction.ProviderName = "Wrap In Try Function"; // Should be Unique
            WrapInTryFunction.DisplayName = "Wrap In Try Function";
            WrapInTryFunction.CheckAvailability += WrapInTryFunction_CheckAvailability;
            WrapInTryFunction.Apply += WrapInTryFunction_Apply;
            ((System.ComponentModel.ISupportInitialize)(WrapInTryFunction)).EndInit();
        }
        private void WrapInTryFunction_CheckAvailability(Object sender, CheckContentAvailabilityEventArgs ea)
        {

            Method activeMethod = CodeRush.Source.ActiveMethod;
            ea.Available = activeMethod != null && activeMethod.MethodType == MethodTypeEnum.Function;
        }

        private void WrapInTryFunction_Apply(Object sender, ApplyContentEventArgs ea)
        {
            // INITIALIZE
            Class activeClass = CodeRush.Source.ActiveClass;
            Method activeMethod = CodeRush.Source.ActiveMethod;
            var builder = new ElementBuilder();


            var method = builder.AddMethod(activeClass, "bool", "Try" + activeMethod.Name);

            // STATIC
            method.IsStatic = activeMethod.IsStatic;

            // PARAMS
            foreach (Param param in activeMethod.Parameters)
            {
                method.Parameters.Add(new Param(param.ParamType, param.Name));
            }
            Param resultParam = builder.BuildParameter(activeMethod.GetTypeName(), "result", ArgumentDirection.Out);
            method.Parameters.Add(resultParam);


            // METHOD CALL
            var arguments = new List<string>();
            foreach (IParameterElement SourceParam in activeMethod.Parameters)
            {
                arguments.Add(SourceParam.Name);
            }

            var methodCall = builder.BuildMethodCall(activeMethod.Name, arguments.ToArray());
            
            var Try = builder.AddTry(method);
            Try.AddNode(builder.BuildAssignment("result", methodCall));
            Try.AddNode(builder.BuildReturn("true"));

            var ExCatch = builder.AddCatch(method);
            ExCatch.AddNode(builder.BuildAssignment("result", CodeRush.Language.GetNullReferenceExpression()));
            ExCatch.AddNode(builder.BuildReturn("false"));

            // RENDER METHOD
            activeClass.AddNode(method);
            var Code = CodeRush.CodeMod.GenerateCode(method, false);
            int LastLine = activeMethod.Range.End.Line;
            var newMethodRange = CodeRush.Documents.ActiveTextDocument.InsertText(new SourcePoint(LastLine+1,1), Code);
            CodeRush.Documents.Format(newMethodRange);
        }
    }
}